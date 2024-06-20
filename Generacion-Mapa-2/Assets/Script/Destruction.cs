using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpawnPoint") || other.CompareTag("Wall"))
        {
            Destroy(other.gameObject);
        }
    }
}
