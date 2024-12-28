using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    [SerializeField] float levelLoadDalay =1f;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            StartCoroutine(LoadNextLever());
        }
    }
    IEnumerator LoadNextLever(){
        yield return new WaitForSecondsRealtime(levelLoadDalay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0;
        }
        FindFirstObjectByType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }
}
