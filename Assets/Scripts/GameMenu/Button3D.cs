namespace MasujimaRyohei
{
    using UnityEngine;
    using System.Collections;
    using UnityEngine.SceneManagement;

    public class Button3D : VRTK.VRTK_InteractableObject
    {

        public enum ButtonType
        {
            NONE,
            CHANGE_SCENE,
            USE_SLIDER,
            SAVING_DATA
        }

        #region [ PUBLIC_VARIABLE ]
        public Vector3 originSize;
        public float magnificationRate;
        public ButtonType type = ButtonType.CHANGE_SCENE;
        public Scenes nextScene = Scenes.UnknownScene;
        #endregion

        #region [ PRIVATE_VARIABLE ]
        private bool _isLooking = false;
        private Transform _text;
        #endregion

        public override void StartUsing(GameObject currentUsingObject)
        {
            base.StartUsing(currentUsingObject);
            Push();
        }

        // Use this for initialization
        private void Start()
        {
            if (this.gameObject.tag != "Button")
                this.gameObject.tag = "Button";

            if (this.gameObject.GetComponent<BoxCollider>() == null)
                this.gameObject.AddComponent<BoxCollider>();

            originSize = this.transform.localScale;
            magnificationRate = 1.1f;
            nextScene = GetComponent<Button3D>().nextScene;
            if(!(_text = this.transform.FindChild("text")))
            {
                Debug.LogError("There is not text object at child");
            }
        }

        // Update is called once per frame
        private void Update()
        {
            if (_isLooking)
            {
                this.transform.localScale = originSize * magnificationRate;
                _text.GetComponent<TextMesh>().color = Color.black;
            }
            else
            {
                this.transform.localScale = originSize;
                _text.GetComponent<TextMesh>().color = Color.white;
            }

            _isLooking = false;
        }
        public void Push()
        {
            Debug.Log(this.name + "Pushed");
            switch (type)
            {
                case ButtonType.NONE:
                    break;
                case ButtonType.CHANGE_SCENE:
                    // Unuse fade.
                    //SceneManager.LoadScene(nextScene.ToString() + "Scene");

                    // Use fade.
                    //FadeManager.instance.LoadLevel(nextScene.ToString() + "Scene");
                    FadeManager.instance.LoadLevel(nextScene.ToString());
                    break;
                case ButtonType.USE_SLIDER:
                    TransformToSlider();
                    break;
                case ButtonType.SAVING_DATA:
                    GameObject.Find("LevelManager").GetComponent<OptionsScene>().Saving();
                    break;

            }
        }
        private void TransformToSlider()
        {
            // Unuse
        }
        public void Appeal()
        {
            // Useing raycast
            _isLooking = true;
        }
    }
}