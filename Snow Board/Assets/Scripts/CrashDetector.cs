using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] float delay = 0.5f;
    [SerializeField] ParticleSystem blood;
    [SerializeField] AudioClip crashSFX;
    bool canPlay = true;
    


    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground" || canPlay){
            canPlay = false;
            FindObjectsByType<PlayerController>((FindObjectsSortMode)FindObjectsInactive.Include)[0].DisableControls();
            blood.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene",delay);
        }
    }

    public void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
