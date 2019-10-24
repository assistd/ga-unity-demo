using UnityEngine;
using System.Collections;

public class FindElementsControl : MonoBehaviour {

    public GameObject button;
    public GameObject image;

    public Transform blackBollon;
	// Use this for initialization
	void Start () {
        EventTriggerListener.Get(button).onClick += HandleButton;
        EventTriggerListener.Get(image).onClick += HandleImage;
	}

    void HandleButton(GameObject obj)
    {
        Vector3 pos = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Transform bollonObj = Instantiate(blackBollon, pos, Quaternion.identity) as Transform;

        bollonObj.parent = this.gameObject.transform.parent;
    }

    void HandleImage(GameObject obj)
    {
        AudioSource audio = obj.GetComponent<AudioSource>();
        audio.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
