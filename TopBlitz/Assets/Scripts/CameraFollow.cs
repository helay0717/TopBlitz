using UnityEngine;

public class CameraFollow : MonoBehaviour
{
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