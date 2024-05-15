using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MAtchStart : MonoBehaviour
{
    public GameObject weaponPanel; // 무기 선택 패널
    public Button pistolButton; // 권총 선택 버튼
    public Button ARButton; // 기관총 선택 버튼
    public Button shotgunButton; // 산탄총 선택 버튼
    public Button sniperButton; // 저격총 선택 버튼

    void Start()
    {
        // 게임 시작 시 무기 선택 패널을 활성화
        weaponPanel.SetActive(true);

        // 각 무기 버튼에 이벤트 리스너 추가
        pistolButton.onClick.AddListener(() => SelectWeapon("Pistol"));
        ARButton.onClick.AddListener(() => SelectWeapon("AR"));
        shotgunButton.onClick.AddListener(() => SelectWeapon("Shotgun"));
        sniperButton.onClick.AddListener(() => SelectWeapon("Sniper"));
    }

    public void SelectWeapon(string weaponName)
    {
        // 무기 선택 로직
        Debug.Log(weaponName + " 선택됨");
        // 무기 선택 후 패널 비활성화
        weaponPanel.SetActive(false);
        // 게임 플레이 로직 추가
        StartGameWithWeapon(weaponName);
    }

    private void StartGameWithWeapon(string weaponName)
    {
        // 여기에 무기에 따른 게임 시작 로직을 추가하세요.
        // 예: 플레이어의 무기를 교체하거나, 무기에 따른 특별한 능력을 활성화
        Debug.Log(weaponName + "으로 게임 시작!");
    }
}
