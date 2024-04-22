using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI _ScoreText;
    public static GameManager Instance;
    public GameObject _LivesHolder;
    public GameObject _GameOverPanel;
    int _Score;
    bool _GameOver = false;
    int _Lives = 3;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _Score = 0;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncrementScore()
    {
        if (!_GameOver)
        {
            _Score++;
            _ScoreText.text = _Score.ToString();
        }
    }

    public void DecrementLife()
    {
        if (_Lives > 0)
        {
            _Lives--;
            _LivesHolder.transform.GetChild(_Lives).gameObject.SetActive(false);
        }

        if (_Lives <= 0)
        {

            _GameOver = true;
            GameOver();
        }
    }

    public void GameOver()
    {
        print("Game Over");
        _GameOverPanel.SetActive(true);
        PlayerController.Instance.canMove = false;
        CandySpawner.Instance.StopSpawningCandies();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
