using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    public float fireRate = 10f; // 초당 발사 횟수
    private float fireInterval; // 발사 간격
    private float lastFireTime; // 마지막으로 발사한 시간

    // Start is called before the first frame update
    void Start()
    {
        // 발사 간격을 계산합니다 (초당 발사 횟수에 따라).
        fireInterval = 1f / fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어가 마우스 좌클릭을 꾹 누르고 있는지 확인합니다.
        if (Input.GetMouseButton(0) && Time.time > lastFireTime + fireInterval && CanFire())
        {
            Fire();
        }
    }

    public override void Fire()
    {
        Vector3 fireDirection = transform.forward;

        if (projectilePrefab != null && firePoint != null)
        {
            // 발사체 프리팹을 인스턴스화하여 발사 위치에 생성합니다.
            GameObject bulletInstance = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(fireDirection));

            // 발사체의 Bullet 스크립트로 속도 및 방향을 설정합니다.
            // 이 스크립트의 SetVelocity 메서드가 이전에 정의되어 있어야 합니다.
            AssaultRifleBullet bulletScript = bulletInstance.GetComponent<AssaultRifleBullet>();
            if (bulletScript != null)
            {
                bulletScript.SetVelocity(fireDirection);
            }
        }
    }
}
