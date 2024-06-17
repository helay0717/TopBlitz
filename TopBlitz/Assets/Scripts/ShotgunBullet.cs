using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    public float speed = 8f;
    public int damage = 15;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void SetVelocity(Vector3 direction)
    {
        if (rb != null)
        {
            // Rigidbody를 사용하여 탄환에 속도를 부여합니다.
            rb.velocity = direction.normalized * speed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // TODO: 충돌 처리 로직
        PlayerMovement dummy = other.GetComponent<PlayerMovement>();
        if (dummy != null)
        {
            dummy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}