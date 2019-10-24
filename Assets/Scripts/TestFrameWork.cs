using UnityEngine;
using System.Collections;

public class TestFrameWork
{
    static bool result=false;

    public static float[] GetCurrentPostion()
    {
        Debug.Log("GetCurrentPosition");
        float[] pos=new float[]{0.4323f,0.112f,13.145f};
        return pos;
    }

    public static bool GoPosition(float x, float y, float z)
    {
        Debug.Log("GetCurrentPosition "+x+","+y+","+z);
        result ^= result;
        return result;
    }
}
