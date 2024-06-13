using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public int characterID; // 해당 버튼에 연결된 캐릭터의 ID
    public GameObject characterPrefab; // 캐릭터의 프리팹
    public Transform spawnPoint; // 캐릭터 스폰 지점
    public CameraFollow cameraFollow;

    // 클릭한 캐릭터를 추적하기 위한 변수
    private GameObject currentCharacter;
    private WeaponManager weaponManager; // WeaponManager 참조

    void Start()
    {
        // 버튼에 클릭 이벤트 추가
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(SelectCharacter);
    }

    void SelectCharacter()
    {
        // 기존 캐릭터가 있을 경우 제거합니다.
        DestroyCurrentCharacter();

        // 캐릭터를 스폰 지점에 소환합니다.
        SpawnCharacter();    

        // 게임 매니저에 선택된 캐릭터의 ID를 전달하여 캐릭터를 변경합니다.
        GameManager.instance.ChangeCharacter(characterID);

        weaponManager = currentCharacter.GetComponent<WeaponManager>();

        // 새로운 캐릭터의 WeaponManager를 설정합니다.
        if(characterID == 1)
        {
           weaponManager.ActivateRevolver();    
        }
        if (characterID == 2)
        {
            weaponManager.ActivateAssault();
        }
        if (characterID == 3)
        {
            weaponManager.ActivateSniper();
        }
        if (characterID == 4)
        {
            weaponManager.ActivateShotgun();
        }

        // 캐릭터를 따라가도록 카메라 설정
        SetCameraTarget(currentCharacter.transform);
    }

    void SpawnCharacter()
    {
        // 스폰 지점이 정의되지 않았다면, 로그를 출력하고 함수를 종료합니다.
        if (spawnPoint == null)
        {
            Debug.LogWarning("Spawn point is not defined!");
            return;
        }

        // 스폰 지점에 캐릭터를 소환합니다.
        currentCharacter = Instantiate(characterPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void DestroyCurrentCharacter()
    {
        // 기존 캐릭터가 있는 경우 제거합니다.
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }
    } 

    void SetCameraTarget(Transform target)
    {
        // 카메라를 따라가게 할 대상 설정
        cameraFollow.SetTarget(target);
    }
}