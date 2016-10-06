﻿// Author MasujimaRyohei

using UnityEngine;

public class SingletonMonoBehavior<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T instance {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));

                if (_instance == null)
                {
                    Debug.LogError(typeof(T) + "Is nothing.");
                }
            }
            return _instance;
        }
    }
}