using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGetGunScript : MonoBehaviour
{

    public static TutorialGetGunScript instance;
    GameObject gun;
    GameObject gunUI;
    public bool stop = false;
    // Update is called once per frame

    private void Start()
    {
        instance = this;
        gunUI = GameObject.Find("ImageWeaponSlot");
    }
    void Update()
    {
        if(stop)
        {
            return;
        }
        if (gun)
        {
            gun.SetActive(false);
        }else
        {
            gun = GameObject.Find("BasicGun");
        }

        gunUI.SetActive(false);
        
    }
}
