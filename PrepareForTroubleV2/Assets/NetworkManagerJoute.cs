using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class NetworkManagerJoute : MonoBehaviourPunCallbacks
{
    public const string GAME_MODE_PROP_KEY = "joute";

    public List<int> blueTeam, redTeam;
    public byte maxPlayers;
    public string chara;
    public bool locked = false;

    // instance
    public static NetworkManagerJoute instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }


    #region JoinOrCreateRoom
    public void JoinOrCreateRandomJoute()
    {
        PhotonNetwork.JoinRandomRoom();
    }



    public override void OnJoinedRoom()
    {
        MainMenu.instance.SetScreen(MainMenu.instance.panels[3]);

        chara = null;

        CheckTeam();

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    private void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayers;
        PhotonNetwork.CreateRoom("Joute" + Random.Range(0,10000), roomOptions, null);
        Debug.Log("Room created");
    }

    

    [PunRPC]
    public void CheckTeam()
    {
        int teamId = Random.Range(0, 2);

        Debug.Log(teamId);

        if (teamId == 0)
        {
            if (blueTeam.Count == PhotonNetwork.CurrentRoom.MaxPlayers / 2)
            {
                CheckTeam();
            }
            else
            {
                photonView.RPC("AddTeamBlue", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer);
            }

        }

        if (teamId == 1)
        {
            if (redTeam.Count == PhotonNetwork.CurrentRoom.MaxPlayers / 2)
            {
                CheckTeam();
            }
            else
            {
                photonView.RPC("AddTeamRed", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer);
            }

        }
    }



    [PunRPC]
    public void AddTeamBlue(Player playerToAdd)
    {
        Debug.Log("Add" + playerToAdd.ActorNumber);
        blueTeam.Add(playerToAdd.ActorNumber);
    }

    [PunRPC]
    public void AddTeamRed(Player playerToAdd)
    {
        Debug.Log("Add" + playerToAdd.ActorNumber);
        redTeam.Add(playerToAdd.ActorNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    #endregion JoinOrCreateRoom

    // changes the scene through Photon's system
    [PunRPC]
    public void ChangeScene()
    {
        PhotonNetwork.LoadLevel(4);
    }

    [PunRPC]
    public void LaunchSelection()
    {
        MainMenu.instance.SetScreen(MainMenu.instance.panels[3]);

        StartCoroutine(LaunchGameCoroutine());
    }

    public IEnumerator LaunchGameCoroutine()
    {
        yield return new WaitForSeconds(10);

        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("LaunchGame", RpcTarget.All);
        }
    }

    [PunRPC]
    public void LaunchGame()
    {
        PhotonNetwork.LoadLevel(4);
    }

    #region CharaSelection

    public void CheckSelection(string buttonToCheck)
    {
        if (chara != null)
        {
            photonView.RPC("ClearChara", RpcTarget.All, chara);

        }

        chara = buttonToCheck;

        //foreach (CharaSelectionButton button in MainMenu.instance.charaSelectionButton)
        //{
        //    if (buttonToCheck == button.pokémonName)
        //    {
        //        photonView.RPC("Select", RpcTarget.All, chara);
        //    }
        //}
    }

    [PunRPC]
    public void Select(string buttonToCheck)
    {
        //foreach (CharaSelectionButton button in MainMenu.instance.charaSelectionButton)
        //{
        //    if (buttonToCheck == button.pokémonName)
        //    {
        //        button.gameObject.GetComponent<Button>().interactable = false;
        //    }
        //}
    }

    [PunRPC]
    public void ClearChara(string buttonToCheck)
    {
        //foreach (CharaSelectionButton button in MainMenu.instance.charaSelectionButton)
        //{
        //    if (button.pokémonName == buttonToCheck)
        //    {
        //        button.gameObject.GetComponent<Button>().interactable = true;
        //    }

        //}
    }

    #endregion CharaSelection

}