using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bollon : MonoBehaviour {

    public int num = 200;
    private Image balloon;
	// Use this for initialization
	void Start () {
        balloon = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        num--;
        if (num == 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            balloon.color = new Color(balloon.color.r, balloon.color.g, balloon.color.b, num/100.0f);
        }
	}
}
