﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotategGun : MonoBehaviour
{
    public GrapplingGun grappling;

    private Quaternion desiredRotation;
    private float rotationSpeed = 5f;


    void Update()
    {
        if (!grappling.IsGrappling())
        {



            desiredRotation = transform.parent.rotation;
        }
        else
        {
            desiredRotation = Quaternion.LookRotation(grappling.GetGrapplingPoint() - transform.position);

        }
        transform.rotation = Quaternion.Lerp(a: transform.rotation, b: desiredRotation, t: Time.deltaTime * rotationSpeed);




    }
}

