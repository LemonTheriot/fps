using System;
using UnityEngine;
using System.Collections.Generic;

public class GrapplingGun : MonoBehaviour
{

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public Transform gunTip, camerapos, player;
    public float maxDistance;
    private SpringJoint joint;

    [Space]
    [Header("Spiring Joint Values")]
    [SerializeField]private float desiredMaxDistanceMod = .8f;
    [SerializeField] private float desiredMinDistanceMod = .25f;
    [SerializeField] private float desiredSpringValue = 4.5f;
    [SerializeField] private float desiredDampeningValue = 7f;
    [SerializeField] private float desiredMassScale = 4.5f;

    private int groundMask;

    private List<SpringJoint> listSpringJoints = new List<SpringJoint>();



    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        groundMask = LayerMask.GetMask("ground");
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            StartGrapple();

        }

        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }

    }

    void LateUpdate()
    {
        DrawRope();
    }



    private void StartGrapple()
    {
        RaycastHit hit;
        if(Physics.Raycast(camerapos.position, camerapos.forward, out hit, maxDistance, groundMask))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * desiredMaxDistanceMod;
            joint.minDistance = distanceFromPoint * desiredMinDistanceMod;

            joint.spring = desiredSpringValue;
            joint.damper = desiredDampeningValue;
            joint.massScale = desiredMassScale;

            listSpringJoints.Add(joint);

            lr.positionCount = 2;
        }

    }
    void DrawRope()
    {
        if (!joint) return;

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, grapplePoint);

    }

    private void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);

        foreach (SpringJoint j in listSpringJoints)
            Destroy(j);

      
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplingPoint()
    {
        return grapplePoint;
    }
}