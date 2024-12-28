using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    private void Awake() {
        int scenes = FindObjectsByType<ScenePersist>(FindObjectsSortMode.None).Length;
        if (scenes > 1){
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ResetScenePersist(){
        Destroy(gameObject);
    }
}
