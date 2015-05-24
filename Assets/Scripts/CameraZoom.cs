using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	bool isOrthographic = true;
	GameObject[] targets;
	float currentDistance, largestDistance;
	Camera theCamera;
	float height = 5;
	Vector3 avgDistance;
	//float distance = 0;
	float speed = 1, offset;


	void Awake () {
		targets = GameObject.FindGameObjectsWithTag("PlayerSpheres"); 
		theCamera = Camera.main;
		//if(theCamera) isOrthographic = theCamera.orthographic;
	}
	

	void LateUpdate () {
		targets = GameObject.FindGameObjectsWithTag ("PlayerSpheres"); 
		
		if (!GameObject.FindWithTag ("PlayerSpheres"))

			return;
		
		Vector3 sum = new Vector3 (0, 0, 0);
		
		for (int n = 0; n < targets.Length; n++) {
			
			sum += targets [n].transform.position;
			
		}
		
		Vector3 avgDistance = sum / targets.Length;

		float largestDifference = returnLargestDifference ();
	
		height = Mathf.Lerp (height, largestDifference, Time.deltaTime * speed);
	
		if (isOrthographic) { 
			theCamera.orthographicSize = (largestDifference/2.5f) >= 5 ? largestDifference/2.5f : 5;
			theCamera.transform.position = new Vector3(avgDistance.x, avgDistance.y, theCamera.transform.position.z);
		
		} else {
		
			//theCamera.transform.position.x = avgDistance.x;
		
			//theCamera.transform.position.z = avgDistance.z - distance + largestDifference;
		
			//theCamera.transform.position.y = height;
		
			//theCamera.transform.LookAt (avgDistance);
		
		}

	}

	float returnLargestDifference(){

		currentDistance = 0.0f;
		largestDistance = 0.0f;
		
		for(int i = 0; i < targets.Length; i++){
			
			for(int j = 0; j <  targets.Length; j++){
				
				currentDistance = Vector3.Distance(targets[i].transform.position,targets[j].transform.position);
				
				if(currentDistance > largestDistance){
					
					largestDistance = currentDistance;
					
				}
			}
		}
		return largestDistance;
	}

}
