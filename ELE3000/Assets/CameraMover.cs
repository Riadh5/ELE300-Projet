using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    void Update()
    {
        GameObject clone = GameObject.FindGameObjectWithTag("clone");
        if (clone != null)
        {
            int screenWidth = Screen.width;
            Vector3 screenRight = Camera.main.ScreenToWorldPoint(new Vector3(screenWidth, 0f, 0f));
            float screenRightX = screenRight.x;
            float cloneX = clone.transform.position.x;
            if (cloneX > screenRightX)
            {
                float cameraX = Camera.main.transform.position.x;
                float delta = cloneX - screenRightX;
                Camera.main.transform.position = new Vector3(cameraX + delta + 15, Camera.main.transform.position.y, Camera.main.transform.position.z);
            }
        }
    }
}
