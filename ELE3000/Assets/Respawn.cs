using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform Player;
    public Transform SpawnPoint;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player.transform.position = SpawnPoint.transform.position;
        Debug.Log("Player spawned");
    }
}
