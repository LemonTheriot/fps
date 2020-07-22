using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;

    public float speeed;

    Vector3 velocity;

    public float gravity = -9.81f;

    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpheight = 10f;
    private float distToGround;
    public float sprintSpeed = 0.5f;

    public GameObject bulletPrefab;

    public float health = 100f;
        
    CharacterController characterCollider;

    public float crouchHeight = 2f;

    public float regHeight = 4f;


    private void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;

        characterCollider = gameObject.GetComponent<CharacterController>();

        speeed = speed;

        
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            characterCollider.height = crouchHeight;
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            characterCollider.height = regHeight;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speeed * sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speeed;
        }



        if (isGrounded() && velocity.y < 0)
        {
            velocity.y = 0;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }


    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + .3f);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(0);
    }

}
