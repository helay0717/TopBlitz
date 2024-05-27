using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤 인스턴스

    public int currentCharacterID = 1; // 현재 제어 중인 캐릭터의 ID

    private void Awake()
    {
        // 싱글톤 인스턴스 설정
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 캐릭터를 변경하는 메서드
    public void ChangeCharacter(int newCharacterID)
    {
        currentCharacterID = newCharacterID;
    }
}