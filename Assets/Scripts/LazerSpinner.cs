using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSpinner : MonoBehaviour
{
    [SerializeField] float DonusHizi = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, DonusHizi * Time.deltaTime);
    }
}
