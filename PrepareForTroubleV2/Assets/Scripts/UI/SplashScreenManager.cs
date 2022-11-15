using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    public AudioSource music;

    public GameObject splashScreenPannel;
    public GameObject loginPannel;

    [Header("Logo")]
    public GameObject bG;
    public GameObject myName;
    public GameObject[] logo;
    public GameObject gameSup;
    public GameObject gameLogo;

    [Header("Timers")]
    public float timerBeforeMe;
    public float timerBeforeGameSup;
    public float timerBeforeLogo;
    public float timerBeforeGameLogo;
    public float timerBeforeEndPannel;

    public void Start()
    {

        

        StartCoroutine(SplashScreen());
    }

    public IEnumerator SplashScreen()
    {
        music.Play();
        yield return new WaitForSeconds(timerBeforeMe);

        myName.SetActive(true);

        yield return new WaitForSeconds(timerBeforeGameSup);

        myName.SetActive(false);
        gameSup.SetActive(true);

        yield return new WaitForSeconds(timerBeforeLogo);

        gameSup.SetActive(false);

        foreach(GameObject image in logo)
        {
            image.SetActive(true);
        }
        
        yield return new WaitForSeconds(timerBeforeGameLogo);

        foreach (GameObject image in logo)
        {
            image.SetActive(false);
        }

        gameLogo.SetActive(true);

        yield return new WaitForSeconds(timerBeforeEndPannel);

        splashScreenPannel.SetActive(false);
        loginPannel.SetActive(true);

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(SplashScreen());

            splashScreenPannel.SetActive(false);

            loginPannel.SetActive(true);
        }
    }
}
