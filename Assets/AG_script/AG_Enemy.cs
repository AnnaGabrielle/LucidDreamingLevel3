using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AG_Enemy : MonoBehaviour {
	[SerializeField] GameObject ag_deathFX;
	[SerializeField] Transform ag_parent;
	
	// Use this for initialization
	void OnParticleCollision(GameObject other){
		GameObject ag_fx = Instantiate(ag_deathFX, transform.position, Quaternion.identity);
		ag_fx.transform.parent = ag_parent;
		Destroy(gameObject);
	}
}
