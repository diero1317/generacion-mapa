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
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return null;
        SpawnRoom();
    }

    void SpawnRoom()
    {
        if (!spawned && templates.cRoom < templates.maxRoom)
        {
            Debug.Log(templates.cRoom+ "," + templates.maxRoom);

            if (openSide == 1)
            {
                //puerta arriba
                i = Random.Range(1, templates.topRooms.Length);
                Instantiate(templates.topRooms[i], transform.position, templates.topRooms[i].transform.rotation);
                Destroy(gameObject);
            }
            else if (openSide == 2)
            {
                //puerta abajo
                i = Random.Range(1, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[i], transform.position, templates.bottomRooms[i].transform.rotation);
                Destroy(gameObject);
            }
            else if (openSide == 3)
            {
                //puerta izq
                i = Random.Range(1, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[i], transform.position, templates.leftRooms[i].transform.rotation);
                Destroy(gameObject);
            }
            else if (openSide == 4)
            {
                //puerta der
                i = Random.Range(1, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[i], transform.position, templates.rightRooms[i].transform.rotation);
                Destroy(gameObject);
            }
            spawned = true;
            templates.cRoom++;
        }
        else //if (templates.cRoomFinal <= 3)
        {
            if (openSide == 1)
            {
                Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);
                Destroy(gameObject);
            }
            else if (openSide == 2)
            {
                Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);
                Destroy(gameObject);
            }
            else if (openSide == 3)
            {
                Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);
                Destroy(gameObject);
            }
            else if (openSide == 4)
            {
                Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);
                Destroy(gameObject);
            }
            spawned = true;
        }
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        // Si el collider tiene la etiqueta "SpawnPoint"
        if (collision.CompareTag("SpawnPoint"))
        {
            // Si la habitaci�n a�n no ha sido generada
            if (!spawned)
            {
                // Destruye el objeto spawner
                Destroy(gameObject);
            }
        }
    }
}
