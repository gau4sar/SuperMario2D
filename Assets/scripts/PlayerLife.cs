using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PlayerLife : MonoBehaviour
{
    Animator playerAnim;
    Rigidbody2D rb;
    public PhotonView pv;
    public GameObject playerPrefab;
    [SerializeField] Transform spawnPoint;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource restartSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (pv.IsMine && collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        deathSoundEffect.Play();
        playerAnim.SetTrigger("death");
        Debug.Log("Player is dead");
        //PhotonNetwork.Destroy(playerPrefab);
    }

    private void Restart()
    {
        Debug.Log("Restart player called");
        restartSoundEffect.Play();
        transform.position = new Vector2(-10, 10);
        int falling = 3;
        playerAnim.SetInteger("state", falling);
        rb.bodyType = RigidbodyType2D.Dynamic;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
