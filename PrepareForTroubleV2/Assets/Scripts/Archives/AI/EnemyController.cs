using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class EnemyController : MonoBehaviourPun
{
    public EnemyMovement eM;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        eM = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //photonView.RPC("SetTarget", RpcTarget.All, other.gameObject);
            target = other.gameObject;
            Debug.Log("other");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            target = null;
            //photonView.RPC("SetTarget", RpcTarget.All, null);
        }
    }

}