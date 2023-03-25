using UnityEngine;

// DONE

public class TimeControl : MonoBehaviour
{ 
    public void GottaGoFast()
    {
        Time.timeScale = 20f;

    }

    public void GottaGoBack()
    {
        if (Time.timeScale >= 1)
        {
            Time.timeScale = Time.timeScale / 20f;
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

