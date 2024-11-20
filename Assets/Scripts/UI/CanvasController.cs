using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance;

    [SerializeField] private RectTransform losePanel;
    [SerializeField] private RectTransform winPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private Button restartGame;
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject player;
    
    private float elapsedTime = 0f;
    private bool isTimerRunning = true;
    private int playerscore = 0;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        restartGame.onClick.AddListener(RestartGame);
        returnButton.onClick.AddListener(ReturnMainMenu);
    }
    private void Update()
    {
        if (!isTimerRunning) return;

        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000f) % 1000);

        timerText.text = $"{minutes:D2}:{seconds:D2}:{milliseconds:D3}";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateScore(int val)
    {
        playerscore += val;
        scoreText.text = "Score: " + playerscore.ToString();
        if(playerscore >= 17)
        {
            player.SetActive(false);
            winText.text = "you win in " + timerText.text + " try blindfolded now";
            winPanel.gameObject.SetActive(true);
        }
    }

    void pauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void PlayerLoss()
    {
        //Da para colocar regras de para o tempo aqui por exemplo para o jogo dar freeze se o player morrer

        losePanel.gameObject.SetActive(true);
    }



}
