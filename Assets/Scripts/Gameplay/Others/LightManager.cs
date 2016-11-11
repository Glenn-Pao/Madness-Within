using UnityEngine;
using System.Collections;

public class LightManager : MonoBehaviour {

    //this light component
    public Light[] lightSources;

    //steady light phase, the length of steady light active in miliseconds
    public float minLightMS = 500f;
    public float maxLightMS = 5000f;

    //flickering phase, the length of darkness in miliseconds
    public float minDarkMS = 25f;
    public float maxDarkMS = 50f;

    //the time between flickers in miliseconds during dark phase
    public float minFlickerMS = 25f;
    public float maxFlickerMS = 50f;

    //the number of times it flickers during dark phase
    public int minFlickers = 1;
    public int maxFlickers = 3;

    // Use this for initialization
    void Start()
    {
        //find the original light source
        //thisLight = this.GetComponent<Light>();

        //start a coroutine order
        StartCoroutine("Flicker");
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            for (int i = 0; i < lightSources.Length; i++)
            {
                lightSources[i].enabled = true;
            }
            yield return new WaitForSeconds(Random.Range(minLightMS, maxLightMS) / 1000f);

            //flickering light period
            for (int i = 0; i < Random.Range(minFlickers, maxFlickers); i++)
            {
                for (int j = 0; j < lightSources.Length; j++)
                {
                    lightSources[j].enabled = false;
                }

                yield return new WaitForSeconds(Random.Range(minDarkMS, maxDarkMS) / 1000f);

                for (int j = 0; j < lightSources.Length; j++)
                {
                    lightSources[j].enabled = true;
                }

                yield return new WaitForSeconds(Random.Range(minFlickerMS, maxFlickerMS) / 1000f);
            }

        }
    }
}
