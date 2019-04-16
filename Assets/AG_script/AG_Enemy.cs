using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AG_Enemy : MonoBehaviour {
	[SerializeField] GameObject ag_deathFX;
	[SerializeField] Transform ag_parent;
	[SerializeField] int ag_scorePerHit = 10;
	//AG_ScoreBoard ag_ScoreBoard;
	AG_GameLevel aG_GameLevel;

	[SerializeField] int ag_maxHit = 2;

	void Start(){
		//ag_ScoreBoard = FindObjectOfType<AG_ScoreBoard>();
		aG_GameLevel =  GameObject.FindGameObjectWithTag("AG_Level").GetComponent<AG_GameLevel>();
		AG_CountingAllEnemies();
	}
	
	private void AG_CountingAllEnemies(){
		aG_GameLevel.AG_CountEnemies();
	}

	// Use this for initialization
	void OnParticleCollision(GameObject other){
		AG_ProcessHit();
		if(ag_maxHit<=1){
			//ag_ScoreBoard.ScoreHit(ag_scorePerHit);
			aG_GameLevel.AG_BreakEnemies();
			AG_KillEnemy();
		}
	}

	void AG_ProcessHit(){
		ag_maxHit= ag_maxHit - 1;
	}

	void AG_KillEnemy(){
		GameObject ag_fx = Instantiate(ag_deathFX, transform.position, Quaternion.identity);
		ag_fx.transform.parent = ag_parent;
		Destroy(gameObject);
	}
		
	
}
