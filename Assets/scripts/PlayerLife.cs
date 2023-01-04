using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    Animator playerAnim;
    Rigidbody2D rigidbody2D;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource restartSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        playerAnim.SetTrigger("death");
        rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    private void Restart()
    {
        restartSoundEffect.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
