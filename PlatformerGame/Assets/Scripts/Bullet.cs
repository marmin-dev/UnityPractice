using UnityEngine;

public class Bullet : MonoBehaviour
{   
    Rigidbody2D myRigidbody;
    [SerializeField] float flySpeed = 1f;
    PlayerMovement player;
    float xSpeed;

    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * flySpeed;
        transform.localScale = new Vector2((Mathf.Sign(xSpeed)),1f);
    }

    void Update() {
        myRigidbody.linearVelocity = new Vector2(xSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

}