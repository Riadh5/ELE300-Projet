using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseter : MonoBehaviour
{
    public GameObject[] coins;
    public Transform cameraStartPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("clone"))
        {
            foreach (GameObject coin in coins)
            {
                coin.SetActive(true);
            }

            ResetCameraPosition();
        }
    }

    private void ResetCameraPosition()
    {
        Camera.main.transform.position = cameraStartPosition.position;
    }
}
