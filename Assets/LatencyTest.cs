using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LatencyTest : MonoBehaviour {

    public GameObject sampleButton;
    public GameObject enterButton;
    public Image imageView;
    private bool backgroud = true;
    private float m_LastUpdateShowTime = 0f;  //上一次更新帧率的时间;  

    private float m_UpdateShowDeltaTime = 0.01f;//更新帧率的时间间隔;  

    private int m_FrameUpdate = 0;//帧数;  

    private int clickTime = 0;

    private float m_FPS = 0;
    

	// Use this for initialization
	void Start () {
        Debug.LogWarning("*****************************************");
        EventTriggerListener.Get(sampleButton).onClick += TestLatency;
        EventTriggerListener.Get(enterButton).onDown += TestLatency;
	}
	
	// Update is called once per frame
	void Update () {
        m_FrameUpdate++;
        if (Time.realtimeSinceStartup - m_LastUpdateShowTime >= m_UpdateShowDeltaTime)
        {
            m_FPS = m_FrameUpdate / (Time.realtimeSinceStartup - m_LastUpdateShowTime);
            m_FrameUpdate = 0;
            m_LastUpdateShowTime = Time.realtimeSinceStartup;
        }

	}

    void TestLatency(GameObject obj)
    {
        Debug.LogWarning("*****************************************");
        Sprite img = null;

        clickTime++;
        if (backgroud)
        {
            img = Resources.Load<Sprite>("texture/LevelBg/map_1_1");
            backgroud = false;
        }
        else
        {
            img = Resources.Load<Sprite>("texture/bg");
            backgroud = true;
        }

        imageView.overrideSprite = img;

        imageView.color = new Color(255, 255, 255, 255);
    }

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle(GUI.skin.GetStyle("label"));
        myStyle.fontSize = 32;
        myStyle.normal.textColor = Color.black;
        GUI.Label(new Rect(Screen.width / 2, 0, 400, 100), "FPS: " + (int)m_FPS+"   times:"+clickTime, myStyle);
    } 
}
