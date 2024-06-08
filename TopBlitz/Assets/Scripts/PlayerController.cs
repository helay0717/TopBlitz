using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 700.0f;
    public float playerHp = 200.0f;
    private GameObject playerHpBar;

    private void Start()
    {
        playerHpBar = GameObject.Find("Canvas/PlayerHpBar");
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }
    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal"); // "a" 와 "d" 에 대응
        float vertical = Input.GetAxis("Vertical"); // "w" 와 "s" 에 대응

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        playerHpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, -0.9f));
    }

    private void RotatePlayer()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.y; // 카메라와 같은 높이 설정
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 direction = worldPos - transform.position;
        direction.y = 0.0f; // 수평 회전만

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
