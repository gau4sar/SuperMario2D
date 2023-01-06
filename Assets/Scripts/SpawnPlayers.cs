using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    PhotonView pv;
    public GameObject playerPrefab;
    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    private void Start()
    {
        
            Vector2 randomPosition = new Vector2(-10, 10);
            PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
   
    }
}
