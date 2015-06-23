using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	public float mass;  	//EQUAL TO RADIUS
	public float speed;
	private float scale;	//TRANSFORM.SCALE PARAMETER
	private float radius;	//RADIUS OF THE CIRCLE
	private bool eated = false;
	private bool justSplitted;

	void Update(){
		Scale();
		if(Input.GetKeyDown("space")){
			Split();
		}

		//		FOR MOUSE AND FINGER POSITION
		if (Input.touchSupported) {
			if (Input.touchCount > 0)
				transform.position = Vector2.MoveTowards (transform.position, Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), speed * Time.deltaTime);
		}
		else {
			//transform.position = Vector2.MoveTowards (transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition), speed * Time.deltaTime);
			GetComponent<Rigidbody2D>().velocity = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * speed;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if ((other.gameObject.GetComponent<Cell>().Mass >= mass + mass/100*10) && !eated) {
			CheckEated (other.gameObject);
		}
	}

	void CheckEated(GameObject eater) {

		float intersectionArea = 0;
		float area = radius*radius;

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

	public void ScaleImmediate(){
		radius = Mathf.Sqrt(mass/Mathf.PI);
		scale = (radius * 1.11f)/2;
		Vector3 newScale = new Vector3 (scale, scale, 1);
		transform.localScale = newScale;
	}

	public void Split(){
		Mass /= 2;
		GameObject splittedCell = Instantiate(Resources.Load ("Prefabs/Player Cell", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
		splittedCell.transform.SetParent(GameObject.Find("Player Cells Container").transform);
		splittedCell.GetComponent<Cell>().Mass = Mass;
		splittedCell.GetComponent<Cell>().ScaleImmediate();
		splittedCell.GetComponent<Rigidbody2D>().AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * 100 , ForceMode2D.Impulse);	//NEED SPLIT FORCE FORMULA
	}
	
	void Destroy(){
		Destroy (this.gameObject);
	}

	public float Mass { get { return mass; } set { mass = value; } }

	public float Radius { get {return radius; } }
}
