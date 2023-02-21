using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneDeath : MonoBehaviour
{
    public GameObject Clone;

    private void OnTriggerEnter2D(Collider2D collision1)
    {
        if (collision1.gameObject.CompareTag("Death"))
        {
            Destroy(Clone);
        }
    }
}
