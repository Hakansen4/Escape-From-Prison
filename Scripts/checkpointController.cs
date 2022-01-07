using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointController : MonoBehaviour
{
    public GameObject cp1Flare;
    public GameObject cp2Flare;
    public GameObject cp3Flare;
    public gameController gc;
    private int activeCP = 0;
    private void Awake()
    {
        activeCP = 0;
    }
    public void setPoint1()
    {
        cp1Flare.SetActive(true);
        activeCP = 1;
    }
    public void setPoint2()
    {
        cp2Flare.SetActive(true);
        activeCP = 2;
    }
    public void setPoint3()
    {
        cp3Flare.SetActive(true);
        activeCP = 3;
    }
    public void end()
    {
        gc.endAnimStart();
    }
    public Vector3 activeCheckpoint()
    {
        if(activeCP == 3)
        {
            return new Vector3(-3, -10.698f, 266.130005f);
        }
        else if(activeCP == 2)
        {
            return new Vector3(-3f, -10.698f, 140.990005f);
        }
        else if(activeCP == 1)
        {
            return new Vector3(-72.5f, 1.64f, 54.62f);
        }
        else
        {
            return new Vector3(-17.4f, 1.64f, -7.649f);
        }
    }
}
