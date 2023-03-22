using UnityEngine;

// DONE

public class TimeControl : MonoBehaviour
{
    public float AccelerationFactor = 2f;

    public void GottaGoFast()
    {
        Time.timeScale = AccelerationFactor;

    }

    public void GottaGoBack()
    {
        if (Time.timeScale >= 1)
        {
            Time.timeScale = 0.05f;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GottaGoFast();
            Debug.Log("10X SPEED");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GottaGoBack();
            Debug.Log("NORMAL SPEED");
        }
    }

}

