using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyuncu : MonoBehaviour
{
    //Configuration Parameters
    [Header("Player")]
    [SerializeField] float HareketHızı = 10f; //1
    [SerializeField] float Padding = 1f; //3
    [SerializeField] int OyuncuCanı = 200; //13
    [SerializeField] AudioClip OyuncuPatlamaSFX; //15
    [SerializeField] [Range(0, 1)] float OyuncuPatlamaSFXSesYuksekligi = 0.75f; //15
    [SerializeField] AudioClip OyuncuAtesEtmeSFX;
    [SerializeField] [Range(0, 1)] float OyuncuAtesEtmeSFXSesYuksekligi = 0.75f;


    [Header("Projectile")]
    [SerializeField] GameObject LazerPrefab; //4
    [SerializeField] float LazerHızı = 10f; //5
    [SerializeField] float AteşPeriyodu = 0.1f; //5

    Coroutine AteşEtmeCoroutine;

    float XDüzlemiMinimumSınır; //3
    float XDüzlemiMaxSınır; 
    float YDüzlemiMinimumSınır; 
    float YDüzlemiMaxSınır;
    
    void Start()
    {
        HareketSınırlarıBelirle(); //3
    }

    void Update()
    {
        HareketEt();//1
        AteşEt();//4
    }

    private void HareketEt() //1 2 3
    {
        var DeltaX = Input.GetAxis("Horizontal") * Time.deltaTime * HareketHızı; //2
        var DeltaY = Input.GetAxis("Vertical") * Time.deltaTime * HareketHızı; //2

        var YeniXPozisyonu = Mathf.Clamp(transform.position.x + DeltaX, //2
                                         XDüzlemiMinimumSınır, XDüzlemiMaxSınır); //3

        transform.position = new Vector2(YeniXPozisyonu, transform.position.y);

        var YeniYPozisyonu = Mathf.Clamp(transform.position.y + DeltaY, //2
                                         YDüzlemiMinimumSınır,YDüzlemiMaxSınır); //3

        transform.position = new Vector2(transform.position.x, YeniYPozisyonu);
    }
    private void HareketSınırlarıBelirle() //3
    {
        Camera OyunKamerası = Camera.main;

        XDüzlemiMinimumSınır = OyunKamerası.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + Padding;
        XDüzlemiMaxSınır = OyunKamerası.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - Padding;
        YDüzlemiMinimumSınır = OyunKamerası.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + Padding;
        YDüzlemiMaxSınır = OyunKamerası.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - Padding;
    }
    private void AteşEt()//4 5
    {
        if (Input.GetButtonDown("Fire1"))
        {
            #region Tek Seferde
            /* GameObject Lazer = Instantiate(LazerPrefab, transform.position, Quaternion.identity)
                                             as GameObject;

             Lazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, LazerHızı);*/
            #endregion 

           AteşEtmeCoroutine = StartCoroutine(DevamlıAteşEt()); //5
        }
        if(Input.GetButtonUp("Fire1")) //5
        {
            //StopAllCoroutines();
            StopCoroutine(AteşEtmeCoroutine);
        }
    }
    IEnumerator DevamlıAteşEt() //5
    {
        while(true)
        {
            GameObject Lazer = Instantiate(LazerPrefab, transform.position, Quaternion.identity)
                        as GameObject;



            Lazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, LazerHızı);
            AudioSource.PlayClipAtPoint(OyuncuAtesEtmeSFX, Camera.main.transform.position, OyuncuAtesEtmeSFXSesYuksekligi);

            yield return new WaitForSeconds(AteşPeriyodu);
        }
    }
    private void OnTriggerEnter2D(Collider2D CarpismaAnı) //13
    {
        HasarVerici HasarVerici1 = CarpismaAnı.gameObject.GetComponent<HasarVerici>(); 

        if(!HasarVerici1) //14
        {
            return;
        }

        VurulmaAnı(HasarVerici1); 
    }
    private void VurulmaAnı(HasarVerici HasarVerici1) //13
    {
        OyuncuCanı -= HasarVerici1.HasarAl();
        HasarVerici1.HasarVer(); //14
        if (OyuncuCanı <= 0)
        {
            OyuncuPatlamaAni();
        }
    }

    private void OyuncuPatlamaAni()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(OyuncuPatlamaSFX, Camera.main.transform.position, OyuncuPatlamaSFXSesYuksekligi);
        FindObjectOfType<Sahne>().BitisSahnesiniYukle();
    }

    public int CanGonder()
    {
        return OyuncuCanı;
    }
}
