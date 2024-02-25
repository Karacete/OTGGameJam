using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMove;
    private Rigidbody2D rb;
    [SerializeField]
    private int walkSpeed;
    [SerializeField]
    private int jumpSpeed;
    private SpriteRenderer sr;
    private bool isJump;
    [SerializeField]
    private AudioSource meow;
    [SerializeField]
    private AudioSource catPurring;
    private float catDistance;
    private GameObject target;
    [SerializeField]
    private GameObject interact;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        target = GameObject.FindWithTag("Hedef");
        sr.flipX = false;
        isJump = false;
    }
    private void FixedUpdate()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(horizontalMove * Time.deltaTime * walkSpeed, rb.velocity.y,0);
    }
    void Update()
    {
        catDistance = Vector2.Distance(gameObject.transform.position, target.transform.position);
        
        catchMovement();
        
        if (Input.GetKeyDown(KeyCode.Space) && !isJump )
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
            animator.Play("CatJump01");
            isJump = true;
        }
        if (Input.GetKey(KeyCode.M) && (!meow.isPlaying && !catPurring.isPlaying))
        {
            meow.Play();
        }
        if (Input.GetKey(KeyCode.R) && (!catPurring.isPlaying && !meow.isPlaying))
        {
            catPurring.Play();
        }
        if (Input.GetKey(KeyCode.S))
        {
            //oturma
        }
        if (catDistance < 2)
        {
            interact.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (catDistance >= 2)
            interact.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
            animator.SetBool("isOnGround", true);
        }     
        if (collision.gameObject.CompareTag("Next"))
        {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                animator.SetBool("isOnGround", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isOnGround", false);
            isJump = true;
        }
    }
    private void catchMovement()
    {
        if (horizontalMove > 0)
        {
            sr.flipX = false;
            // animator.Play("CatWalking");
            animator.SetBool("isMoving", true);
        }
             
        else if (Input.GetKey(KeyCode.A))
        {
            sr.flipX = true;
            animator.SetBool("isMoving", true);
        }
        else    
            animator.SetBool("isMoving",false);
    }
}
