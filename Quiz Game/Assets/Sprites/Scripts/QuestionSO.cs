using UnityEngine;

[CreateAssetMenu(menuName ="QuizQuestion",fileName ="New Question")]
public class QuestionSO : ScriptableObject {
    // Text Area 속성은 인스펙터 안의 텍스트 상자의 크기를 지정하고 조정할 수 있도록 해준다.
    [TextArea(2,6)] 
    [SerializeField] string question = "Enter new Questiontext here";
    [SerializeField] string[] answerArray = new string[4];
    [SerializeField] int answer = 0;

    public string GetQuestion(){
        return this.question;
    }
    
    public string GetAnswer(int index){
        return this.answerArray[index];
    }

    public int GetCorretIndex(){
        return this.answer;
    }


}
