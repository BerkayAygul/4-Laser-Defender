using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanMeydanaGetir : MonoBehaviour
{

    [SerializeField] List<DalgaConfig> DalgaConfigleri; // 9 // Dalganın scriptable objesini al ve serialize field olarak tek tek ata
    [SerializeField] bool DalgaDongusu = false; //10

    int IlkDalgaIndex = 0;

    /*void 10 */ IEnumerator Start()
    {
        // 9 // var SuAnkiDalga = DalgaConfigleri[IlkDalgaIndex];  // Dalganın scriptable objelerinin ilkini al
                                                            //  Kes ve tüm dalgaları oluşturma metotuna yapıştır       
         // Dalganın scriptable objesini kullanarak dalga olustur

        do // 10
        {
            yield return StartCoroutine(TumDalgalarıMeydanaGetir());

        } while (DalgaDongusu);

    }

    private IEnumerator DalgadakiTumDusmanlarıMeydanaGetir(DalgaConfig DalgaConfig1) //9
    {
        for(int DusmanSayisi = 0; DusmanSayisi < DalgaConfig1.DusmanlarinSayisiAl(); DusmanSayisi++) // Surekli kopya uret
        {//9
            var YeniDusman = Instantiate // Orjinali al ve klon gönder
            (DalgaConfig1.DusmanPrefabAl(), // Dusman prefablarını al 
            DalgaConfig1.DusmanAraNoktalariAl()[0].transform.position, // Ara noktaların pozisyonunu al
            Quaternion.identity); // Rotasyona ihtiyaç yok

            YeniDusman.GetComponent<DusmanYolBulma>().DalgaConfigAl(DalgaConfig1);

            yield return new WaitForSeconds(DalgaConfig1.SpawnlarArasiZamanAl());

        }
    }

    private IEnumerator TumDalgalarıMeydanaGetir() //10
    {
        for (int DalgaIndexi = IlkDalgaIndex; DalgaIndexi < DalgaConfigleri.Count; DalgaIndexi++)
        {
            var SuAnkiDalga = DalgaConfigleri[DalgaIndexi];
            yield return StartCoroutine(DalgadakiTumDusmanlarıMeydanaGetir(SuAnkiDalga));
        }

    }
}
