using UnityEngine;
using System.Collections;

public class Slider : MonoBehaviour
{

    [Range(0, 10)]
    public int currentlyValue = 0;
    public int skip = 1;

    private int _defaultValue;
    
    // Use this for initialization
    void Start()
    {
        _defaultValue = currentlyValue;
    }

    // Update is called once per frame
    void Update()
    {

        transform.FindChild("ControlKnob").transform.position = new Vector3(this.transform.position.x + (currentlyValue * 0.253f), this.transform.position.y, this.transform.position.z);
    }

    void Reset()
    {
        currentlyValue = _defaultValue;
    }

    public int GetValue()
    {
        return currentlyValue;
    }

}
