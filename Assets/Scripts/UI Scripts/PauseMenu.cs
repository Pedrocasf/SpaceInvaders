using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private string FaseDoJogo;
    [SerializeField] private GameObject painelPausa; // arraste aqui o Canvas no Inspector
    [SerializeField] private GameObject painelHUD;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Voltar();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Voltar()
    {
        painelPausa.SetActive(false);
        painelHUD.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }
    public void Despausar()
    {
        Voltar();
    }

    void Pause()
    {
        painelHUD.SetActive(false);
        painelPausa.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
}