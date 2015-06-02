using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed = 100;

	void FixedUpdate() {

		//FOR MOUSE AND FINGER POSITION
		if (Input.touchSupported) {
			if (Input.touchCount > 0)
				transform.position = Vector2.MoveTowards (transform.position, Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), speed * Time.deltaTime);
		}
		else {
			transform.position = Vector2.MoveTowards (transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition), speed * Time.deltaTime);
		}
	}
}
