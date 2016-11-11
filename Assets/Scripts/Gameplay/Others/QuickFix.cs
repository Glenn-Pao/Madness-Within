using UnityEngine;
using System.Collections;

public class QuickFix : MonoBehaviour 
{	
	// Update is called once per frame
	void Update () 
    {
        if (!this.GetComponent<VRTK.VRTK_InteractableObject>().enabled)
        {
            this.GetComponent<VRTK.VRTK_InteractableObject>().enabled = true;
        }
	}
}
