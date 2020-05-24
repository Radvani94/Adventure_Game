using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedTest : ScriptedEventTrigger
{
    private float TotalTime = 0;
    private BoxCollider thisCollider;
    public float Delay = 3;
    public GameObject TestBlocks;
    public ObjectType Action;

    public Rigidbody[] bodiez;
    public Light thislight;

    private void Start()
    {
        thisCollider = gameObject.GetComponent<BoxCollider>();
        switch(Action)
        {
            case ObjectType.FALLING_OBJECT:
                bodiez = TestBlocks.GetComponentsInChildren<Rigidbody>();
                break;
            case ObjectType.LIGHT_ON:
                thislight.enabled = false;
                break;
        }
    }
    void waitFor(float _seconds)
    {
        StartCoroutine("waitForMe", _seconds);
    }

    void DoThis()
    {
        Debug.Log("DID THIS");
        switch (Action)
        {
            case ObjectType.FALLING_OBJECT:
                for (int i = 0; i < bodiez.Length; i++)
                {
                    bodiez[i].useGravity = true;
                }
                break;
            case ObjectType.LIGHT_ON:
                thislight.enabled = true;
                break;
        }

        thisCollider.enabled = false;
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
