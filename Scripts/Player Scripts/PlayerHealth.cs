using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float realHealth;

	private Animator anim;
	private bool playerDead;
	private bool playerBeHit;

	private Slider healthSlider;
	private Text healthText;

	private BossHealth bossHealth;
	private Transform bossTransform;
	private bool victory;

	private string ANIMATION_DEAD = "Dead";
	private string ANIMATION_ATTACK = "Attack";
	private string ANIMATION_VICTORY = "Victory";

	private string BASE_LAYER_DYING = "Base Layer.Dying";
	private string BASE_LAYER_VICTORY = "Base Layer.Victory";

	void Awake () {
		anim = GetComponent<Animator> ();

		healthSlider = GameObject.Find ("Health Foreground").GetComponent<Slider> ();
		healthText = GameObject.Find ("Health Text").GetComponent<Text> ();

		healthText.text = realHealth.ToString ();
		healthSlider.value = realHealth;

		bossTransform = GameObject.FindGameObjectWithTag ("Boss").transform;
		bossHealth = bossTransform.gameObject.GetComponent<BossHealth> ();

	}

	void Update () {

		if(realHealth <= 0) {
			realHealth = 0;
			PlayerDying();
		}

		if (playerDead) {
			StopPlayerDeadAnimation();
		}

//		if (realHealth > 100) {
//			realHealth = 100f;
//		}

		if (bossHealth.realHealth <= 0) {
			Victory();
		}

		if (victory) {
			StopVictoryAnimation();
		}
	}

	void PlayerDying() {
		playerDead = true;
		anim.SetBool (ANIMATION_DEAD, true);
		anim.SetBool (ANIMATION_ATTACK, false);
	}

	void StopPlayerDeadAnimation() {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (BASE_LAYER_DYING)) {
			anim.SetBool (ANIMATION_DEAD, false);	
		}
	}

	public void TakeDamage(float amount) {
		realHealth -= amount;

		if (realHealth <= 0) {
			realHealth = 0;
		}

		if (amount > 0) {
			healthText.text = realHealth.ToString();
			healthSlider.value = realHealth;
			playerBeHit = true;
		}
	}

	void Victory() {
		anim.SetBool (ANIMATION_VICTORY, true);
		victory = true;
	}

	void StopVictoryAnimation() {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (BASE_LAYER_VICTORY)) {
			anim.SetBool (ANIMATION_VICTORY, false);	
		}
	}

} // class































