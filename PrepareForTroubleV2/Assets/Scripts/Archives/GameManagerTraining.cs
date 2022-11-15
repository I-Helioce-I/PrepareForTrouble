using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class GameManagerTraining : MonoBehaviourPun
{
    public static GameManagerTraining instance;

    [Header("Players")]
    public string playerPrefabLocation;
    public PlayerController[] players;
    public Transform spawnPoints;
    public int alivePlayers;
    public int playersInGame;

    [Header("Choice")]

    public int actualRound;

    public UITraining ui;
    public TerrainManagerTraining tMT;

    void Awake()
    {
        instance = this;
        //StartCoroutine(StartGame());
    }

    void Start()
    {
        
        players = new PlayerController[PhotonNetwork.PlayerList.Length];
        alivePlayers = players.Length;

        photonView.RPC("ImInGame", RpcTarget.AllBuffered);
    }

    #region Initialization
    [PunRPC]
    void ImInGame()
    {
        playersInGame++;

        if (PhotonNetwork.IsMasterClient && playersInGame == PhotonNetwork.PlayerList.Length)
        {
            photonView.RPC("SpawnPlayer", RpcTarget.All);

        }

    }

    [PunRPC]
    void SpawnPlayer()
    {
        GameObject playerObj = PhotonNetwork.Instantiate(playerPrefabLocation, spawnPoints.position, Quaternion.identity);

        // initialize the player for all other players
        playerObj.GetComponent<PlayerController>().photonView.RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }

    public PlayerController GetPlayer(int playerId)
    {
        foreach (PlayerController player in players)
        {
            if (player != null && player.id == playerId)
                return player;
        }

        return null;
    }

    public PlayerController GetPlayer(GameObject playerObject)
    {
        foreach (PlayerController player in players)
        {
            if (player != null && player.gameObject == playerObject)
                return player;
        }

        return null;
    }

    #endregion Initialization

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Loaded");
    }

    // Update is called once per frame
    void Update()
    {
        ui.UpdateTimer();
    }

    public void SetRoung(int round)
    {
        actualRound = round++;
        CheckRound();
    }

    public void CheckRound()
    {
        if(actualRound == 0)
        {
            StartCoroutine(SelectionRound());
        }
    }
    
    IEnumerator SelectionRound()
    {
        ui.SetTimer(15);

        yield return new WaitForSeconds(3);

    }

    #region ChoiceTurn

    public void SetUpChoice()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            foreach(PlayerController player in players)
            {

            }

        }
    }

    #endregion ChoiceTurn
}
