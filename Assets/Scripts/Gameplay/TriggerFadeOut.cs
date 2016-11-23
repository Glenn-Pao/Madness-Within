using UnityEngine;
using System.Collections;

public class TriggerFadeOut : MonoBehaviour 
{
    public ScreenFader fade;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fade.fadeIn = false;
        }
    }


}
