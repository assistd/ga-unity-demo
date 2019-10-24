using UnityEngine;
using System.Collections;

public class PressControl : MonoBehaviour {

    public GameObject pressButton;
    public Transform expPrefab;

    private bool up = false;


    private int num = 1;
	// Use this for initialization
	void Start () {
        EventTriggerListener.Get(pressButton).onDown += HandleDown;
        EventTriggerListener.Get(pressButton).onUp += HandleUp;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void HandleDown(GameObject obj)
    {
        Debug.Log("down");
        up = false;
        StartCoroutine(Create());
    }

    void HandleUp(GameObject obj)
    {
        up = true;
    }

    private IEnumerator Create()
    {
        float lastTime = -0.1f;
        while (true)
        {
            if (up)
            {
                num = 0;
                break;
            }
            if(lastTime<0)
            {
                num++;
                Vector3 pos=new Vector3(Screen.width / 2, Screen.height / 2, 0);
                Transform expTran = Instantiate(expPrefab, pos, Quaternion.identity) as Transform;

                
                ExpHandler exp = expTran.GetComponent<ExpHandler>();
                exp.SetValue(num);

                expTran.parent = this.gameObject.transform.parent;
                expTran.localScale = new Vector3(1, 1, 1);
                lastTime = 0.5f;
            }

            lastTime -= Time.deltaTime;
            yield return null;
        }
    }

}
