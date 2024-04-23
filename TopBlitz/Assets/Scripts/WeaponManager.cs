using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject revolver; // 리볼버 게임 오브젝트
    public GameObject shotgun; // 샷건 게임 오브젝트
    public GameObject assaultRifle; // 돌격소총 게임 오브젝트
                               // 추후 다른 무기에 대한 참조를 추가할 수 있습니다.

    private GameObject activeWeapon; // 현재 활성화된 무기

    void Start()
    {
        // 게임이 시작했을 때 리볼버를 기본 무기로 설정합니다.
        ActivateWeapon(revolver);
    }
    void Update()
    {
        // 마우스 왼쪽 버튼을 눌렀을 때 발사합니다.
        if (Input.GetMouseButton(0))
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

    // 활성화된 무기에서 발사 메서드를 호출하는 함수를 작성합니다.
    void Fire()
    {
        // 현재 활성화된 무기가 있다면 그 무기의 Fire 메서드를 호출합니다.
        if (activeWeapon != null)
        {
            activeWeapon.GetComponentInChildren<Weapon>().Fire();
        }
    }

    // 무기를 활성화하는 비공개 메서드
    private void ActivateWeapon(GameObject weapon)
    {
        if (activeWeapon != null)
        {
            activeWeapon.SetActive(false);
        }

        activeWeapon = weapon;
        activeWeapon.SetActive(true);
    }
}
