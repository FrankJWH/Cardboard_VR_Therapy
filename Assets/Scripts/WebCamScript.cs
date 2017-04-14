using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamScript : MonoBehaviour {

	static float viewTilt;
	public Text userInput;
	Vector3 zAxis;

	// Use this for initialization
	void Start () {
		WebCamTexture webcamTexture = new WebCamTexture();
		Renderer renderer = GetComponent<Renderer>();
		renderer.material.mainTexture = webcamTexture;
		webcamTexture.Play();
	}

	// Update is called once per frame
	void Update () {
		float.TryParse (userInput.text, out viewTilt);
		if (viewTilt is float) {
			zAxis = new Vector3 (0, 0, viewTilt);
			transform.eulerAngles = Camera.main.transform.eulerAngles + zAxis;
		}
	}
		
	static float getViewTilt() { return viewTilt; }
		
}
