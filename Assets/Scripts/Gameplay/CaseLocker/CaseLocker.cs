using UnityEngine;
using System.Collections;

public class CaseLocker : MonoBehaviour
{
    public char[] c_Passcode;
    public char[] c_PasscodeCur;

    // Use this for initialization
    void Start()
    {
        /*c_PasscodeCur = new char[4];

        for (int i = 0; i < 4; ++i)
        {
            c_PasscodeCur[i] = '0';
        }//*/
    }

    void Update()
    {
		//Debug.Log (new string (c_PasscodeCur));
		if (GetComponent<VRTK.VRTK_Chest>().b_CheckLocker)
		{
			GetComponent<VRTK.VRTK_Chest>().io.isGrabbable = isUnlocked();
		}

    }

    public void toggleDial(int position)
    {
        if (c_PasscodeCur[position] < '9')
        {
            c_PasscodeCur[position]++;
        }
        else
        {
            c_PasscodeCur[position] = '0';
        }
    }

	public bool isUnlocked()
	{
		for (int i = 0; i < 4; i++)
		{
			if (c_Passcode [i] != c_PasscodeCur [i])
				return false;
		}//
		return true;
	}
}
