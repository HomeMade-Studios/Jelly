using UnityEngine;
using System.Collections;

public class Scaling : MonoBehaviour {

	public float size;

	void Awake (){
		size = 10;
	}

	void Start () {

	}

	void Update () {
		iTween.ScaleUpdate (this.gameObject, new Vector3 (size, size, 1), 5);
	}
}
