using UnityEngine;
using System.Collections;

public class GeneratorFailure : MonoBehaviour
{
    public RealSpace3D.RealSpace3D_AudioSource RS_GeneratorFailSound;
    public RealSpace3D.RealSpace3D_AudioSource RS_GeneratorSound;
    public RealSpace3D.RealSpace3D_AudioSource RS_FireSound;
    public RealSpace3D.RealSpace3D_AudioSource RS_FirePutout;
    public ParticleSystem[] PS_Particles;
    public Light[] L_Lights;
    public GameObject GO_Fire;

    public bool b_SetReadyToTrigger = false;
    public bool b_EventTriggered = false;
    public bool b_PutFireOut = false;

    float f_Temp = 10f;

    // Use this for initialization
    void Start()
    {
        RS_FireSound.rs3d_StopSound();
    }

    // Update is called once per frame
    void Update()
    {
        if (b_EventTriggered)
        {
            if (b_PutFireOut)
            {
                for (int i = 0; i < PS_Particles.Length; i++)
                {
                    PS_Particles[i].enableEmission = false;
                }

                for (int i = 0; i < L_Lights.Length; i++)
                {
                    L_Lights[i].enabled = false;
                }

                RS_FireSound.rs3d_StopSound();
                RS_FirePutout.rs3d_PlaySound();

                GameObject.Destroy(this.GetComponent<GeneratorFailure>());
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (b_SetReadyToTrigger)
        {
            if (!b_EventTriggered)
            {
                if (other.tag == "Player")
                {
                    RS_GeneratorFailSound.rs3d_PlaySound();
                    RS_GeneratorSound.rs3d_StopSound();
                    RS_FireSound.transform.position = GO_Fire.transform.position;
                    RS_FireSound.rs3d_PlaySound();
                    RS_FireSound.rs3d_LoopSound(true);
                    b_EventTriggered = true;
                    GO_Fire.SetActive(true);
                }
            }
        }
    }
}
