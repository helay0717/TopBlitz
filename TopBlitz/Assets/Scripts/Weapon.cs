using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab; // 사용할 발사체 프리팹
    public Transform firePoint; // 발사 위치
    public float rateOfFire = 1f; // 발사 속도 (초당 발사 횟수)

    private float nextFireTime = 0f; // 다음 발사까지 남은 시간

    // 발사 메서드, 상속받는 클래스에서 구현
    public abstract void Fire();

    // 발사 가능 여부 확인
    protected bool CanFire()
    {
        return Time.time >= nextFireTime;
    }

    // 발사 후 다음 발사까지 시간을 재설정
    protected void UpdateFireTime()
    {
        nextFireTime = Time.time + 1f / rateOfFire;
    }

    // 호출되는 발사 함수
    public void TryFire()
    {
        if (CanFire())
        {
            Fire();
            UpdateFireTime();
        }
    }
}
