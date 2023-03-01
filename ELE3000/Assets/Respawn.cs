using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform Player;
    public Transform SpawnPoint;

    private float nextActionTime = 0.0f;
    private float period = 2f;

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            SpawnPoint.transform.position = Vector2.MoveTowards(Player.transform.position, Player.transform.position, .03f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.transform.position = SpawnPoint.transform.position;
            Debug.Log("Player spawned");
        }

    }
    
}
