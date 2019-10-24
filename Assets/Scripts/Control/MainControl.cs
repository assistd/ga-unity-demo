using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Reflection;

public class MainControl : MonoBehaviour {

    public GameObject sampleButton;
    public GameObject findElementsButton;
    public GameObject interactionButton;
    public GameObject joystickButton;
    public GameObject callPcButton;

    public Transform bollon;

	// Use this for initialization
	void Start () {
        EventTriggerListener.Get(sampleButton).onClick += SampleHandler;
        EventTriggerListener.Get(callPcButton).onClick += CallPythonClient;
        EventTriggerListener.Get(callPcButton).onClick += CallPythonClientReturnValue;
        EventTriggerListener.Get(callPcButton).onClick += CallPythonClientReturnNone;
        EventTriggerListener.Get(findElementsButton).onClick += LoadFindElements;
        EventTriggerListener.Get(interactionButton).onClick += LoadInteraction;
        EventTriggerListener.Get(joystickButton).onClick += LoadJoyStick;
	}

    public static void printResult(int status,string message)
    {
        Debug.Log("call back result = " + message+" status = "+status);
    }

    private static void PrintFiles()
    {
        Assembly excute = Assembly.GetAssembly(typeof(MainControl));
        Module[] files = excute.GetLoadedModules();
        foreach (Module f in files)
        {
            Debug.Log("Cs Files:" + f.FullyQualifiedName);
            Type[] types=f.GetTypes();

            foreach (Type t in types)
            {
                
                if (t.IsImport)
                {
                    Debug.Log("Import Type Files:" + t.FullName+" Handle "+t.TypeHandle.Value);
                }
                else
                {
                    Debug.Log("UnImport Type Files:" + t.FullName+" Handle "+t.TypeHandle.Value);
                }
                
            }
        }

        
    }

    public void CallPythonClient(GameObject obj)
    {

        WeTest.U3DAutomation.CustomHandler.InvokeClientMethod("test", "call python client callback", printResult);
    }

    public void CallPythonClientReturnValue(GameObject obj)
    {
        string result = WeTest.U3DAutomation.CustomHandler.InvokeClientMethodReturnValue("testReturn", "call python client return value", 1000);
        Debug.Log("CallPythonClientReturnValue return value = " + result);
    }

    public void CallPythonClientReturnNone(GameObject obj)
    {
        WeTest.U3DAutomation.CustomHandler.InvokeClientMethod("testReturn", "call python client not return value");
    }

    public void SampleHandler(GameObject obj)
    {
        Vector3 pos = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Transform bollonObj = Instantiate(bollon, pos, Quaternion.identity) as Transform;
        
        bollonObj.parent = this.gameObject.transform.parent;

        PrintFiles();
    }

    public void LoadFindElements(GameObject obj)
    {
        Application.LoadLevel("FindElements");
    }

    public void LoadInteraction(GameObject obj)
    {
        Application.LoadLevel("Interaction");
    }

    public void LoadJoyStick(GameObject obj)
    {
        Application.LoadLevel(3);
    }
}
