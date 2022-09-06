using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dusman Dalga Config")] //8
public class DalgaConfig : ScriptableObject
{
    [SerializeField] GameObject DusmanPrefab; //8
    [SerializeField] GameObject DusmanYolPrefab;
    [SerializeField] float SpawnlarArasiZaman = 0.5f;
    [SerializeField] float SpawnRandomFaktor = 0.3f;
    [SerializeField] int DusmanlarinSayisi = 5;
    [SerializeField] float DusmanHareketHizi = 2f;

    public GameObject DusmanPrefabAl()
    {
        return DusmanPrefab;
    }
    public List<Transform> DusmanAraNoktalariAl()//9
    {
        var DalgaAraNoktaları = new List<Transform>();

        foreach (Transform DusmanYolundakiAraNoktalar in DusmanYolPrefab.transform)
        {
            DalgaAraNoktaları.Add(DusmanYolundakiAraNoktalar);
        }

        return DalgaAraNoktaları;
    }
    public float SpawnlarArasiZamanAl()
    {
        return SpawnlarArasiZaman;
    }
    public float SpawnRandomFaktorAl()
    {
        return SpawnRandomFaktor;
    }
    public int DusmanlarinSayisiAl()
    {
        return DusmanlarinSayisi;
    }
    public float DusmanHareketHızıAl()
    {
        return DusmanHareketHizi;
    }


}
