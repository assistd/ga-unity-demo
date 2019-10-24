using UnityEngine;
using System.Collections;

public class ReflectionTest : MonoBehaviour
{

    public Transform bollon;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int TestReflection(int a, string b)
    {
        Debug.Log("Reflection test: " + a + " " + b);
        Vector3 pos = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Transform bollonObj = Instantiate(bollon, pos, Quaternion.identity) as Transform;
        bollonObj.parent = this.gameObject.transform.parent;
        return a + 100;
    }
}
