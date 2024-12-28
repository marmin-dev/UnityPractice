using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] int pointsForCoinPickup = 100;
    bool isPickUp = false;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && !isPickUp){
            isPickUp = true;
            AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
            FindFirstObjectByType<GameSession>().AddScore();
            Destroy(gameObject);
        }    
    }
}
