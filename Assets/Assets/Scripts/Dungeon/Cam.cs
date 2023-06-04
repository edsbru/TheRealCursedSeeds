using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject cam;
    public string direcion;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("CameraFollow");
        player = FindObjectOfType<PlayerStats>().transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            if (direcion == "up")
            {
                cam.transform.position += new Vector3(0, 12.38f, 0);
                player.transform.position += new Vector3(0, 6.4f, 0);
            }

            else if (direcion == "down")
            {
                cam.transform.position += new Vector3(0, -12.48f, 0);
                player.transform.position += new Vector3(0, -6.4f, 0);
            }

            else if(direcion == "right")
            {
                cam.transform.position += new Vector3(22, 0, 0);
                player.transform.position += new Vector3(3f, 0, 0);
            }

            else if (direcion == "left")
            {
                cam.transform.position += new Vector3(-22f, 0, 0);
                player.transform.position += new Vector3(-3f, 0, 0);
            }
            FixTeleportedPosition();

            AutoConfigMinimapMask.ConfigurarRenderers();

        }

    }

    void FixTeleportedPosition()
    {
        var rooms = FindObjectsOfType<TpManager>();
        var closest = rooms[0];
        float closesDistance = Vector2.Distance(closest.transform.position, cam.transform.position);

        foreach ( var room in rooms )
        {
            float distance = Vector2.Distance(cam.transform.position, room.transform.position);

            if ( distance < closesDistance )
            {
                closesDistance = distance;
                closest = room;
            }
        }

        Vector2 destinyPosition = closest.transform.position;
        cam.transform.position = (Vector3)destinyPosition + Vector3.forward * cam.transform.position.z;


    }

}
