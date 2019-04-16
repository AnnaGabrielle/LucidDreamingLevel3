using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AG_BackMenu : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		BacktoMenu();
	}

	void BacktoMenu(){
		if(Input.GetKeyDown(KeyCode.Escape)){
		SceneManager.LoadScene(0);
		}
	}
}

