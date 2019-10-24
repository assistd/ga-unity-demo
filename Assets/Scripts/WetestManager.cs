using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Reflection;
using WeTest.U3DAutomation;

[Serializable]
public class WorldScreen
{
    public string name;
    public double x;
    public double y;
    public double z;

    public WorldScreen()
    {
    }

    public WorldScreen(string name, double x, double y, double z)
    {
        this.name = name;
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

public class WetestManager : MonoBehaviour {
    private float m_LastUpdateShowTime = 0f;  //上一次更新帧率的时间;  

    private float m_UpdateShowDeltaTime = 0.01f;//更新帧率的时间间隔;  

    private int m_FrameUpdate = 0;//帧数;  

    private float m_FPS = 0;

    private int total = 0;
	// Use this for initialization
	void Start () {
        // WeTest.U3DAutomation.CrashMonitor.CLOSE_MONITOR = false;
        Application.targetFrameRate = -1;
        this.gameObject.AddComponent<WeTest.U3DAutomation.U3DAutomationBehaviour>();

        WeTest.U3DAutomation.CustomHandler.RegisterCallBack("test", testReq);
        WeTest.U3DAutomation.CustomHandler.RegisterCallBack("world2screen", position);
        WeTest.U3DAutomation.CustomHandler.RegisterCallBack("currentposition", currentPosition);

        //callBack("hello reflect invoke");
        m_LastUpdateShowTime = Time.realtimeSinceStartup; 

     }
    void Update()
    {
        m_FrameUpdate++;
        if (Time.realtimeSinceStartup - m_LastUpdateShowTime >= m_UpdateShowDeltaTime)
        {
            m_FPS = m_FrameUpdate / (Time.realtimeSinceStartup - m_LastUpdateShowTime);
            m_FrameUpdate = 0;
            m_LastUpdateShowTime = Time.realtimeSinceStartup;
        }

        PrintTouch();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2, 0, 100, 100), "FPS: " + (int)m_FPS);
    } 

    string testReq(string args)
    {
        Debug.Log("Args = " + args);
        string result = args + " Response";
        return result;
    }

    private void PrintTouch()
    {
        Touch[] touchs = Input.touches;
        for (int i = 0; i < touchs.Length; ++i)
        {
            Touch t = touchs[i];
            Debug.Log(String.Format("Touch delta time = {0},x = {1},y={2} ,fingerId = {3},phase = {4}", t.deltaTime * Time.timeScale, t.position.x, t.position.y, t.fingerId, t.phase));
        }
    }



    public Camera FindBestCamera(GameObject obj)
    {
        Camera[] camerasArray = Camera.allCameras;
        List<Camera> cameras = new List<Camera>();

        //找到渲染改GameObject的Camera
        for (int i = 0; i < camerasArray.Length; ++i)
        {
            if ((camerasArray[i].cullingMask & (1 << obj.layer)) == (1 << obj.layer))
            {
                cameras.Add(camerasArray[i]);
            }
        }

        cameras.Sort(
            delegate(Camera p1, Camera p2)
            {
                return (int)(p2.depth - p1.depth);
            });

        for (int i = 0; i < cameras.Count; ++i)
        {
            if (cameras[i] == null || !cameras[i].gameObject.activeInHierarchy)
            {
                continue;
            }
            //TODO,如果有多个的情况情况下，选渲染GameObject最大的那个
            return cameras[i];
        }
        return null;

    }

    string position(string arg)
    {
        Debug.Log("position arg = " + arg);
        WorldScreen ws=WeTest.U3DAutomation.JsonMapper.ToObject<WorldScreen>(arg);
        GameObject cam = GameObject.Find(ws.name);
        if (cam == null)
        {
            Debug.Log("not find hero");
            return "";
        }
        Camera c = cam.GetComponent<Camera>();
        if (c == null)
        {
            Debug.Log("not find camera");
            return "";
        }
        Vector3 v = new Vector3();
        v.x = (float)ws.x;
        v.y = (float)ws.y;
        v.z = (float)ws.z;
        Vector3 v1 = c.WorldToScreenPoint(v);
        Vector2 pt = new Vector2(v1.x, v1.y);
        Point p = CoordinateTool.ConvertUnity2Mobile(pt);
        string res="{x:" + p.X + ",y:" + p.Y + "}";
        return res;
    }

    string currentPosition(string arg)
    {
        GameObject obj=GameObject.Find(arg);
        Vector3 v=obj.transform.position;
        string res = "{x:" + v.x + ",y:" + v.y +",z:"+v.z+ "}";
        return res;
    }

    void OnDestroy()
    {
        WeTest.U3DAutomation.CustomHandler.UnRegisterCallBack("world2screen");
        WeTest.U3DAutomation.CustomHandler.UnRegisterCallBack("currentposition");
        Debug.Log("UnRegister test");
    }

}
