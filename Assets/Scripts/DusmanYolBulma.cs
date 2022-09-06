using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanYolBulma : MonoBehaviour
{
    //[SerializeField] Dalga Config Serialize Field Gerek Yok
    DalgaConfig DalgaConfig1; //10
    [SerializeField] List<Transform> AraNoktalar; //7
    //[SerializeField] float DusmanHareketHızı = 2f; //10 Değiştirilecek

    int AraNoktalarIndex = 0;

    void Start()
    {
        AraNoktalar = DalgaConfig1.DusmanAraNoktalariAl();
        transform.position = AraNoktalar[AraNoktalarIndex].transform.position;   //7
    }


    void Update()
    {
        DusmanHareketi();
    }

    public void DalgaConfigAl(DalgaConfig DalgaConfig2)
    {
        DalgaConfig1 = DalgaConfig2;
    }
    private void DusmanHareketi() //7
    {
        if (AraNoktalarIndex <= AraNoktalar.Count - 1)
        {
            var HareketEdilecekPozisyon = AraNoktalar[AraNoktalarIndex].transform.position;

            var FrameBasiHareket = /*DusmanHareketHızı*/ DalgaConfig1.DusmanHareketHızıAl() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, HareketEdilecekPozisyon,
                                                     FrameBasiHareket);

            if (transform.position == HareketEdilecekPozisyon)
            {
                AraNoktalarIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
