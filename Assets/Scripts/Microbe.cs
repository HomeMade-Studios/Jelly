using UnityEngine;
using System.Collections;

public class Microbe : MonoBehaviour {

	void Eated(GameObject eater) {
		transform.position = Vector2.MoveTowards (transform.position, eater.transform.position, 1f);
		eater.GetComponent<Cell> ().Mass += 1;
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "EatCollider") {
			Eated (other.gameObject.transform.parent.gameObject);
		}
	}

}
