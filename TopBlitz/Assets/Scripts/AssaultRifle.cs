using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AssaultRifle : Weapon
{
    // 총알 간의 간격 조절을 위한 변수
    public float bulletSpreadAngle = 5f;
    // 각 총알 사이의 딜레이
    public float shotDelay = 0.1f;

    private bool isFiring = false; // 현재 발사 중인지 여부를 나타내는 플래그

    public override void Fire()
    {
        if (!isFiring) // 현재 발사 중이 아니라면 발사 가능
        {
            isFiring = true;
            StartCoroutine(FireBurst());
        }
    }

    IEnumerator FireBurst()
    {
        Vector3 fireDirection = transform.forward;

        for (int i = 0; i < 3; i++)
        {
            Vector3 spread = Quaternion.Euler(0, Random.Range(-bulletSpreadAngle, bulletSpreadAngle), 0) * fireDirection;

            // 총알 발사
            FireBullet(spread);

            yield return new WaitForSeconds(shotDelay);
        }

        isFiring = false; // 발사가 끝났음을 나타냄
        UpdateFireTime(); // 다음 발사 가능 시간 업데이트
    }

    void FireBullet(Vector3 direction)
    {
        // 발사체 프리팹을 인스턴스화하여 발사 위치에 생성합니다.
        GameObject bulletInstance = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));

        // 발사체의 Bullet 스크립트로 속도 및 방향을 설정합니다.
        // 이 스크립트의 SetVelocity 메서드가 이전에 정의되어 있어야 합니다.
        AssaultRifleBullet bulletScript = bulletInstance.GetComponent<AssaultRifleBullet>();
        if (bulletScript != null)
        {
            bulletScript.SetVelocity(direction);
        }
    }
}