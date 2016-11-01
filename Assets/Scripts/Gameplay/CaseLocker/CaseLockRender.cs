using UnityEngine;
using System.Collections;

public class CaseLockRender : MonoBehaviour
{
    public int i_CurrentDial;
    public GameObject LockCode;
    //(int)(GetComponent<CaseLocker>().c_PasscodeCur[i_CurrentDial] - '0'); Value
    //36 degrees
    void Start()
    {
        
    }
    
    void Update()
    {
		//GetComponent<Transform>().localRotation.SetAxisAngle(new Vector3(0, 0, 1), (float)((int)(LockCode.GetComponent<CaseLocker>().c_PasscodeCur[i_CurrentDial] - '0') * 36f) * (3.141592654f/180f));
		GetComponent<Transform>().localRotation = Quaternion.Euler(GetComponent<Transform>().localRotation.x, GetComponent<Transform>().localRotation.y, (float)((int)(LockCode.GetComponent<CaseLocker>().c_PasscodeCur[i_CurrentDial] - '0') * 36f));//* (3.141592654f/180f)
	}
}
