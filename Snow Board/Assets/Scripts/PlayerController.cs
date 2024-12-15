using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb2d;
    float torque = 1f;
    void Start()
    {
         rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            rb2d.AddTorque(torque);
        }else if (Input.GetKey(KeyCode.D)){
            rb2d.AddTorque(-torque);
        }
    }
}
