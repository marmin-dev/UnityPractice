using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Run")]
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    [SerializeField] float moveSpeed = 10f;
    [Header("Animation")]
    Animator playerAnimator;
    [Header("Jump")]
    [SerializeField] float jumpSpeed = 7f;
    BoxCollider2D myfeetColider;
    CapsuleCollider2D myBodyColider;
    [Header("Climb")]
    [SerializeField] float climbSpeed = 7f;
    [SerializeField] float gravityScale = 3f;
    [Header("Death")]
    [SerializeField] Vector2 deathKick = new Vector2(10f, 20f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;

    bool isAlive = true;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        myfeetColider = GetComponent<BoxCollider2D>();
        myBodyColider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    void OnFire(InputValue value){
        if (!isAlive){
            return;
        }
        Instantiate(bullet, gun.position, transform.rotation);
    }

    void OnMove(InputValue value){
        if (!isAlive){
            return;
        }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value){
        if (!isAlive){
            return;
        }
        if(!myfeetColider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            return;
        }
        if(value.isPressed){
        myRigidbody.linearVelocity += new Vector2(0f, jumpSpeed);
        }
        
    }

    void Run(){
        if (!isAlive){
            return;
        }
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, myRigidbody.linearVelocity.y);
        myRigidbody.linearVelocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning",playerHasHorizontalSpeed);
        
        
    }

    void FlipSprite(){
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed){
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.linearVelocity.x),1f);
        }        
    }

    void ClimbLadder(){
        if (!isAlive){
            return;
        }
        if(!myfeetColider.IsTouchingLayers(LayerMask.GetMask("Ladder"))){
            myRigidbody.gravityScale = gravityScale;
            playerAnimator.SetBool("isClimbing",false);
            return;
        }
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.y) > Mathf.Epsilon;
        playerAnimator.SetBool("isClimbing",playerHasHorizontalSpeed);
        Vector2 climbVelocity = new Vector2(myRigidbody.linearVelocity.x, moveInput.y * climbSpeed);
        myRigidbody.linearVelocity = climbVelocity;
        myRigidbody.gravityScale = 0;
    }    

    void Die(){
        if(myBodyColider.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazard"))&& isAlive){
            isAlive = false;
            playerAnimator.SetTrigger("Dying");
            myRigidbody.linearVelocity = deathKick;
            FindFirstObjectByType<GameSession>().ProcessPlayerDeath();
        }
    }
    
}
