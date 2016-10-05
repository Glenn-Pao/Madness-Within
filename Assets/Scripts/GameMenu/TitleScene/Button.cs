using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    public enum ButtonType
    {
        NONE,
        CHANGE_SCENE,
        USE_SLIDER,
    }
    public enum Scenes
    {
        UNKNOWN,
        Logo,
        Title,
        Play,
        Options,
        Exit,
    }

    #region [ PUBLIC_VARIABLE ]
    public Vector3 originSize;
    public float magnificationRate;
    public ButtonType type = ButtonType.NONE;
    public Scenes nextScene = Scenes.UNKNOWN;
    #endregion

    #region [ PRIVATE_VARIABLE ]
    private bool _isLooking;
    #endregion


    // Use this for initialization
    void Start()
    {
        if (this.gameObject.tag != "Button")
            this.gameObject.tag = "Button";

        if (this.gameObject.GetComponent<BoxCollider>() == null)
            this.gameObject.AddComponent<BoxCollider>();

        originSize = this.transform.localScale;
        magnificationRate = 1.5f;
        nextScene = GetComponent<Button>().nextScene;
    }

    // Update is called once per frame
    void Update()
    {

        if (_isLooking)
            this.transform.localScale = originSize * magnificationRate;
        else
            this.transform.localScale = originSize;
    }
    public void pushedButton()
    {
        Debug.Log("Pushed");
        switch (type)
        {
            case ButtonType.NONE:
                break;
            case ButtonType.CHANGE_SCENE:
                // Unuse fade.
                //SceneManager.LoadScene(nextScene.ToString() + "Scene");

                // Use fade.
                FadeManager.instance.LoadLevel(nextScene.ToString() + "Scene");
                break;
            case ButtonType.USE_SLIDER:
                TransformToSlider();
                break;
                
        }
    }
    void TransformToSlider()
    {

    }
}
