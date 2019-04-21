using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AG_GameLevel : MonoBehaviour {

	[SerializeField] int ag_Enemies;
	[SerializeField] float ag_loadWinDelay =1f;
    [SerializeField] string ag_Level4;
	[SerializeField] Text ag_enemy_number;
	//Tags name
	public string ag_EnemiesTAG;

	void Update(){
		ag_enemy_number.text = ag_Enemies.ToString();
	}
	public void AG_CountEnemies(){
		ag_Enemies++;
	}

	public void AG_BreakEnemies(){
		ag_Enemies--;
		AG_WinConditional();
	}
	public void AG_WinConditional(){
		if(ag_Enemies <=0){
			Invoke("AG_NextScene", ag_loadWinDelay);
		}
	}

	private void AG_NextScene(){
		SceneManager.LoadScene(ag_Level4);
	}

}
