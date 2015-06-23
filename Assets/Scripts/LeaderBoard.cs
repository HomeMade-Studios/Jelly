using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeaderBoard : MonoBehaviour {

	public Text[] playerNames;

	void update(){
		updateLeaderPlayer();
	}

	void updateLeaderPlayer(){

		for (int i = 0; i < playerNames.Length; i++){
			//playerNames[i].text = ................
		}
	}
}
