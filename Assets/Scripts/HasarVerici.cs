using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasarVerici : MonoBehaviour
{
    [SerializeField] int Hasar = 100; // 11

    public int HasarAl()
    {
        return Hasar;
    }

    public void HasarVer()
    {
        Destroy(gameObject);
    }
}
