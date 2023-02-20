using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject Clones;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            for (int i = 0; i < 10; i++) {

                Instantiate(Clones, new Vector2(-5.94f, 1.76f), Quaternion.identity);
            }

            Debug.Log("10 Clones created");
        }

    }

}
