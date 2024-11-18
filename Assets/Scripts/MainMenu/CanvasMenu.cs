using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMenu : MonoBehaviour
{
    [SerializeField] private RectTransform mainPanel;
    [SerializeField] private RectTransform creditPanel;
    [SerializeField] private Button startGame;
    [SerializeField] private Button quitGame;
    [SerializeField] private Button creditButton;

    private void Start()
    {
        startGame.onClick.AddListener(StartGame);
        quitGame.onClick.AddListener(QuitGame);
        creditButton.onClick.AddListener(CreditsPanel);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("InGame");
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void CreditsPanel()
    {
        mainPanel.gameObject.SetActive(false);
        creditPanel.gameObject.SetActive(true);
    }

    public void ReturnMainPanel()
    {
        creditPanel.gameObject.SetActive(false);
        mainPanel.gameObject.SetActive(true);
    }
}
