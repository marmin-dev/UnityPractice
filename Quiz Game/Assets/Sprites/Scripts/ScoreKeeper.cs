using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers = 0;
    int questionSeen = 0;

    public void SetCorrectAnswers(int answers){
        this.correctAnswers = answers;
    }
    public void IncrementCorrectAnswers(){
        this.correctAnswers += 1;
    }
    public void SetQuestionSeen(int question){
        this.questionSeen = question;
    }
    public void IncrementQuestionSeen(){
        this.questionSeen += 1;
    }
    public int GetCorrectAnswers(){
        return this.correctAnswers;
    }
    public int GetQuestionSeen(){
        return this.questionSeen;
    }
    public int CalculateScore(){
        if(correctAnswers == 0 && questionSeen == 0){
            return 100;
        }else {
            return Mathf.RoundToInt(correctAnswers / (float)questionSeen * 100);
        }
        
    }

}
