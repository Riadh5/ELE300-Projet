using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reseter : MonoBehaviour
{
    public GameObject[] coins;
    public Transform cameraStartPosition;
    public bool IsHit;
    public int Overlap;

    private float GenCount = 0f;

    [SerializeField] private Text genText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("clone"))
        {
            foreach (GameObject coin in coins)
            {
                coin.SetActive(true);
            }

            ResetCameraPosition();

            Overlap += 1;

            if (Overlap >= 1)
            {
                IsHit = true;
            }
            if (IsHit == true)
            {
                GenCount += 1;
                Overlap = 0;
            }
            
            genText.text = " : " + GenCount;

        }
    }

    private void ResetCameraPosition()
    {
        Camera.main.transform.position = cameraStartPosition.position;
    }
}
