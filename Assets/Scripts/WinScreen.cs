using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreen : MonoBehaviour
{
    public TextMeshProUGUI score; 
    public TextMeshProUGUI title;

    void Start()
    {
        if (score != null) {
            int final = GameManager.finalScore;
            score.text = final+"";
            if (final <=0) {
                title.text = "Eh...?";
            } else {
                title.text = "Fabuloso!";
            }
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
