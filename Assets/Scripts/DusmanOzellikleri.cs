using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanOzellikleri : MonoBehaviour
{
    [Header("Dusman Ozellikleri")]
    [SerializeField] float DusmanCanı = 100; //11
    [SerializeField] int DusmanSkorDeğeri = 150;

    [Header("Dusman Ates Etme")]
    float AtisSayici;
    [SerializeField] float AtislarArasiMinZaman = 0.2f;
    [SerializeField] float AtislarArasiMaxZaman = 3f;
    [SerializeField] GameObject LazerMermi;
    [SerializeField] float LazerHizi;

    [Header("Dusman Efeketleri")]
    [SerializeField] GameObject PatlamaAniVFX;
    [SerializeField] float DusmanPatlamaAniSuresi = 0.8f;
    [SerializeField] AudioClip DusmanPatlamaSFX; //15
    [SerializeField] [Range(0, 1)] float DusmanPatlamaSFXSesYuksekligi = 0.75f; //15
    [SerializeField] AudioClip DusmanAtesEtmeSFX;
    [SerializeField] [Range(0, 1)] float DusmanAtesEtmeSFXSesYuksekligi = 0.75f;

    void Start()
    {
        AtisSayici = Random.Range(AtislarArasiMinZaman, AtislarArasiMaxZaman); // 13
    }

    void Update()
    {
        AtislariSayVeVur(); // 13
    }

    private void AtislariSayVeVur()
    {
        AtisSayici -= Time.deltaTime; // 13

        if(AtisSayici <= 0f)
        {
            AtesEt();
            AtisSayici = Random.Range(AtislarArasiMinZaman, AtislarArasiMaxZaman); // 13
        }
    }

    private void AtesEt()
    {
        GameObject Lazer = Instantiate(LazerMermi, transform.position, Quaternion.identity) as GameObject;
        Lazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -LazerHizi);
        AudioSource.PlayClipAtPoint(DusmanAtesEtmeSFX, Camera.main.transform.position, DusmanAtesEtmeSFXSesYuksekligi);
    }

    private void OnTriggerEnter2D(Collider2D CarpismaAnı) //11
    {
        HasarVerici HasarVerici1 = CarpismaAnı.gameObject.GetComponent<HasarVerici>(); //11

        VurulmaAnı(HasarVerici1); //12
    }

    private void VurulmaAnı(HasarVerici HasarVerici1)
    {
        DusmanCanı -= HasarVerici1.HasarAl();
        HasarVerici1.HasarVer(); //14

        if (DusmanCanı <= 0) //12
        {
            DusmanPatlamaAni();
        }
    }

    private void DusmanPatlamaAni()
    {
        FindObjectOfType<OyunOturumu>().SkoraPuanEkle(DusmanSkorDeğeri);
        Destroy(gameObject);
        GameObject PatlamaEfekti = Instantiate(PatlamaAniVFX, transform.position, transform.rotation);
        Destroy(PatlamaEfekti, DusmanPatlamaAniSuresi);
        AudioSource.PlayClipAtPoint(DusmanPatlamaSFX,Camera.main.transform.position,DusmanPatlamaSFXSesYuksekligi);
    }
}
