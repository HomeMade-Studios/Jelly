using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public CNAbstractController movementController;
	public float speed = 100;

	void Start () {

	}
	
	void FixedUpdate() {
		float translationY = movementController.GetAxis("Vertical") * speed * Time.deltaTime;
		float translationX = movementController.GetAxis("Horizontal") * speed * Time.deltaTime;
		transform.Translate (translationX, translationY, 0);

	}
}
