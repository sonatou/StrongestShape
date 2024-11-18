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
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button restartGame;

    private int playerscore = 0;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        restartGame.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateScore(int val)
    {
        playerscore += val;
        scoreText.text = "Score: " + playerscore.ToString();
    }

    public void PlayerLoss()
    {
        //Da para colocar regras de para o tempo aqui por exemplo para o jogo dar freeze se o player morrer

        losePanel.gameObject.SetActive(true);
    }



}
