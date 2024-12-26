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
    CapsuleCollider2D myCapsuleColider;
    [Header("Climb")]
    [SerializeField] float climbSpeed = 7f;
    [SerializeField] float gravityScale = 3f;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        myCapsuleColider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value){
        if(!myCapsuleColider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            return;
        }
        if(value.isPressed){
        myRigidbody.linearVelocity += new Vector2(0f, jumpSpeed);
        }
        
    }

    void Run(){
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
        if(!myCapsuleColider.IsTouchingLayers(LayerMask.GetMask("Ladder"))){
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
}
