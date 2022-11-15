using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class LoginMenu : MonoBehaviourPunCallbacks, ILobbyCallbacks
{
    [Header("Screens")]
    public GameObject loginPanel;
    public GameObject registerPanel;
    public GameObject mainMenuPanel;
    public GameObject loadingPanel;
    public GameObject selectionPanel;


    [Header("Lobby")]
    public TextMeshProUGUI connectionState;
    public TextMeshProUGUI roomPlayersInfos;
    public Button soloButton;
    public Button hardStart;


    void Start()
    {
        // enable the cursor since we hide it when we play the game
        Cursor.lockState = CursorLockMode.None;

        // are we in a game?
        if (PhotonNetwork.InRoom)
        {
            //// go to the lobby
            //SetScreen(loadingPanel);

            // make the room visible again
            PhotonNetwork.CurrentRoom.IsVisible = true;
            PhotonNetwork.CurrentRoom.IsOpen = true;
        }

    }
    public void OnClickRegister()
    {
        SetScreen(registerPanel);
    }

    public void OnClickLogin()
    {
        SetScreen(loginPanel);
    }
    // changes the currently visible screen
    public void SetScreen(GameObject screen)
    {
        // disable all other screens
        loginPanel.SetActive(false);
        registerPanel.SetActive(false);
        //mainMenuPanel.SetActive(false);
        //loadingPanel.SetActive(false);

        // activate the requested screen
        screen.SetActive(true);

    }


    



}