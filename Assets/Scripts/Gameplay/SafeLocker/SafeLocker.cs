using UnityEngine;
using System.Collections;

public class SafeLocker : MonoBehaviour
{
    public int PasswordLength = 5;
    public string s_Password = "86195";
    public string s_CurPassword = "";
    public bool b_CanOpen = false;
    public bool b_ShowError = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool isUnlocked()
    {
        return (s_Password == s_CurPassword);
    }

    public void clearKey()
    {
        s_CurPassword = "";
    }

    public void enterKey(char KEY)
    {
        if (s_CurPassword.Length < PasswordLength)
        {
            s_CurPassword += KEY;
        }
    }

    public void ShowError()
    {
        b_ShowError = true;
    }
}
