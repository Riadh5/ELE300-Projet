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

    GameObject farthestRightFlag = null;
    float farthestRightX = Mathf.NegativeInfinity;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Spawner();

            for (int i = 1; i < 100; i++)
            {
                Invoke("TransformPosGameObject", (15 * i) - 1);
                Invoke("ActivateGameObject", 15f * i);
                //Invoke("DestroyFlag", 15f * i);
            }
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

        GameObject[] flags = GameObject.FindGameObjectsWithTag("Flag");

        foreach (GameObject flag in flags)
        {
            float x = flag.transform.position.x;
            if (x > farthestRightX)
            {
                farthestRightFlag = flag;
                farthestRightX = x;
            }
        }

        foreach (GameObject clone in CloneTable)
        {
            clone.transform.position = farthestRightFlag.transform.position;
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
