using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetting : MonoBehaviour {

	public Slider slider_LightIntensity;
	public Slider slider_LightEular_X;
	public Slider slider_LightEular_Y;

	public GameObject mainLight;

	Light light;


	// Use this for initialization
	void Start () {
		light = mainLight.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeLightIntensity(){
		light.intensity = slider_LightIntensity.value;
	}

	public void ChangeLightEular(){
		Vector3 new_Eular = mainLight.transform.eulerAngles;

		new_Eular.x = slider_LightEular_X.value;
		new_Eular.y = slider_LightEular_Y.value;

		mainLight.transform.eulerAngles = new_Eular;
	}
}
