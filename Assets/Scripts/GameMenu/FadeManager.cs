using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class FadeManager : SingletonMonoBehavior<FadeManager>
{

    public List<Texture2D> texs;

    private float _fadeAlpha = 0;
    private bool _isFading = false;

    public bool isUsingTexture =false;
    public Color fadeColor = Color.black;
    public const float defInterval = 0.5f;

    public void Awake()
    {
        if (this != instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        texs.Add((Texture2D)Resources.Load("Displacements"));
    }

    public void OnGUI()
    {
        if (this._isFading)
        {
            this.fadeColor.a = this._fadeAlpha;
            GUI.color = this.fadeColor;
            if (this.isUsingTexture)
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
            else
            {
                //GUI.color = Color.white;
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texs[0]);
            }
        }
    }

    public void LoadLevel(string scene, float interval = defInterval)
    {
        StartCoroutine(TransScene(scene, interval));
    }

    public void LoadLevel(string scene,Texture2D tex, float interval = defInterval)
    {
        StartCoroutine(TransSceneWithTexture(scene, tex, interval));
    }
    

    public void Wink(float interval)
    {
        StartCoroutine(FadeInOut(interval));
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
    private IEnumerator TransSceneWithTexture(string scene,  Texture2D texture, float interval)
    {
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

    private IEnumerator FadeInOut(float interval)
    {
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
