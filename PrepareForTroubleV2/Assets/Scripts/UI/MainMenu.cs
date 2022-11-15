using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject[] panels;

    public AudioSource bGMusic;

    public TextMeshProUGUI connectionState;

    public static MainMenu instance;

    public void Start()
    {
        SetScreen(panels[0]);
        StartCoroutine(Loading());
        instance = this;
    }

    public void Update()
    {
        connectionState.text = PhotonNetwork.NetworkClientState.ToString();

    }

    public IEnumerator Loading()
    {
        bGMusic.Play();
        yield return new WaitForSeconds(3.75f);

        SetScreen(panels[1]);

        //MainMenu.instance.SetScreen(MainMenu.instance.panels[1]);
    }

    

    public void SetScreen(GameObject panelsToActivate)
    {
        foreach(GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        panelsToActivate.SetActive(true);
    }

    
    public void OnClickTraining()
    {
        SetScreen(panels[2]);
    }

    public void OnCLickLaunchJoute()
    {
        Debug.Log("Joute Clicked");
        NetworkManagerJoute.instance.JoinOrCreateRandomJoute();
    }

    public void OnCLickLaunchTraining()
    {
        Debug.Log("training Clicked");
        NetworkManager.instance.CreateTrainingRoom();
    }

    [PunRPC]
    void UpdateLobbyUI()
    {
        
    }

}
