using UnityEngine;
using System.Collections;

public class GeneratorFailureTriggerer : MonoBehaviour
{
    public GeneratorFailure GF_Failure;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (!GF_Failure.b_SetReadyToTrigger)
        {
            if (other.tag == "Player")
            {
                GF_Failure.b_SetReadyToTrigger = true;
            }
        }
    }
}