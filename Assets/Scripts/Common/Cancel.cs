using UnityEngine;
using System.Collections;

public class Cancel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EventTriggerListener.Get(this.gameObject).onClick += Close;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void Close(GameObject obj)
    {
        GameObject.Destroy(this.gameObject.transform.parent.gameObject);
    }
}
