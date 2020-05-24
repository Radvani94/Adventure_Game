using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedTest : ScriptedEventTrigger
{
    private float TotalTime = 0;
    public float Delay = 3;
    public GameObject TestBlocks;
    public Rigidbody[] bodiez;

    private void Start()
    {
        bodiez = TestBlocks.GetComponentsInChildren<Rigidbody>();
    }
    void waitFor(float _seconds)
    {
        StartCoroutine("waitForMe", _seconds);
    }

    void DoThis()
    {
        Debug.Log("DID THIS");
        for(int i =0; i<bodiez.Length; i++)
        {
            bodiez[i].useGravity = true;
        }
    }

    IEnumerator waitForMe(float secs)
    {

        while (TotalTime <= secs)
        {
            TotalTime += Time.deltaTime;
            Debug.Log("COUNTING");
            yield return null;
        }
        Debug.Log("TIME DONE");
        DoThis();
        TotalTime = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        waitFor(Delay);
    }

    private void OnTriggerExit(Collider other)
    {

    }
}
