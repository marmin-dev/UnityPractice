using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene",delay);            
        }
    }


    void ReloadScene(){
        // 장면을 불러오는 기능
        SceneManager.LoadScene(0);
    }
}
