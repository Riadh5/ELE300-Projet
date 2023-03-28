using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseter : MonoBehaviour
{
    public GameObject[] coins;
    public Transform cameraStartPosition;

    private float GenCount = 0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("clone"))
        {
            foreach (GameObject coin in coins)
            {
                coin.SetActive(true);
            }

            ResetCameraPosition();

            GenCount++;

            Debug.Log("Generation :" + GenCount);
        }
    }

    private void ResetCameraPosition()
    {
        Camera.main.transform.position = cameraStartPosition.position;
    }
}
