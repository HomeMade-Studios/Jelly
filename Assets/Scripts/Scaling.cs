using UnityEngine;
using System.Collections;

public class Scaling : MonoBehaviour {

	public float size = 10;

	void Awake (){

	}

	void Start () {

	}

	void Update () {
		iTween.ScaleUpdate (this.gameObject, new Vector3 (size, size, 1), 1);
	}
}
