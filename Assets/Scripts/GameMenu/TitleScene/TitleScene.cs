using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{

    public string selectingItem = null;
    public GameObject txtTitle, txtPlay, txtOptions, txtExit;
    public Vector3 txtScale;

    // Use this for initialization
    public void Start()
    {
        txtScale = txtTitle.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        txtTitle.GetComponent<Renderer>().material.EnableKeyword("_Emission");
        txtTitle.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(1, 0, 0));
        //Debug.Log(txtTitle.GetComponent<Renderer>().material.GetColor("_EmissionColor"));
        Debug.Log(selectingItem);

        txtTitle.transform.localScale = txtScale;

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(selectingItem + "Scene");
        }
    }
}
