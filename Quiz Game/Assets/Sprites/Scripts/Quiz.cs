using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;
    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    bool hasAnsweredEarly;
    [Header("Buttons")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [Header("Timers")]
    [SerializeField] Image timerImage;
    Timer timer;
    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Start()
    {
        timer = FindFirstObjectByType<Timer>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    void Update(){
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion){
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion){
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index){
        hasAnsweredEarly = true;
        SetButtonState(false);
        DisplayAnswer(index);
        timer.CancelTimer();
        scoreText.text = "Score:" + scoreKeeper.CalculateScore()+"%";
    }

    void DisplayAnswer(int index){
        if(index == currentQuestion.GetCorretIndex()){
            questionText.text = "Correct!";
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.IncrementCorrectAnswers();
        }else{
            questionText.text = "It was \"" + answerButtons[currentQuestion.GetCorretIndex()].GetComponentInChildren<TextMeshProUGUI>().text + "\"";
            TextMeshProUGUI wrongbuttonText = answerButtons[index].GetComponentInChildren<TextMeshProUGUI>();
            wrongbuttonText.color = new Color32(255, 0,0, 255);
            Image buttonImage = answerButtons[currentQuestion.GetCorretIndex()].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    void GetNextQuestion(){
        if (questions.Count > 0){
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
        }
        
    }

    void GetRandomQuestion(){
        if(questions.Count > 0){
            int index = Random.Range(0, questions.Count);
            currentQuestion = questions[index];
            if (questions.Contains(currentQuestion)){
                questions.Remove(currentQuestion);
            }   
        }
    }

    void DisplayQuestion(){
        questionText.text = currentQuestion.GetQuestion();
        for(int i =0; i < answerButtons.Length; i++){
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.color = new Color32(0, 0, 0, 255);
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    void SetButtonState(bool state){
        for(int i =0; i < answerButtons.Length; i++){
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    void SetDefaultButtonSprites(){
        for(int i =0; i < answerButtons.Length; i++){
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
