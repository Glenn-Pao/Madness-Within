using UnityEngine;
using System.Collections;

public class CaseLockRender : MonoBehaviour
{
    public int i_CurrentDial;
    public GameObject LockCode;
	float f_rotation = 0f;
    //(int)(GetComponent<CaseLocker>().c_PasscodeCur[i_CurrentDial] - '0'); Value
    //36 degrees
    void Start()
    {
		
    }
    
    void Update()
    {
		f_rotation += ((float)((int)(LockCode.GetComponent<CaseLocker> ().c_PasscodeCur [i_CurrentDial] - '0') * 36f) - f_rotation + 10f) * Time.deltaTime * 3f;
		//GetComponent<Transform>().localRotation.SetAxisAngle(new Vector3(0, 0, 1), (float)((int)(LockCode.GetComponent<CaseLocker>().c_PasscodeCur[i_CurrentDial] - '0') * 36f) * (3.141592654f/180f));
		GetComponent<Transform>().localRotation = Quaternion.Euler(GetComponent<Transform>().localRotation.x, GetComponent<Transform>().localRotation.y, f_rotation);//* (3.141592654f/180f)
	}
}
