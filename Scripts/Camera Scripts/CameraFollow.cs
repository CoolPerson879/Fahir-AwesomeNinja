using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Transform myTransform;
	private Transform target;
	public Vector3 offset = new Vector3(3, 7.5f, -3);

	void Awake() {
		target = GameObject.Find ("Ninja").transform;
	}

	void Start () {
		myTransform = this.transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target != null) {
			myTransform.position = target.position + offset;
			myTransform.LookAt (target.position, Vector3.up);
		}
	}

} // class







































