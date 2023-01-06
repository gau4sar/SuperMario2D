using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using Photon.Pun;

public class CameraController : NetworkBehaviour
{
    public PhotonView pv;
    /*[SerializeField] private Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }*/

    /*public override void OnStartAuthority()
    {
        cameraHolder.SetActive(true);
    }
*/

    public GameObject cameraHolder;
    public Vector3 offset;

    public void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    public void Update()
    {
        if (pv.IsMine && (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2"))
        {
            cameraHolder.transform.position = transform.position + offset;
        }
    }
}
