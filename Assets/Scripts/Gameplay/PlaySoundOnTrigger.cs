using UnityEngine;
using System.Collections;

public class PlaySoundOnTrigger : MonoBehaviour
{
    public RealSpace3D.RealSpace3D_AudioSource RS_Sound;
    public bool b_playOnce;


    bool b_soundPlayed = false;

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
        if ((b_playOnce && !b_soundPlayed) || !b_playOnce)
        {
            if (other.tag == "Player")
            {
                RS_Sound.rs3d_PlaySound();
                b_soundPlayed = true;
            }
        }
        else
        {
            GameObject.Destroy(this.GetComponent<PlaySoundOnTrigger>());
        }
    }
}
