using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBehavior : MonoBehaviour
{
    public float range = 10f;
    public float fireRate;
    public float fireTimer;
    public GameObject player;
    public GameObject bulletPrefab;
    public float bulletForce;

    public Transform barrelTip;
    

    private void Update()
    {
        if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) < range)
        {
            transform.LookAt(player.transform.position);

            if(fireTimer >= fireRate)
            {

                Shoot();
                fireTimer = 0;

            }

        }

        fireTimer += Time.deltaTime;

    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = barrelTip.position;
        bullet.transform.rotation = barrelTip.rotation;

        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce, ForceMode.Impulse);
    }

    private void Shoot(GameObject target)
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = barrelTip.position;
        bullet.transform.LookAt(target.transform.position);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletForce);
    }
}
