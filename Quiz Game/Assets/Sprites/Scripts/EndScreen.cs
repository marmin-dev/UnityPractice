using UnityEngine;
using TMPro;


public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;
    void Awake() {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }


    public void ShowFinalScore(){
        finalScoreText.text = "Congrations!\nYour Score is " 
            + scoreKeeper.CalculateScore();

    }
}
