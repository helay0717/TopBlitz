using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동속도 변경 필요 시 값 변경하기
    public int characterID; // 각 캐릭터의 고유한 식별자
    public float maxHealth = 200;
    private float currentHealth;
    public Slider healthBar; // 체력바 UI

    Rigidbody rb;
    Camera mainCamera;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // 중력
        rb.useGravity = true;
        // 캐릭터 떨어지는 속도 조절
        rb.AddForce(Vector3.down * 10f, ForceMode.Impulse);
        mainCamera = Camera.main;

        // Animator 컴포넌트 가져오기
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        // 현재 캐릭터의 ID와 입력한 ID가 같으면 해당 캐릭터를 제어
        if (GameManager.instance.currentCharacterID == characterID)
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

            if (horizontalInput == 0 && verticalInput == 0)
            {
                animator.SetBool("isMoving", false);
            }
            else
            {
                animator.SetBool("isMoving", true);
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthBar();

        if (currentHealth == 0)
        {
            Destroy(gameObject); // 체력이 0이 되면 더미를 파괴
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth;
        }
    }
}