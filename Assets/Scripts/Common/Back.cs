﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Back : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EventTriggerListener.Get(this.gameObject).onClick += goMain;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goMain(GameObject obj)
    {
		SceneManager.LoadScene(0);
	}
}
