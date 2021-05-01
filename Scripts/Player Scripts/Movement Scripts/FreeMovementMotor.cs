using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovementMotor : MonoBehaviour {

	[HideInInspector]
	public Vector3 movementDirection;

	private Rigidbody myBody;

	public float walkingSpeed = 5f;
	public float walkingSnapyness = 50f;
	public float turningSmoothing = 0.3f;

	void Awake() {
		myBody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		// Handle the movement of the character
		Vector3 targetVelocity = movementDirection * walkingSpeed;
		Vector3 deltaVelocity = targetVelocity - myBody.velocity;

		if (myBody.useGravity) {
			deltaVelocity.y = 0;
		}

		myBody.AddForce (deltaVelocity * walkingSnapyness, ForceMode.Acceleration);

		Vector3 faceDir = movementDirection;

		// Make the character rotate towards the target rotation
		if (faceDir == Vector3.zero) {
			myBody.angularVelocity = Vector3.zero;
		} else {
			float rotationAngle = AngleAroundAxis (transform.forward, faceDir, Vector3.up);
			myBody.angularVelocity = (Vector3.up * rotationAngle * turningSmoothing);
		}

	}

	// The angle between dirA and dirB around axis
	static float AngleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis) {
		// Project A and B onto the plane orthogonal target axis
		dirA = dirA - Vector3.Project(dirA, axis);
		dirB = dirB - Vector3.Project (dirB, axis);

		// Find (positive) angle between A and B
		float angle = Vector3.Angle(dirA, dirB);

		// Return angle multiplied with 1 or -1
		return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0 ? -1 : 1);
	} 

} // class









































