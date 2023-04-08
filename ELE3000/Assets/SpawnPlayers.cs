using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DONE

public class SpawnPlayers : MonoBehaviour
{
    public GameObject[] allClones;
    public GameObject Player;

    void Start()
    {
        foreach (GameObject clone in allClones)
        {
            clone.SetActive(false);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Spawner();
        }
    }


    public void Spawner()
    {
        foreach(GameObject clone in allClones)
        {
            clone.SetActive(true);
        }

        Player.SetActive(false);

        Debug.Log("10 Clones activated");
    }

}
