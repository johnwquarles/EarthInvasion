﻿using UnityEngine;
using System.Collections;

public class MenuObjectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1")) {
			Application.LoadLevel("main");
		}
	}
}
