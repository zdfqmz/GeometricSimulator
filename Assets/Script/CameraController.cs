using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {



	public bool EditMode = true;
	public bool is_Operating = false;

	float camPostion_x;
	float camPostion_y;
	float camPostion_z;


	public GameObject Panel_Button;
	public Text text_ModeInformation;

	// Use this for initialization
	void Start () {
		camPostion_x = this.transform.localPosition.x;
		camPostion_y = this.transform.localPosition.y;
		camPostion_z = this.transform.localPosition.z;

		text_ModeInformation.text = "当前状态 : 编辑";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (EditMode) {
				Time.timeScale = 0;
				EditMode = false;

				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;

				text_ModeInformation.text = "当前状态 : 锁定";
				Panel_Button.SetActive (false);
			} else {
				Time.timeScale = 1;
				EditMode = true;

				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;

				text_ModeInformation.text = "当前状态 : 编辑";
				Panel_Button.SetActive (true);
			}
		}

		if (!EditMode) {
			return;
		}

		MoveCamera ();
		if (is_Operating)
			return;
		RotateCamera ();

	}

	void MoveCamera(){
		camPostion_z += Input.GetAxis ("Mouse ScrollWheel") * 50.0f* Time.deltaTime;
		this.transform.localPosition = new Vector3 (camPostion_x, camPostion_y, camPostion_z);

		if (Input.GetMouseButton (2)) {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;

			camPostion_x -= Input.GetAxis ("Mouse X") * 0.04f;
			camPostion_y -= Input.GetAxis ("Mouse Y") * 0.04f;
				
			this.transform.localPosition = new Vector3 (camPostion_x, camPostion_y, camPostion_z);

			is_Operating = true;
		} else {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

			is_Operating = false;
		}
	}

	void RotateCamera(){
		if (Input.GetMouseButton (1)) {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;

			Vector3 this_Eular = this.transform.eulerAngles;

			this_Eular.x -= Input.GetAxis ("Mouse Y");
			this_Eular.y += Input.GetAxis ("Mouse X");

			this.transform.eulerAngles = this_Eular;

			return;
		} else {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}

