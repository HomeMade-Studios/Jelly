using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	public float mass;  	//EQUAL TO RADIUS
	private float scale;	//TRANSFORM.SCALE PARAMETER
	private float radius;	//RADIUS OF THE CIRCLE
	private bool eated = false;  //IS ALREADY BE EATED

	void Update(){
		Scale();
	}

	void OnTriggerStay2D(Collider2D other){
		if ((other.gameObject.GetComponent<Cell>().Mass >= mass + mass/100*10) && !eated) {
			CheckEated (other.gameObject);
		}
	}

	void CheckEated(GameObject eater) {

		float area = radius*radius;
		print (area + "\t" + intersectionArea + "\t" + r1 + "\t" + r2 + "\t" + d);
		if(intersectionArea >= area/100*99){
		
			transform.position = Vector2.MoveTowards (transform.position, eater.transform.position, 10f);
			eater.GetComponent<Cell> ().Mass += mass;
			eated = true;
			Invoke ("Destroy", 0.25f);
		}
	}

	void Scale(){
		radius = Mathf.Sqrt(mass/Mathf.PI);
		scale = (radius * 1.11f)/2;
		Vector3 newScale = new Vector3 (scale, scale, 1);
		transform.localScale = Vector3.Lerp(transform.localScale, newScale, 2.5f*Time.deltaTime);
	}
	
	void Destroy(){
		Destroy (this.gameObject);
	}

	public float Mass { get { return mass; } set { mass = value; } }

	public float Radius { get {return radius; } }
}
