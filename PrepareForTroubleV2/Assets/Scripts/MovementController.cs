using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MovementController : MonoBehaviour
{
    private PlayerController pC;

    [Header("Stats")]
    public float moveSpeed;

    [Header("Components")]
    public Rigidbody rig;


    public void Start()
    {
        pC = GetComponent<PlayerController>();
    }

    public void Update()
    {
        Move();

        
    }

    

    public void Move()
    {
        // get the input axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // calculate a direction relative to where we're facing
        Vector3 dir = (pC.gameObject.transform.forward * z + pC.gameObject.transform.right * x) * moveSpeed;
        dir.y = rig.velocity.y;

        // set that as our velocity
        rig.velocity = dir;
    }
}
