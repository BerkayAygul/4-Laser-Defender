using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sahne : MonoBehaviour
{
    [SerializeField] float SahneYuklerkenkiBeklemeSuresi = 2f;

    public void MenuSahnesiniYukle()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OyunSahnesiniYukle()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<OyunOturumu>().OyunuBastanBaslat();
    }

    public void BitisSahnesiniYukle()
    {
        StartCoroutine(BekleVeYukle());
    }

    IEnumerator BekleVeYukle()
    {
        yield return new WaitForSeconds(SahneYuklerkenkiBeklemeSuresi);
        SceneManager.LoadScene("GameOver");
    }

    public void OyundanCik()
    {
        Application.Quit();
    }


}
