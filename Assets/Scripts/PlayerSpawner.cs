using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject playerPrefab;
    public Vector2 spawnRange;
    
    void Start(){

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRange.x,spawnRange.x),0,Random.Range(-spawnRange.y,spawnRange.y));

        PhotonNetwork.Instantiate(playerPrefab.name,spawnPos,Quaternion.identity);

    }

}
