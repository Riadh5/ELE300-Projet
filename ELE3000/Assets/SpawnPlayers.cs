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

    private int counter = 0;
    private float lastLogTime = 0f;
    private float logInterval = 20f;
    private bool isLogging = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Spawner();

            for (int i = 1; i < 100; i++)
            {
                Invoke("TransformPosGameObject", (20 * i) - 1);
                Invoke("ActivateGameObject", 20f * i);
                Invoke("DestroyFlag", 20f * i);
            }

            isLogging = true;
        }

        if (isLogging && Time.time - lastLogTime >= logInterval)
        {
            counter++;
            Debug.Log("Génération : " + counter);
            lastLogTime = Time.time;
        }
    }


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

        foreach (GameObject clone in CloneTable)
        {
            MovementRandomizer myComponent = clone.GetComponent<MovementRandomizer>();

            clone.SetActive(true);

            if (myComponent != null)
            {
                myComponent.enabled = true;
            }
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
