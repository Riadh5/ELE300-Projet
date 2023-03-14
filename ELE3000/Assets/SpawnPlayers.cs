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

            for (int i = 1; i < 10; i++)
            {
                Invoke("TransformPosGameObject", (20 * i) - 2);
                Invoke("ActivateGameObject", 20f * i);
            }
                
        }

    }


    void TransformPosGameObject()
    {
        Debug.Log("Position transformed");

        foreach (GameObject clone in CloneTable)
        {
            clone.transform.position = Flag.transform.position;
        }

    }


    void ActivateGameObject()
    {
        Debug.Log("clone activated");

        foreach (GameObject clone in CloneTable)
        {
            clone.SetActive(true);
        }
    }


    void DestroyFlag()
    {
        GameObject[] OldFlags = GameObject.FindGameObjectsWithTag("Flag");

        foreach (GameObject flag in OldFlags)
        {
            Destroy(flag);
        }
    }

}
