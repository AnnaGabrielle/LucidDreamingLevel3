using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ag_MusicPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("AG_LoadScene3", 3.45f);
	}
	
	// Update is called once per frame
	void AG_LoadScene3 () {
		SceneManager.LoadScene("Level3");
	}
}
