using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	public int mass;
	public Collider2D[] eatedColliders;
	private float size;
	bool eated = false;

	void Awake(){
		eatedColliders = gameObject.transform.FindChild ("EatedColliders").GetComponents<Collider2D> ();
	}

	void Update(){
		Scale();
	}

	void OnTriggerStay2D(Collider2D other){
		if ((other.gameObject.tag == "EatCollider") && !eated) {
			CheckEated (other.gameObject.transform.parent.gameObject);
		}
	}

	void CheckEated(GameObject eater) {
		
		Collider2D otherEatCollider = eater.gameObject.GetComponent<Collider2D>();
		
		foreach(Collider2D eatedCollider in eatedColliders){
			if (!eatedCollider.bounds.Intersects(otherEatCollider.bounds))
				return;
		}
		
		transform.position = Vector2.MoveTowards (transform.position, eater.transform.position, 1f);
		eater.GetComponent<Cell> ().Mass += mass;
		eated = true;
		Invoke ("Destroy", 0.25f);
		
	}

	void Scale(){
		if(size != mass/10){
			size = mass/10;
			iTween.ScaleTo (this.gameObject, new Vector3 (size, size, 1), 0.5f);
		}
	}
	
	void Destroy(){
		Destroy (this.gameObject);
	}

	public int Mass { get { return mass; } set { mass = value; } }
}
