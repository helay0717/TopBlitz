using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform weaponHoldPlace;
    public Gun startingGun;
    Gun equippedGun;
    void Start()
    {
        if (startingGun != null) {
            EquipGun(startingGun);
        }
    }

    public void EquipGun(Gun gunToEquip)
    {
        if(equippedGun != null){
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate(gunToEquip, weaponHoldPlace.position, weaponHoldPlace.rotation);
        equippedGun.transform.parent = weaponHoldPlace;
    }

    public void Shoot()
    {
        if(equippedGun != null)
        {
            equippedGun.Shoot();
        }
    }
}
