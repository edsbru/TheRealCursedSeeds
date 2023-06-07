using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecoverHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (FindObjectOfType<PlayerStats>().life < 3)
            {
                FindObjectOfType<PlayerStats>().life++;
                Destroy(this.gameObject);

                FindObjectOfType<PlayerHealthHandler>().UpdateLifeUI();
            }
        }
    }
}