using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneDeath : MonoBehaviour
{
    public Transform Clone;
    public GameObject SpawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            // Move player back to spawn point
            Clone.transform.position = SpawnPoint.transform.position;
        }
    }
}
