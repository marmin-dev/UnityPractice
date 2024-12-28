using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    int points = 0;
    void Awake() {
        int numGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if (numGameSessions > 1){
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start(){
        livesText.text = playerLives.ToString();
        scoreText.text = points.ToString();
    }
    public void ProcessPlayerDeath(){
        if(playerLives > 1){
            TakeLife();
        }else{
            ResetGameSession();
        }
    }

    public void AddScore(){
        points += 1;
        scoreText.text = points.ToString();
    }

    private void TakeLife()
    {
        playerLives -= 1;
        livesText.text = playerLives.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ResetGameSession()
    {
        FindFirstObjectByType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
