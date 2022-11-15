using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{

    [Header("Info")]
    public int id;
    private int curAttackerId;

    [Header("Stats")]
    public int level;
    public float curXp;
    public float xpTillNextLVL;
    public float curHp;
    public float maxHp;
    public int gold;
    

    [Header("Skills")]


    





    public bool dead;

    [Header("Components")]
    public Rigidbody rig;
    public Player photonPlayer;
    public Camera cam;


    [PunRPC]
    public void Initialize(Player player)
    {
        id = player.ActorNumber;
        photonPlayer = player;

        GameManagerJoute.instance.players[id - 1] = this;

        // is this not our local player?
        if (!photonView.IsMine)
        {
            GetComponentInChildren<Camera>().gameObject.SetActive(false);
            //rig.isKinematic = true;
        }
        else
        {
            //mC = GetComponent<MovementController>();
            //GameUI.instance.Initialize(this);
        }
    }

    void Update()
    {
        // if this isn't our local player or we're dead - return
        if (!photonView.IsMine || dead)
            return;


    }


}
