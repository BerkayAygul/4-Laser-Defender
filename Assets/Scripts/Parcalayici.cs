using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcalayici : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D CarpismaObjesiniAl) //6
    {
        Destroy(CarpismaObjesiniAl.gameObject);
    }

}
