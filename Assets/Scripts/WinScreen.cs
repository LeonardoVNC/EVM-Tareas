using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreen : MonoBehaviour
{
    public TextMeshProUGUI score; 

    void Start()
    {
        if (score != null) {
            score.text =  GameManager.finalScore+"";
        }
    }

    void Update()
    {
        
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
