using UnityEngine;
using System.Collections;

//Flickering lights
public class FlickeringLight : MonoBehaviour
{
    //this light component
    private Light thisLight;

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
        thisLight = this.GetComponent<Light>();

        //start a coroutine order
        StartCoroutine("Flicker");
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            thisLight.enabled = true;
            yield return new WaitForSeconds(Random.Range(minLightMS, maxLightMS) / 1000f);

            //flickering light period
            for (int i = 0; i < Random.Range(minFlickers, maxFlickers); i++)
            {
                thisLight.enabled = false;
                yield return new WaitForSeconds(Random.Range(minDarkMS, maxDarkMS) / 1000f);
                thisLight.enabled = true;
                yield return new WaitForSeconds(Random.Range(minFlickerMS, maxFlickerMS) / 1000f);
            }
        }
    }
}
