using UnityEngine;

public class DustTrail : MonoBehaviour
{
   [SerializeField] ParticleSystem snow;

   void OnCollisionEnter2D(Collision2D other) {
    if(other.gameObject.tag == "Ground"){
        snow.Play();
    }
   }

   void OnCollisionExit2D(Collision2D other) {
    if(other.gameObject.tag == "Ground"){
        snow.Stop();
    }
   }
}
