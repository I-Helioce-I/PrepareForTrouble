using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class LaboPlayerController : MonoBehaviourPun
{

    public Vector3 newPosition;

    public GameObject graphics;
    public MovementController mC;

    [Header("Stats")]
    public float speed;
    public float walkRange;


    [Header("Info")]
    public int id;
    private int curAttackerId;

    [Header("Stats")]
    public float moveSpeed;
    public float jumpForce;
    public int curHp;
    public int maxHp;
    public int kills;
    public bool dead;

    [Header("Components")]
    public Rigidbody rig;
    public Player photonPlayer;
    public MeshRenderer mr;
    public Camera cam;


    //[PunRPC]
    //public void Initialize(Player player)
    //{
    //    id = player.ActorNumber;
    //    photonPlayer = player;

    //    GameManagerJoute.instance.players[id - 1] = this;

    //    // is this not our local player?
    //    if (!photonView.IsMine)
    //    {
    //        GetComponentInChildren<Camera>().gameObject.SetActive(false);
    //        //rig.isKinematic = true;
    //    }
    //    else
    //    {
    //        mC = GetComponent<MovementController>();
    //        //GameUI.instance.Initialize(this);
    //    }
    //}

    public void Start()
    {
        mC = GetComponent<MovementController>();
        newPosition = this.transform.position;
    }

    void Update()
    {
        //// if this isn't our local player or we're dead - return
        //if (!photonView.IsMine || dead)
        //    return;

        Move();

    }

    void Move()
    {
        bool rMB = Input.GetKeyDown(KeyCode.Mouse1);

        if (rMB)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Ground")
            {
                newPosition = hit.point;
            }
        }

        if (Vector3.Distance(newPosition, this.transform.position) > walkRange)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, newPosition, speed * Time.deltaTime);
            Quaternion tranRot = Quaternion.LookRotation(newPosition - this.transform.position, Vector3.up);
            graphics.transform.rotation = Quaternion.Slerp(tranRot, graphics.transform.rotation, 0.7f);
        }
    }


}
