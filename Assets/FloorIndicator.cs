using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloorIndicator : MonoBehaviour
{

    public bool doNotDestroy;

    float originalAlpha = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().text = "Floor " + (GameManager.instance.currentFloor + 1);
    }

    float timeCounter = 0;

    // Update is called once per frame
    void Update()
    {
        if (doNotDestroy)
            return;

        timeCounter += Time.deltaTime;
        originalAlpha  = Mathf.Max(originalAlpha-(Time.deltaTime*0.17f), 0f);

        GetComponent<TMP_Text>().color = new Color(1, 1, 1, originalAlpha);
        
    }
}
