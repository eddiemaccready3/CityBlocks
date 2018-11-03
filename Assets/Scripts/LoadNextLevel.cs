using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLevel : MonoBehaviour {

	private ScoreBoard scoreBoard;
    
    // Use this for initialization
	void Start () {
		scoreBoard = FindObjectOfType<ScoreBoard>();
	}
	
	// Update is called once per frame
	//void Update () {
	//	if(ScoreBoard.score == 3000)
 //       {

 //       }
	//}
}
