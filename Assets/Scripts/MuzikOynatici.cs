using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzikOynatici : MonoBehaviour
{

    void Awake()
    {
        SingletonMuzikCalar();
    }

    private void SingletonMuzikCalar()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


}
