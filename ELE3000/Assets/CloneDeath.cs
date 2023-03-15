using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneDeath : MonoBehaviour
{
    public string cloneTag = "clone";
    public GameObject[] respawnPoints;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("clone"))
        {
            // Find the nearest respawn point
            Transform nearestRespawnPoint = FindNearestRespawnPoint();

            // Respawn the clone at the nearest respawn point
            other.transform.position = new Vector3(nearestRespawnPoint.position.x, nearestRespawnPoint.position.y, 0);
        }
    }

    private Transform FindNearestRespawnPoint()
    {
        Transform nearestPoint = null;
        float minDistance = float.MaxValue;

        GameObject[] allClones = GameObject.FindGameObjectsWithTag("clone");

        foreach (GameObject Clone in allClones)
        {
            foreach (GameObject respawnPoint in respawnPoints)
            {
                float distance = Vector3.Distance(Clone.transform.position, respawnPoint.transform.position);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestPoint= respawnPoint.transform;
                }
            }
        }

        return nearestPoint;
    }
}
