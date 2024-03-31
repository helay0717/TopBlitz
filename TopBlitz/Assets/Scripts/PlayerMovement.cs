using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동속도 변경 필요 시 값 변경하기

    Rigidbody rb;
    Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // 중력 제거
        rb.useGravity = false;
        mainCamera = Camera.main;
    }

    void Update()
    {
        // 플레이어로부터 입력받기 (WASD)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // 이동 속도 계산
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Rigidbody에 움직임 적용
        rb.MovePosition(transform.position + movement);

        // 마우스 커서의 위치를 받아옴
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // 플레이어가 바라보아야 할 방향을 계산
            Vector3 lookDirection = hit.point - transform.position;
            lookDirection.y = 0f; // 시선 방향을 지면과 평행하게 유지
            if (lookDirection != Vector3.zero)
            {
                // R마우스 커서 방향을 향하도록 플레이어를 회전
                Quaternion rotation = Quaternion.LookRotation(lookDirection);
                rb.MoveRotation(rotation);
            }
        }
    }
}