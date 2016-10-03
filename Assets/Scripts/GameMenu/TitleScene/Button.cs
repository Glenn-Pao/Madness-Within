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

    #region [ PUBLIC_VARIABLE ]
    public Vector3 originSize= new Vector3(0.04f, 0.04f, 0.04f);
    public Vector3 lookingSize = new Vector3(0.05f, 0.05f, 0.05f);
    public ButtonType type = ButtonType.NONE;
    public string nextScene = "Empty";
    #endregion

    #region [ PRIVATE_VARIABLE ]
    private bool _isLooking;
    #endregion


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (_isLooking)
            this.transform.localScale = lookingSize;
        else
            this.transform.localScale = originSize;
    }
    void pushedButton()
    {
        switch (type)
        {
            case ButtonType.NONE:
                break;
            case ButtonType.CHANGE_SCENE:
                SceneManager.LoadScene(nextScene);
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
