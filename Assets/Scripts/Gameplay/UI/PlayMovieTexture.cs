using UnityEngine;
using System.Collections;

public class PlayMovieTexture : MonoBehaviour
{
    public MovieTexture movie;
    //public bool loop = true;
    GameObject GO_Head;

    Vector3 v3_ScreenCheck;
    // Use this for initialization
    void Start()
    {
        GO_Head = GameObject.FindGameObjectWithTag("MainCamera");

        if (movie == null)
        {
            movie = this.GetComponent<Renderer>().material.mainTexture as MovieTexture;
        }

        movie.loop = true;
        //movie.Play();
    }

    void Update()
    {
        v3_ScreenCheck = GO_Head.GetComponent<Camera>().WorldToViewportPoint(this.transform.position);
        if (((v3_ScreenCheck.x > 0 && v3_ScreenCheck.x < 1 && v3_ScreenCheck.y > 0 && v3_ScreenCheck.y < 1) && v3_ScreenCheck.z > 0) && Vector3.SqrMagnitude(GO_Head.transform.position - this.transform.position) < 15)
        {
            if (!movie.isPlaying)
            {
                movie.Play();
            }
        }
        else
        {
            if (movie.isPlaying)
            {
                movie.Stop();
            }
        }
    }
}
