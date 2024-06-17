using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponManager : MonoBehaviour
{
    public GameObject revolver; // 리볼버 게임 오브젝트
    public GameObject assaultRifle; // 돌격소총 게임 오브젝트
    public GameObject sniper;
    public GameObject shotgun; // 샷건 게임 오브젝트
    // 추후 다른 무기에 대한 참조를 추가할 수 있습니다.

    private GameObject activeWeapon; // 현재 활성화된 무기

    void Start()
    {
        // 초기화 코드는 여기에 추가할 수 있습니다.
    }

    void Update()
    {
        // 마우스 왼쪽 버튼을 눌렀을 때 발사합니다.
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.currentSelectedGameObject)
        {
            Fire();
        }
    }

    // 리볼버를 활성화하는 공개 메서드
    public void ActivateRevolver()
    {
        ActivateWeapon(revolver);
    }

    // 샷건을 활성화하는 공개 메서드
    public void ActivateShotgun()
    {
        ActivateWeapon(shotgun);
    }

    public void ActivateAssault()
    {
        ActivateWeapon(assaultRifle);
    }

    public void ActivateSniper()
    {
        ActivateWeapon(sniper);
    }

    // 활성화된 무기에서 발사 메서드를 호출하는 함수를 작성합니다.
    void Fire()
    {
        // 현재 활성화된 무기가 있다면 그 무기의 Fire 메서드를 호출합니다.
        if (activeWeapon != null)
        {
            activeWeapon.GetComponentInChildren<Weapon>()?.Fire();
        }
    }

    // 무기를 활성화하는 메서드
    public void ActivateWeapon(GameObject weapon)
    {
        // 현재 활성화된 무기와 새로운 무기가 같은 경우 처리를 생략합니다.
        if (activeWeapon == weapon)
            return;

        // 이전에 활성화된 무기를 비활성화합니다.
        if (activeWeapon != null)
        {
            activeWeapon.SetActive(false);
        }

        // 새로운 무기를 활성화합니다.
        activeWeapon = weapon;

        if (activeWeapon != null)
        {
            activeWeapon.SetActive(true);
        }
    }
}