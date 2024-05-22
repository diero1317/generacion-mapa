using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openSide;

    //1 necesitamos puerta arriba
    //2 necesitamos puerta abajo
    //3 necesitamos puerta izq
    //4 necesitamos puerta der

    private RoomTemplate templates;
    private int i;
    private bool spawned = false;
    

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
    }


    void Spawn()
    {
        if (!spawned)
        {
            if (openSide == 1)
            {
                //puerta arriba

                i = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[i], transform.position, templates.topRooms[i].transform.rotation);
            }
            else if (openSide == 2)
            {
                //puerta abajo

                i = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[i], transform.position, templates.bottomRooms[i].transform.rotation);
            }
            else if (openSide == 3)
            {
                //puerta izq

                i = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[i], transform.position, templates.leftRooms[i].transform.rotation);
            }
            else if (openSide == 4)
            {
                //puerta der

                i = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[i], transform.position, templates.rightRooms[i].transform.rotation);
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }
}
