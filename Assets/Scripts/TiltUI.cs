using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.UI;

public class TiltUI : MonoBehaviour {
	
	Button btn;
	Canvas canvasUI;

	public GameObject vrViewer;
	public Button uiButton;

	// Use this for initialization
	void Start () {
		VRSettings.enabled = false;
		canvasUI = GameObject.FindWithTag ("TiltCanvas").GetComponent<Canvas> ();
		//canvasUI.enabled = false; //TODO comment this when toggle test is done
		btn = uiButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}// Start()

	// Update is called once per frame
	void Update () {

		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began && VRSettings.enabled == true) {
				displayUI ();
			}
			//StartCoroutine (TogglePause ());
		}

		if(Input.GetMouseButtonDown (0)) {
			displayUI ();
		}

		// tester for VR toggle without UI, works without problem
		//disable canvasUI first and comment out above foreach
//		foreach (Touch touch in Input.touches) {
//			if (touch.phase == TouchPhase.Began) {
//				displayUI ();
//			}
//			StartCoroutine (TogglePause ());
//		}

	}// Update()

	// UI button listener
	void TaskOnClick() {
		//canvasUI.enabled = false;
		VRSettings.enabled = true;
	}// TaskOnClick()

	// displays the tilt UI menu when screen is in VR mode and user touches screen
	// deactivates VR and enables Canvas in order to display menu
	void displayUI() {
		VRSettings.enabled = false; //disable VR for options
		canvasUI.enabled = true;
	}// displayUI()


	IEnumerator TogglePause() {
		yield return new WaitForSeconds(2);
	}
		
}
