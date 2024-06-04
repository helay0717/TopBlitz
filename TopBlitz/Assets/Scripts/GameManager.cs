using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤 인스턴스
    public int currentCharacterID; // 현재 제어 중인 캐릭터의 ID
    public CameraFollow cameraFollow; // CameraFollow 스크립트 참조

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 게임 매니저 오브젝트를 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeCharacter(int characterID)
    {
        currentCharacterID = characterID;
        Character[] characters = FindObjectsOfType<Character>();
        foreach (Character character in characters)
        {
            if (character.characterID == characterID)
            {
                cameraFollow.SetTarget(character.transform);
                break;
            }
        }
    }
}