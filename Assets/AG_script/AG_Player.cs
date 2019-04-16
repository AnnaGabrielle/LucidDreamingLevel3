using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AG_Player : MonoBehaviour {

	[Header("General")]
	[Tooltip("In ms^-1")][SerializeField] float ag_xSpeed = 3f;
	[SerializeField] float ag_xRangeMax = 1.1f;
	[SerializeField] float ag_xRangeMin= -1.1f;

	[SerializeField] float ag_positionPitchFactor = -5f;
	[SerializeField] float ag_controlPitchFactor = -20f;
	[SerializeField] float ag_controlRollFactor = -10f;
	[SerializeField] float ag_positionYawFactor = 10f;
	[SerializeField] float ag_yRangeMax = 0.51f;
	[SerializeField] float ag_yRangeMin= -0.41f;

	[SerializeField] GameObject ag_bullets;
	[SerializeField] AudioClip ag_bulletSound;
	AudioSource ag_bulletSoundComponent ;

	bool ag_ControlEnabled = true;

	float ag_xThrow, ag_yThrow;

	string ag_Xside = "Horizontal";
	string ag_Yside="Vertical";
	// Use this for initialization
	// Update is called once per frame

	void Start(){
		ag_bulletSoundComponent = ag_bullets.GetComponent<AudioSource>();
	}
	void Update () {
		if(ag_ControlEnabled){
			Ag_Shoot();
			Ag_Movement();
			Ag_Rotation();
		}
	
	}

	private void Ag_Shoot(){
		if(CrossPlatformInputManager.GetButton("Fire")){
			Ag_setActiveBullet(true);
		}
		else{
			Ag_setActiveBullet(false);
		}

	}

	void Ag_setActiveBullet(bool isActive){
		var emmissionModule = ag_bullets.GetComponent<ParticleSystem>().emission;
		emmissionModule.enabled = isActive;
	}

	
	private void Ag_Movement(){
		ag_xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		ag_yThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float ag_xOffset = ag_xThrow * ag_xSpeed * Time.deltaTime;
		float ag_yOffset = ag_yThrow * ag_xSpeed * Time.deltaTime;

		float ag_rawNewXPos = transform.localPosition.x + ag_xOffset;
		float ag_rawNewYPos = transform.localPosition.y + ag_yOffset;

		float ag_clampedXPos = Mathf.Clamp(ag_rawNewXPos, ag_xRangeMin, ag_xRangeMax);
		float ag_clampedYPos = Mathf.Clamp(ag_rawNewYPos, ag_yRangeMin, ag_yRangeMax);
		transform.localPosition = new Vector3(ag_clampedXPos, ag_clampedYPos, transform.localPosition.z);
	}
	private void Ag_Rotation(){
		float ag_pitch = -90 + transform.localPosition.y * ag_positionPitchFactor + ag_yThrow* ag_controlPitchFactor;
		float ag_roll = ag_xThrow * ag_controlRollFactor;
		float ag_yaw = transform.localPosition.x * ag_positionYawFactor;
		transform.localRotation = Quaternion.Euler(ag_pitch, ag_yaw, ag_roll);

	}

	void Ag_OnPlayerDeath(){
		print("Control stop");
		ag_ControlEnabled = false;
	}


}
