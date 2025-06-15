using UnityEngine;

public class PauseController : MonoBehaviour
{
    public bool pause = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    void TogglePause()
    {
        pause = !pause;
        Time.timeScale = pause ? 0f : 1f;
    }
}
