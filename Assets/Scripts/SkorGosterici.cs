using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkorGosterici : MonoBehaviour
{
    Text SkorText;
    OyunOturumu oyunOturumu;

    void Start()
    {
        SkorText = GetComponent<Text>();
        oyunOturumu = FindObjectOfType<OyunOturumu>();
    }


    void Update()
    {
        SkorText.text = oyunOturumu.SkorAl().ToString();
    }
}
