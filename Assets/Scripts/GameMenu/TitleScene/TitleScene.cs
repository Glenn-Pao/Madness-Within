using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public GameObject audioManager;
    public GameObject fadeManager;
    public GameObject timeManager;
    // Use this for initialization
    public void Awake()
    {
        if(!GameObject.Find("AudioManager"))
        {
            Instantiate(audioManager);
        }
        if (!GameObject.Find("FadeManager"))
        {
            Instantiate(fadeManager);
        }
        if (!GameObject.Find("TimeManager"))
        {
            Instantiate(timeManager);
        }
    }

    public void Start() { }

    // Update is called once per frame
    void Update()
    {
    }
}
