using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Weapon
{
    // Delay between shots for the sniper rifle
    public float shotDelay = 1.0f;

    public override void Fire()
    {
        // Check if it's time to fire
        if (CanFire())
        {
            Vector3 fireDirection = transform.forward;

            if (projectilePrefab != null && firePoint != null)
            {
                // Instantiate the projectile prefab and create it at the launch location.
                GameObject bulletInstance = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(fireDirection));

                // Set the speed and direction with the projectile's Bullet script.
                // The SetVelocity method in this script must have been previously defined.
                SniperBullet bulletScript = bulletInstance.GetComponent<SniperBullet>();
                if (bulletScript != null)
                {
                    bulletScript.SetVelocity(fireDirection);
                }

                // After launch, update the next available launch time.
                UpdateFireTime();

                // Apply the delay for the sniper rifle
                StartCoroutine(ApplyShotDelay());
            }
        }
    }

    IEnumerator ApplyShotDelay()
    {
        yield return new WaitForSeconds(shotDelay);
    }
}