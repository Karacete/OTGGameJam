using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class PlayerMovement2 : MonoBehaviour
{
    private float horizontalMove;
    private Rigidbody2D rb;
    [SerializeField]
    public int walkSpeed;
    public int jumpSpeed;
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
        walkSpeed = 100;
        jumpSpeed = 250;
        isJump = false;
    }
    private void FixedUpdate()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(horizontalMove * Time.deltaTime * walkSpeed, rb.velocity.y, 0);
    }
    void Update()
    {
        catDistance = Vector2.Distance(gameObject.transform.position, target.transform.position);
        if (Input.GetKey(KeyCode.D))
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
            animator.SetBool("isMoving", false);

        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
            Debug.Log(jumpSpeed);
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
        if (catDistance < 5)
        {
            interact.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (catDistance >= 5)
            interact.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
            if (collision.gameObject.CompareTag("Next"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                animator.SetBool("isOnGround", true);
            }
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
}
