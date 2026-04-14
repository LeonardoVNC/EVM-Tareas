using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public TextMeshProUGUI timer;
    public TextMeshProUGUI scorer;

    private float time = 5f;
    private int score = 0;
    private bool isGameOver = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (isGameOver) return;

        if (time > 0) {
            time -= Time.deltaTime;
            UpdateUI();
        } else {
            GameOver();
        }
    }

    void UpdateUI() {
        scorer.text = score+"";
        timer.text = time.ToString("F1") + " s";
    }

    public void AddScore() {
        if (isGameOver) return;
        score++;

        float timeToAdd = Mathf.Max(2f, 4f - (score * 0.2f));
        time += timeToAdd;
        if (time > 10) {
            time = 10;
        }
    }

    void GameOver() {
        isGameOver = true;
        time = 0;
        UpdateUI();
        SceneManager.LoadScene("WinScreen"); 
    }
}
