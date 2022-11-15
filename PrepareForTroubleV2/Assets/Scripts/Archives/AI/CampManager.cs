using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class CampManager : MonoBehaviourPun
{
    public Transform[] spawnPositions;
    public GameObject[] enemyPrefab;

    public void TriggerCamp()
    {
        int timeCamp = 0;
        foreach(GameObject enemy in enemyPrefab)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                SpawnEnemy(timeCamp);
            }
            timeCamp++;
        }
    }

    public void SpawnEnemy(int id)
    {
        GameObject pokemonOBJ = PhotonNetwork.Instantiate(enemyPrefab[id].name, spawnPositions[id].position, spawnPositions[id].rotation);
        pokemonOBJ.transform.parent = spawnPositions[id].transform;
    }
}
