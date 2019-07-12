using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour {


	public bool is_Selected;

	public Camera mainCamera;
	public GameObject selectedGameObject;
	public Text Text_selectionInfomation;

	void Start () {
		selectedGameObject = null;
		is_Selected = false;

		Text_selectionInfomation.text = "选中物体 : 否";
	}

	// Update is called once per frame
	void Update () {
		if (is_Selected == true) {
			OperateItem ();
		}

		if (Input.GetMouseButtonDown (0)) {
			if (CheckGameObject ()) {

				Text_selectionInfomation.text = "选中物体 : 是";
				is_Selected = true;
				ScriptControl (false);
			} else {

				Text_selectionInfomation.text = "选中物体 : 否";
				is_Selected = false;
				ScriptControl (true);
			}
		}
	}


	bool CheckGameObject ()
	{
		Ray ray = mainCamera.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit;
		if (Physics.Raycast (ray, out hit) && hit.collider.tag == "Item") {
			selectedGameObject = hit.collider.gameObject;
			return true;
		} else
			selectedGameObject = null;
			return false;
	}

	void ScriptControl(bool opr){
		if (opr == true) {
			this.GetComponent<CameraController> ().enabled = true;
		} else
			this.GetComponent<CameraController> ().enabled = false;
	}

	void OperateItem(){
		if (Input.GetMouseButton (0)) {
			Vector3 temp = selectedGameObject.transform.localPosition;

			temp.x += Input.GetAxis ("Mouse X") * 0.2f;
			temp.z += Input.GetAxis ("Mouse Y") * 0.2f;

			selectedGameObject.transform.localPosition = temp;
		}
	}
}
