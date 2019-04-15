using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AG_ScoreBoard : MonoBehaviour {

	int ag_score =0;
	Text ag_textScore;
	//[SerializeField] int ag_scorePerHit = 10;


	// Use this for initialization
	void Start () {
		ag_textScore = GetComponent<Text>();
		ag_textScore.text = ag_score.ToString();
	}
	
	// Update is called once per frame
	public void ScoreHit(int scoreEnemy){
		ag_score = ag_score + scoreEnemy;
		ag_textScore.text = ag_score.ToString();
	}
}
