using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(Screen.currentResolution);
        Debug.Log("++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        Debug.Log(SystemInfo.deviceModel);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount != 0)
        {

            Debug.Log(Input.touches);
        }
	}
}
