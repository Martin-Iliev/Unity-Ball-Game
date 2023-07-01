using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 10f;
    public float maxSpeed = 10f;
    public float jumpForce = 5f;
    [HideInInspector]
    public bool isJumping = false;
    [HideInInspector]
    public bool isMoving = false;

    private float xInput;
    private float zInput;

    public AudioSource rolling;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rolling.Play();
    }

    private void Update()
    {
        Inputs();
        Audio();
    }

    private void FixedUpdate()
    {
        Movement();
        LimitMaxSpeed();
    }

    private void Inputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetScene();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void Movement()
    {
        rb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);
    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        isJumping = true;
    }

    private void LimitMaxSpeed()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
    
    private void Audio()
    {
        if (rb.velocity.x > 0.5 || rb.velocity.y > 0.5 || rb.velocity.x < -0.5 || rb.velocity.y < -0.5 && !isJumping && !isMoving)
        {
            rolling.volume = 1;
            isMoving = true;
        }
        
        if (rb.velocity.x < 0.5 && rb.velocity.x > -0.5 && rb.velocity.y < 0.5 && rb.velocity.y > -0.5 && isMoving || isJumping)
        {
            rolling.volume = 0;
            isMoving = false;
        }
    }

    private void resetScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fail"))
        {
            resetScene();
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
