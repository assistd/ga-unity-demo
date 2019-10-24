using UnityEngine;
using System.Collections;

public class InteractionControl : MonoBehaviour {
    public GameObject closeButton;

    public GameObject clickButton;

    public Transform dialogPrefab;
    public Transform orangePrefab;
	// Use this for initialization
	void Start () {
        EventTriggerListener.Get(closeButton).onClick += HandleClose;
        EventTriggerListener.Get(clickButton).onClick += HandleClick;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void HandleClose(GameObject obj)
    {
        Vector3 pos = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Transform dialog = Instantiate(dialogPrefab, pos, Quaternion.identity) as Transform;
        

        dialog.parent = this.gameObject.transform.parent;
        dialog.localScale = new Vector3(1, 1, 1); 
    }

    void HandleClick(GameObject obj)
    {
        Vector3 pos = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Transform bollonObj = Instantiate(orangePrefab, pos, Quaternion.identity) as Transform;

        bollonObj.parent = this.gameObject.transform.parent;
    }
}
