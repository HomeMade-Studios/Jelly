using UnityEngine;
using System.Collections;

public class Microbe : MonoBehaviour {

	public int mass = 1;

	void Eated(GameObject eater) {
		transform.position = Vector2.Lerp (transform.position, eater.transform.position, 1f);
		eater.GetComponent<Controller> ().Mass += mass;
		Invoke ("Destroy", 0.10f);
		
	}
	
	void Destroy(){
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "EatCollider") {
			Eated (other.gameObject.transform.parent.gameObject);
		}
	}

}
