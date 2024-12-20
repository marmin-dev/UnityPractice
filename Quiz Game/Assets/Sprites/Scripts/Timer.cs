using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f; 
    float timerValue;
    public float fillFraction;
    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion;
    void Update()
    {
        UpdateTimer();
    }
    void UpdateTimer(){
        timerValue -= Time.deltaTime;
        if (isAnsweringQuestion){
            if (timerValue > 0){
                fillFraction = timerValue / timeToCompleteQuestion;
            }else{
                isAnsweringQuestion=false;
                timerValue = timeToShowCorrectAnswer;
            }
        }else{
            if (timerValue > 0f){
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }else{
                isAnsweringQuestion=true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
    }

    public void CancelTimer(){
        timerValue = 0;
    }
}
