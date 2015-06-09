using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public Transform playerSpheres;
	public float followSpeed = 1;
	Vector3 playerSpheresMiddle;
	Camera theCamera;
	
	void Start () {
		theCamera = Camera.main;
	}


	void FixedUpdate () {
		playerSpheresMiddle = Vector3.zero;
		foreach (Transform child in playerSpheres) {
			playerSpheresMiddle += child.position;
		}
		playerSpheresMiddle /= playerSpheres.childCount;
		theCamera.transform.position = new Vector3(playerSpheresMiddle.x, playerSpheresMiddle.y, transform.position.z);
	}
}
