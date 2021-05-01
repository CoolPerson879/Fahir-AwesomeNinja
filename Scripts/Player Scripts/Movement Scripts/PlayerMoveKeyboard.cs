using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour {

	private Animator anim;

	// objects to drag in
	public FreeMovementMotor motor;
	public Transform playerTransfrom;

	private Quaternion screenMovementSpace;
	private Vector3 screenMovementForward;
	private Vector3 screenMovementRight;

	private string AXIS_X = "Horizontal";
	private string AXIS_Y = "Vertical";

	private string ANIMATION_RUN = "Run";

	void Awake() {
		anim = GetComponent<Animator> ();
		motor.movementDirection = Vector2.zero;
	}

	void Start() {
		screenMovementSpace = Quaternion.Euler (0, Camera.main.transform.eulerAngles.y, 0);
		screenMovementForward = screenMovementSpace * Vector3.forward;
		screenMovementRight = screenMovementSpace * Vector3.right;
	}

	void Update() {

		motor.movementDirection = Input.GetAxis (AXIS_X) * screenMovementRight + 
			Input.GetAxis (AXIS_Y) * screenMovementForward;

		if (Input.GetAxis (AXIS_X) != 0 || Input.GetAxis (AXIS_Y) != 0) {
			anim.SetBool (ANIMATION_RUN, true);
		} else {
			anim.SetBool (ANIMATION_RUN, false);
		}
		
		// Make sure the direction vector doesn't exceed a length of 1
		// so the character can't move faster diagonally than horizontally or vertically
		if (motor.movementDirection.sqrMagnitude > 1)
			motor.movementDirection.Normalize ();

	}


} // class






















