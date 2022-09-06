using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunOturumu : MonoBehaviour
{

    int Skor = 0;


    private void Awake()
    {
        SingletonSkor();
    }

    private void SingletonSkor()
    {
        int OyunOturumlar�n�nSay�s� = FindObjectsOfType<OyunOturumu>().Length;

        if(OyunOturumlar�n�nSay�s� > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int SkorAl()
    {
        return Skor;
    }

    public void SkoraPuanEkle(int SkorDegeri)
    {
        Skor += SkorDegeri;
    }

    public void OyunuBastanBaslat()
    {
        Destroy(gameObject);
    }
}
