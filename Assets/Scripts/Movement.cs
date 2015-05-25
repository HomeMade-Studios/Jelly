using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public CNAbstractController movementController;
	public float speed = 100;
	float translationX = 0, translationY = 0;

	void Start () {

	}
	
	void FixedUpdate() {

		//FOR MOUSE AND FINGER POSITION
		if (Input.touchSupported) {
			if (Input.touchCount > 0)
				transform.position = Vector2.MoveTowards (transform.position, Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), speed * Time.deltaTime);
		} 
		else {
			//transform.position = Vector2.MoveTowards (transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition), speed * Time.deltaTime);
		}

		 
		//FOR JOYSTICK
		translationX = movementController.GetAxis("Horizontal") * speed * Time.deltaTime;
		translationY = movementController.GetAxis("Vertical") * speed * Time.deltaTime;

		transform.Translate (translationX, translationY, 0);

		/*
		//FOR ACCELEROMETER
		translationX = Input.acceleration.x * speed * Time.deltaTime;
		translationY = Input.acceleration.y * speed * Time.deltaTime;

		transform.Translate (translationX, translationY, 0);
		*/




	}
}
