using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaplanScroll : MonoBehaviour
{
    [SerializeField] float ArkaplanKaydirmaHizi = 0.5f;
    Material Materyal1;
    Vector2 Dengeleyici;


    // Start is called before the first frame update
    void Start()
    {
        Materyal1 = GetComponent<Renderer>().material;
        Dengeleyici = new Vector2(0f, ArkaplanKaydirmaHizi);
    }

    // Update is called once per frame
    void Update()
    {
        Materyal1.mainTextureOffset += Dengeleyici * Time.deltaTime;
    }
}
