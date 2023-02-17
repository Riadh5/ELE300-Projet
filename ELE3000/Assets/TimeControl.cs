using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public float AccelerationFactor = 2f;

    public void GottaGoFast()
    {
        Time.timeScale = AccelerationFactor;

    }

    public void GottaGoBack()
    {
        if (Time.timeScale > 1)
        {
            Time.timeScale = 1;
        }
    }

}
