using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouch : MonoBehaviour
{
    Transform capsuleHeight;

    void Start()
    {
        capsuleHeight = gameObject.GetComponent<Transform>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            transform.localScale = new Vector3(2, 1, 2);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
    }
}
