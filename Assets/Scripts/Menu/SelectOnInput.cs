using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

	public EventSystem esys;
	public GameObject selected;
	private bool button_selected;

	// Use this for initialization
	void Start () {
		button_selected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Vertical") != 0 && button_selected == false) 
		{
			esys.SetSelectedGameObject (selected);
			button_selected = true;
		}
	}

	private void OnDisable() {
		button_selected = false;
	}
}
