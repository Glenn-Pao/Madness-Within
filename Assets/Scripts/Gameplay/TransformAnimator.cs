using UnityEngine;
using System.Collections;

public class TransformAnimator : MonoBehaviour
{
    public bool b_TransformPosition = false;
    public bool b_TransformRotation = false;

    public Vector3 v3_RotationalMovement;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(b_TransformRotation)
            this.transform.Rotate(v3_RotationalMovement);
    }
}
