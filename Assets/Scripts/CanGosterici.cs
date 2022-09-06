using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanGosterici : MonoBehaviour
{
    Text CanText;
    Oyuncu oyuncu;

    void Start()
    {
        CanText = GetComponent<Text>();
        oyuncu = FindObjectOfType<Oyuncu>();
    }


    void Update()
    {
        CanText.text = oyuncu.CanGonder().ToString();
    }
}
