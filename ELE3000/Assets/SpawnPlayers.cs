using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject Clones;
    public GameObject Player;
    public GameObject[] gos;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.N))
        {

            gos = new GameObject[10];

            for (int i = 0; i < 5; i++) {

                GameObject clone = Instantiate(Clones, new Vector2(-5.94f, 1.76f), Quaternion.identity);
                gos[i] = clone;
            }

            Debug.Log("10 Clones created");
        }

    }

}
