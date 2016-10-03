using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Start");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
