using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	public float mass;
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
			Vector3 newScale = new Vector3 (size, size, 1);
			transform.localScale = Vector3.Lerp(transform.localScale, newScale, Time.deltaTime);

		}
		print (mass/10);
	}
	
	void Destroy(){
		Destroy (this.gameObject);
	}

	public float Mass { get { return mass; } set { mass = value; } }
}
