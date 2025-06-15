using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject painelMenu;
    [SerializeField] private GameObject painelConfigs;
    [SerializeField] private GameObject painelControles;
    [SerializeField] private GameObject painelHighscore;
    [SerializeField] private GameObject painelHUD;

    public void Jogar()
    {
        Debug.Log("Carregando jogo");
        painelMenu.SetActive(false);
        painelHUD.SetActive(true);
    }

    public void Configs()
    {
        painelMenu.SetActive(false);
        painelControles.SetActive(false);
        painelConfigs.SetActive(true);
    }
    public void Controles()
    {
        painelConfigs.SetActive(false);
        painelMenu.SetActive(false);
        painelControles.SetActive(true);
    }
    public void VoltarMenu()
    {
        painelConfigs.SetActive(false);
        painelControles.SetActive(false);
        painelHighscore.SetActive(false);
        painelMenu.SetActive(true);
    }
    public void Highscores()
    {
        painelHUD.SetActive(false);
        painelMenu.SetActive(false);
        painelHighscore.SetActive(true);
    }
    public void Sair()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit(); // funciona apenas em builds
    }
}

