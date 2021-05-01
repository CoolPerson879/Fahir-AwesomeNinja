using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour {

	public float realHealth;

	public AudioClip deadSound;
	private AudioSource audioSource;

	private Animator anim;
	private bool isDead;

	private CapsuleCollider col;

	private string ANIMATION_DEAD = "Dead";
	private string BASE_LAYER_DEAD = "Base Layer.Dead";

	void Awake () {
		anim = GetComponent<Animator> ();
		audioSource = GetComponent<AudioSource> ();
		col = GetComponent<CapsuleCollider> ();
	}

	void Update () {
		if (isDead) {
			StopDeadAnimation();
		}
	}

	void BossDying() {
		anim.SetBool (ANIMATION_DEAD, true);
		isDead = true;
		col.enabled = false;
		audioSource.PlayOneShot (deadSound);
	}

	public void BossTakeDamage(float amount) {
		realHealth -= amount;

		Debug.Log ("BOSS TOOK DAMAGE - HEALTH IS " + realHealth);

		if (realHealth <= 0) {
			realHealth = 0;
			BossDying ();
		}
	}

	void StopDeadAnimation() {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName (BASE_LAYER_DEAD)) {
			anim.SetBool (ANIMATION_DEAD, false);
		}
	}

} // class











































