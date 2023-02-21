using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneDeath : MonoBehaviour
{
    public GameObject Clone;
    public Transform Spawn;

    private void OnTriggerEnter2D(Collider2D collision1)
    {
        if (collision1.gameObject.CompareTag("clone"))
        {
            Destroy(collision1.gameObject);
            Instantiate(Clone, Spawn.transform.position, Quaternion.identity);
        }
    }
}
