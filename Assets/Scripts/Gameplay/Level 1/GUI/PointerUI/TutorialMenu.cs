using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//Tutorial UI that makes use of the UI System
public class TutorialMenu : MonoBehaviour
{
    public TextMesh thisMesh;                   //the text mesh

    private bool isReleased = false;            //whether player released the trigger button
    private bool isFading = false;              //whether it is fading

    public Texture2D texture;

    private float _fadeAlpha = 0;
    private bool _isFading = false;

    public bool isUsingTexture = false;
    public Color fadeColor;
    public const float defInterval = 0.5f;

    // Use this for initialization
    void Start ()
    {
        if (thisMesh == null)
        {
            thisMesh = this.GetComponent<TextMesh>();
        }
	}
    public void OnGUI()
    {
        if (this._isFading)
        {

            if (this.isUsingTexture)
            {
                GUI.color = this.fadeColor;
                this.fadeColor.a = this._fadeAlpha;
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
            }
            else
            {
                GUI.color = this.fadeColor;
                this.fadeColor.a = this._fadeAlpha;
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
            }
        }
    }
    // Update is called once per frame
    void Update ()
    {
        bool temp = this.GetComponent<PointerUIReceiver>().Interacted();
        if (temp && !isReleased)
        {
            isReleased = true;
            this.GetComponent<FadeInFadeOut>().FadeIn();
            
        }
        else if (!temp && isReleased)
        {
            isReleased = false;
            this.GetComponent<FadeInFadeOut>().FadeOut();
            isFading = true;
            LoadLevel("Level1");
        }
    }

    public void LoadLevel(string scene, float interval = defInterval)
    {
        StartCoroutine(TransScene(scene, interval));
    }

    private IEnumerator TransScene(string scene, float interval)
    {
        // It's getting dark.
        #region [ FADEOUT ]
        this._isFading = true;
        float time = 0;
        while (time <= interval)
        {
            this._fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            time += Time.deltaTime;
            yield return 0;
        }
        #endregion

        SceneManager.LoadScene(scene);

        // It's getting lighter.
        #region [ FADEIN ]
        time = 0;
        while (time <= interval)
        {
            this._fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
            time += Time.deltaTime;
            yield return 0;
        }

        this._isFading = false;
        #endregion
    }
}
