using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public int pelletCount = 8; // 발사될 샷건 탄알의 수
    public float spreadAngle = 30f; // 탄알이 퍼질 수평 각도

    public override void Fire()
    {
        // Weapon 클래스의 CanFire 메서드를 사용하여 발사할 수 있는지 확인합니다.
        if (projectilePrefab != null && firePoint != null && CanFire())
        {
            for (int i = 0; i < pelletCount; i++)
            {
                // 각 탄알을 위한 임의의 분산 각도를 계산합니다. (수평 방향만 고려합니다.)
                Quaternion spreadRotation = Quaternion.Euler(0, Random.Range(-spreadAngle, spreadAngle), 0);

                // 발사체 프리팹을 인스턴스화하여 발사 위치에 생성하고, 방향을 조정합니다.
                GameObject pelletInstance = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation * spreadRotation);

                // 발사체의 Bullet 스크립트로 속도 및 방향을 설정합니다.
                ShotgunBullet pelletScript = pelletInstance.GetComponent<ShotgunBullet>();
                if (pelletScript != null)
                {
                    pelletScript.SetVelocity(pelletInstance.transform.forward);
                }
            }

            // 발사 후 다음 발사 가능 시간을 업데이트합니다.
            UpdateFireTime();
        }
    }
}