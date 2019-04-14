using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AG_CollisionHandler : MonoBehaviour {

	[SerializeField] float ag_loadLevelDelay = 1f;
	[SerializeField] GameObject ag_ExplosionFX;
	[SerializeField] GameObject ag_PillModel;
	void Start(){
		ag_ExplosionFX.SetActive(false);
		ag_PillModel.SetActive(true);
	}
	void OnTriggerEnter(Collider otger){
		StartDeathSequence();
		ag_ExplosionFX.SetActive(true);
		ag_PillModel.SetActive(false);
		Invoke("AG_ReloadLevel", ag_loadLevelDelay);
	}
	private void StartDeathSequence(){
		SendMessage("Ag_OnPlayerDeath");
	}
	private void AG_ReloadLevel(){
		SceneManager.LoadScene("Level3");
	}
}
