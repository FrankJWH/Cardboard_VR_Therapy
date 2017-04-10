using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.UI;


public class TiltUI : MonoBehaviour {

	Canvas canvasUI;

	public Button uiButton;
	Button btn;

	// Use this for initialization
	void Start () {
		VRSettings.enabled = !VRSettings.enabled;
		canvasUI = GameObject.FindWithTag ("TiltCanvas").GetComponent<Canvas> ();

		btn = uiButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}// Start()

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && VRSettings.enabled)
		{
			displayUI ();
		}

	}// Update()

	// UI button listener
	void TaskOnClick() {
		Debug.Log ("You clicked the UI button!");
		canvasUI.enabled = false;
		VRSettings.enabled = true;
		Debug.Log ("ending the call");
	}// TaskOnClick()

	void displayUI() {
		VRSettings.enabled = false; //disable VR for options
		canvasUI.enabled = true;
	}// displayUI()

	// remove listener when UI is disabled to resume Update()
	void Destroy() {
		btn.onClick.RemoveListener (TaskOnClick); 
	}

	//add listener again to reenable previous functionality
	void Create() {
		btn.onClick.AddListener (TaskOnClick);
	}
}
