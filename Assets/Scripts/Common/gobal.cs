using UnityEngine;
using System.Collections;

public class gobal : MonoBehaviour {

    static bool inited = false;
    // Use this for initialization
    void Start()
    {
        if (!inited)
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            inited = true;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        UnityEngine.Profiling.Profiler.BeginSample("Gobal");
        if (Input.GetKey("escape"))
            Application.Quit();

        UnityEngine.Profiling.Profiler.EndSample();
	}
}
