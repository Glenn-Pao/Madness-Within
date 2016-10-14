namespace MasujimaRyohei
{

    using UnityEngine;
    using System.Collections;

    [RequireComponent(typeof(SceneBase))]
    public class ExitScene : MonoBehaviour
    {

        public int timerSecs = 5;
        // Use this for initialization
        void Start()
        {

            //!!
            //!! I want to put character who wave she's hand.
            //!!



            Debug.Log("Exit");
            InvokeRepeating("CountDown", 1, 1);
        }

        void CountDown()
        {
            timerSecs--;
            if (timerSecs < 1)
            {
                CancelInvoke("CountDown");
                QuitGame();
            }
        }

        void QuitGame()
        {
            Debug.Log("QUIT");
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}