using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : VRTK.VRTK_InteractableObject{

    public enum ButtonType
    {
        NONE,
        CHANGE_SCENE,
        USE_SLIDER,
    }

    #region [ PUBLIC_VARIABLE ]
    public Vector3 originSize;
    public float magnificationRate;
    public ButtonType type = ButtonType.NONE;
    public Scenes nextScene = Scenes.UNKNOWN;
    #endregion

    #region [ PRIVATE_VARIABLE ]
    private bool _isLooking =false;
    #endregion

    public override void StartUsing(GameObject currentUsingObject)
    {
        base.StartUsing(currentUsingObject);
        Push();
    }

    // Use this for initialization
    void Start()
    {
        if (this.gameObject.tag != "Button")
            this.gameObject.tag = "Button";

        if (this.gameObject.GetComponent<BoxCollider>() == null)
            this.gameObject.AddComponent<BoxCollider>();

        originSize = this.transform.localScale;
        magnificationRate = 1.1f;
        nextScene = GetComponent<Button>().nextScene;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isLooking)
            this.transform.localScale = originSize * magnificationRate;
        else
            this.transform.localScale = originSize;

        _isLooking = false;
    }
    public void Push()
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
                //FadeManager.instance.LoadLevel(nextScene.ToString() + "Scene");
                FadeManager.instance.LoadLevel(nextScene.ToString() + "Scene", FadeManager.instance.texs[0]);
                break;
            case ButtonType.USE_SLIDER:
                TransformToSlider();
                break;
                
        }
    }
    void TransformToSlider()
    {

    }
    public void Appeal()
    {
        _isLooking = true;
    }
}
