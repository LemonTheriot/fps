using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float movespeed = 10f;

    public float jumpforce = 30f;

    private Rigidbody rb;

    public float maxspeed = .6f;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)){
            transform.position += transform.forward * movespeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * movespeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * movespeed;
        }

        if (Input.GetKey(KeyCode.S))
        {

            //transform.position += -transform.forward * movespeed;
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.VelocityChange);
        }
    }
}
