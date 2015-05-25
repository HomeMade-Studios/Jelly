using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public int mass;
	public Collider2D[] eatedColliders;
	bool eated = false;

	void Awake(){
		mass = 10;
		eatedColliders = gameObject.transform.FindChild ("EatedColliders").GetComponents<Collider2D> ();
	}

	void Eated(GameObject eater) {
		transform.position = Vector2.Lerp (transform.position, eater.transform.position, 1f);
		eater.GetComponent<Controller> ().Mass += mass;
		eated = true;
		Invoke ("Destroy", 0.10f);

	}

	void Destroy(){
		Destroy (this.gameObject);
	}

	void OnTriggerStay2D(Collider2D other){
		if ((other.gameObject.tag == "EatCollider") && (!other.transform.IsChildOf (this.gameObject.transform)) && !eated) {

			foreach(Collider2D eatedCollider in eatedColliders){

				if (!eatedCollider.bounds.Intersects(other.gameObject.GetComponent<Collider2D>().bounds))
					return;

			}

			Eated (other.gameObject.transform.parent.gameObject);
		}
	}

	public int Mass { get { return mass; } set { mass = value; } }
}
