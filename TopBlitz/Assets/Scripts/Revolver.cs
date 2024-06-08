using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Weapon
{

    public override void Fire()
    {
        Vector3 fireDirection = transform.forward;

        if (projectilePrefab != null && firePoint != null)
        {
            // 발사체 프리팹을 인스턴스화하여 발사 위치에 생성합니다.
            GameObject bulletInstance = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(fireDirection));

            // 발사체의 Bullet 스크립트로 속도 및 방향을 설정합니다.
            // 이 스크립트의 SetVelocity 메서드가 이전에 정의되어 있어야 합니다.
            RevolverBullet bulletScript = bulletInstance.GetComponent<RevolverBullet>();
            if (bulletScript != null)
            {
                bulletScript.SetVelocity(fireDirection);
            }
            // 발사 후 다음 발사 가능 시간을 업데이트합니다.
            UpdateFireTime();
        }
    }
}
