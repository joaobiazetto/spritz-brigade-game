using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    [SerializeField] WaterGunWeapon waterGunWeapon;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            waterGunWeapon.Fire();
        }
    }
}
