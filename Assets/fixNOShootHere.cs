using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixNOShootHere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GunSelection.instance.SelectWeapon(GameManager.instance.currentWeaponID);
    }

    // Update is called once per frame
    void Update()
    {
        var weapons = FindObjectsOfType<ShootScript>();

        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].enabled = false;
        }
    }
}
