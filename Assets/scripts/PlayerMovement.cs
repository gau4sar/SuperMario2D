using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerMovement : MonoBehaviour
{

    public PhotonView pv;
    Rigidbody2D rigidBody;
    SpriteRenderer sprite;
    Animator anim;
    BoxCollider2D boxCollider2D;

    [SerializeField] private LayerMask jumpableGround;
    
    [SerializeField] private GameObject playerCamera;
    
    private float dirX = 0f;
    
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private AudioSource jumpSoundEffect;

    private enum MovementState { idle, running, jumping, falling, death }


    // Start is called before the first frame update
    void Start()
    {//stop assigning controls if this is not the player related to this peer
        pv = GetComponent<PhotonView>();
        if (pv.IsMine)
        {
            Debug.Log("pv.IsMine");
            playerCamera.SetActive(true);
            //Camera.main.gameObject.SetActive(false);
        }
        else
        {
            playerCamera.SetActive(false);
            Debug.Log("pv.Is not Mine");
        }
        Debug.Log("Started");
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {//stop assigning controls if this is not the player related to this peer

        if (pv.IsMine)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            rigidBody.velocity = new Vector2(moveSpeed * dirX, rigidBody.velocity.y);
            UpdateAnimationState();
        }

       
    }

    void UpdateAnimationState()
    {
        MovementState state = MovementState.idle;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpForce, 0);
        }

        if (dirX < 0f)
        {
            sprite.flipX = true;
            state = MovementState.running;
        }
        else if (dirX > 0f)
        {
            sprite.flipX = false;
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        /*bool jumpDetected = rigidBody.velocity.y > .1f;
        bool fallDetected = rigidBody.velocity.y < -.1f;*/

        if (rigidBody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rigidBody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
