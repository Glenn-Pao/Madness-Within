using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeManager : SingletonMonoBehavior<FadeManager> {



    private float _fadeAlpha = 0;
    private bool _isFading = false;

    public Color fadeColor = Color.black;
    public float defInterval = 0.5f;

    public void Awake()
    {
        if(this != instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void OnGUI()
    {
        if (this._isFading)
        {
            this.fadeColor.a = this._fadeAlpha;
            GUI.color = this.fadeColor;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
        }
    }
  
    public void LoadLevel(string scene, float interval)
    {
        StartCoroutine(TransScene(scene, interval));
    }
    public void LoadLevel(string scene)
    {
        StartCoroutine(TransScene(scene, defInterval));
    }

    private IEnumerator TransScene(string scene, float interval)
    {
        // It's getting dark.
        this._isFading = true;
        float time = 0;
        while (time <= interval)
        {
            this._fadeAlpha = Mathf.Lerp(0f, 1f, time / interval);
            time += Time.deltaTime;
            yield return 0;
        }

        SceneManager.LoadScene(scene);

        // It's getting lighter.
        time = 0;
        while(time <= interval)
        {
            this._fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
            time += Time.deltaTime;
            yield return 0;
        }

        this._isFading = false;
    }
}
