using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DONE

public class SpawnPlayers : MonoBehaviour
{
    public GameObject Clones;
    public GameObject Player;
    public Transform PlayerPos;
    public GameObject Flag;

    private GameObject[] CloneTable;

    public void Spawner()
    {
        CloneTable = new GameObject[10];

        for (int i = 0; i < 10; i++) 
        {
            GameObject clone = Instantiate(Clones, PlayerPos.transform.position, Quaternion.identity);

            CloneTable[i] = clone;
        }

        Debug.Log("10 Clones created");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Spawner();

            //Invoke("Spawner", 15f);
            Invoke("InstantiateObject", 14f);
        }
    }

    void InstantiateObject()
    {
        Instantiate(Flag, transform.position, transform.rotation);
    }

}
