using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float lifetime = 5.0f; // 오브젝트가 파괴되기까지의 시간(초)

    void Start()
    {
        // 일정 시간이 지난 후 게임 오브젝트를 파괴합니다.
        Destroy(gameObject, lifetime);
    }
}
