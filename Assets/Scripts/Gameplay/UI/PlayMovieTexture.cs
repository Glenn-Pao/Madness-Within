using UnityEngine;
using System.Collections;

public class PlayMovieTexture : MonoBehaviour
{
    public MovieTexture movie;
    public bool loop = true;
    // Use this for initialization
    void Start()
    {
        if (movie == null)
        {
            movie = this.GetComponent<Renderer>().material.mainTexture as MovieTexture;
        }

        if (loop)
        {
            movie.loop = true;
        }
        movie.Play();
    }
}
