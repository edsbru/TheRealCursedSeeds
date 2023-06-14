using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantFix : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.currentFloor >= 2)
        {
            GetComponent<ChargerMovement>().chargingForce = 800;
            if(!GetComponent<ChargerMovement>().isCharging)
                GetComponent<ChargerMovement>().chargeTime = 2f;

        }
        else
        {
            GetComponent<ChargerMovement>().chargingForce = 700;
            if(!GetComponent<ChargerMovement>().isCharging)
                GetComponent<ChargerMovement>().chargeTime = 2f;

        }

    }
}
