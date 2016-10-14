namespace MasujimaRyohei
{

    using UnityEngine;
    using System.Collections;


    public class ExitScene : SceneBase
    {

        public int timerSecs = 5;
        // Use this for initialization
        private void Start()
        {
            //!!
            //!! I want to put character who wave she's hand.
            //!!



            Debug.Log("Exit");
            InvokeRepeating("CountDown", 1, 1);
        }

        private void CountDown()
        {
            timerSecs--;
            if (timerSecs < 1)
            {
                CancelInvoke("CountDown"); 
                QuitGame();
            }
        }

        private  void QuitGame()
        {
            Debug.Log("QUIT");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}