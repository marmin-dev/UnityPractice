using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    // 두 메서드는 콜백이라고 부른다.

    // 게임이 실행되는 매 프레임 마다 실행됨 

    void Update()
    {
        // 프레임 마다 계산해야 하기 때문에 update 안에서 생성
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "SpeedUp"){
            Debug.Log("speed up");
            moveSpeed = boostSpeed;
        }
    }
}
