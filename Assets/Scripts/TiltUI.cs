using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;


public class TiltUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		VRSettings.enabled = !VRSettings.enabled;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			VRSettings.enabled = !VRSettings.enabled;
		}
	}
}
