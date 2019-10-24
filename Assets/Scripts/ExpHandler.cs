using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExpHandler : MonoBehaviour
{
    public float t = 10.0f;
    private float x;
    private float y;
    private Text txt;
    public void SetValue(int num)
    {
       txt=this.gameObject.GetComponent<Text>();
       txt.text = "+Exp " + num;
        
    }
    // Use this for initialization
    void Start()
    {
        txt = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        x = this.gameObject.transform.position.x;
        y = this.gameObject.transform.position.y;
        this.gameObject.transform.position = new Vector3(x, y + Time.deltaTime * 100.0f, 0);

        t -= Time.deltaTime;

        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, t);

        if (t < 0)
        {
            GameObject.Destroy(this.gameObject);
        }

    }
}
