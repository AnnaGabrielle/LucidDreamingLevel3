using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AG_SelfDestruct : MonoBehaviour {

	[SerializeField] float ag_secondsDelay = 3f; 
	// Use this for initialization
	void Start () {
		Destroy(gameObject, ag_secondsDelay);		
	}

}
