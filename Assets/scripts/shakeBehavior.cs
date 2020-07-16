using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeBehavior : MonoBehaviour
{

    private Transform transForm;

    private float shakeDuration = 0f;

    private float shakeMagnitude = 0.3f;


    private float dampingSpeed = .5f;

    Vector3 initialPos;

    public gun gunRef;

    public float shakelength = 2f;

    public blackboard bb;

    private float nextTimeToFire;

    void Awake()
    {
        if(transForm == null)
        {
            transForm = GetComponent(typeof(Transform)) as Transform;
        }

    }

    private void OnEnable()
    {
        initialPos = transform.localPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanShoot()){

            switch (bb.weaponSwitchref.selectedWeapon)
            {
                case 0:
                    nextTimeToFire = Time.time + 1f / bb.akRef.fireRate;

                    Triggershake();

                    break;

                case 1:


                    nextTimeToFire = Time.time + 1f / bb.umpRef.fireRate;

                    Triggershake();
                    break;
                case 2:
                    nextTimeToFire = Time.time + 1f / bb.skorpRef.fireRate;

                    Triggershake();
                    break;
            }
        }

        if(shakeDuration > 0)
        {
            transform.localPosition = initialPos + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPos;
        }
    }

    public void Triggershake()
    {
        shakeDuration = shakelength;
    }

    bool CanShoot()
    {

        return Input.GetMouseButton(0) && Time.time >= nextTimeToFire;
    }
}
