//using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] characterPrefabs; // 캐릭터 프리팹 배열
    public Transform[] redTeamSpawnPoints; // 레드 팀 스폰 지점 배열
    public Transform[] blueTeamSpawnPoints; // 블루 팀 스폰 지점 배열
    public CameraFollow cameraFollow; // 카메라 팔로우 스크립트

    private WeaponManager weaponManager; // WeaponManager 참조

    void Start()
    {
        int selectedCharacterID = PlayerPrefs.GetInt("SelectedCharacterID", 0);

        CreateCharacter(selectedCharacterID);

        //// TeamManager가 초기화되었는지 확인
        //if (TeamManager.instance == null)
        //{
        //    Debug.LogError("TeamManager instance is null. Make sure it is initialized correctly.");
        //    return;
        //}

        // 선택된 캐릭터 ID를 Photon Custom Properties에서 가져옴
        //object selectedCharacterIDObj;
        //if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue("SelectedCharacterID", out selectedCharacterIDObj))
        //{
        //    CreateCharacter((int)selectedCharacterIDObj);
        //}
        //else
        //{
        //    Debug.LogError("SelectedCharacterID not found in CustomProperties.");
        //}
    }

    void CreateCharacter(int selectedCharacterID)
    {
        // 플레이어 팀 정보를 Photon Custom Properties에서 가져옴
        //Team playerTeam = (Team)System.Enum.Parse(typeof(Team), PhotonNetwork.LocalPlayer.CustomProperties["PlayerTeam"].ToString());

        // 진영에 따른 스폰 지점을 가져옴
        Transform spawnPoint = GetSpawnPoint(/*playerTeam*/);

        // 선택된 캐릭터 프리팹을 스폰 지점에 네트워크 상에서 생성
        GameObject character = Instantiate(characterPrefabs[selectedCharacterID], spawnPoint.position, spawnPoint.rotation);

        // 캐릭터의 색상을 진영에 따라 변경
        //if (TeamManager.instance != null)
        //{
        //    ChangeCharacterColor(character, playerTeam);
        //}
        //else
        //{
        //    Debug.LogError("TeamManager instance is null.");
        //}

        // 선택된 캐릭터의 WeaponManager를 설정
        weaponManager = character.GetComponent<WeaponManager>();
        switch (selectedCharacterID)
        {
            case 0:
                weaponManager.ActivateRevolver();
                break;
            case 1:
                weaponManager.ActivateAssault();
                break;
            case 2:
                weaponManager.ActivateSniper();
                break;
            case 3:
                weaponManager.ActivateShotgun();
                break;
        }

        // 카메라가 캐릭터를 따라가도록 설정
        if (cameraFollow != null)
        {
            cameraFollow.SetTarget(character.transform);
        }
        else
        {
            Debug.LogWarning("CameraFollow is not assigned in GameManager.");
        }
    }

    private Transform GetSpawnPoint(/*Team team*/)
    {
        //// 진영에 따라 적절한 스폰 지점을 반환
        //if (team == Team.Red)
        //{
        //    return redTeamSpawnPoints[Random.Range(0, redTeamSpawnPoints.Length)];
        //}
        //else
        //{
            return blueTeamSpawnPoints[Random.Range(0, blueTeamSpawnPoints.Length)];
        //}
    }

    //private void ChangeCharacterColor(GameObject character, Team team)
    //{
    //    if (character == null)
    //    {
    //        Debug.LogError("Character GameObject is null.");
    //        return;
    //    }

    //    Renderer[] renderers = character.GetComponentsInChildren<Renderer>();

    //    foreach (Renderer renderer in renderers)
    //    {
    //        // Renderer 컴포넌트가 있는 경우에만 색상 변경
    //        renderer.material.color = TeamManager.instance.GetTeamColor(team);
    //    }
    //}
}