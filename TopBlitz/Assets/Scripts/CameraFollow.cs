<<<<<<< HEAD
=======
using System.Collections;
using System.Collections.Generic;
>>>>>>> Joon
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
<<<<<<< HEAD
    private Transform target; // 따라갈 대상
    public float fixedY; // 고정할 Y 좌표
    public float smoothSpeed = 0.125f; // 부드러운 이동을 위한 속도

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x, fixedY, target.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
=======
    public Transform target; // 플레이어의 Transform
    public Vector3 offset = new Vector3(0,15,0); // 플레이어와 카메라 사이의 오프셋
    private void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset; // 플레이어 뒤에서 일정 거리를 유지하며 따라감

            // 카메라를 플레이어가 바라보는 방향으로 회전하게 하고 싶지 않기 때문에,
            // 카메라의 회전은 여기서 조정하지 않습니다.
        }
    }
}
>>>>>>> Joon
