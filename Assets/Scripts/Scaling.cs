using UnityEngine;
using System.Collections;

public class Scaling : MonoBehaviour {

	Cell cellController;
	float size;

	void Awake (){
		cellController = gameObject.GetComponent<Cell> ();
		UpdateSize ();
	}

	void Update () {
		UpdateSize ();
		iTween.ScaleUpdate (this.gameObject, new Vector3 (size, size, 1), 1);
	}

	void UpdateSize(){
		size = cellController.Mass/10;
	}

}
