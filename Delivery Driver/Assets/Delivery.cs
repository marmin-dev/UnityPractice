using UnityEngine;

public class Collision : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float destroyTime = 0.5f;

    [SerializeField] Color32 noPackageColor = new Color32(255,255,255,255);

    [SerializeField] Color32 hasPackageColor = new Color32(255,0,0,255);

    SpriteRenderer spriteRenderer;
    // 충돌 감지 코드
    // private 은 이 클래스에서만 사용이 가능한 코드이기 때문에 제거

private void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();
}

    void OnCollisionEnter2D(Collision2D other) 
    {
        // Debug.Log("Hello It's Stone");
    }

// 트리거 진입시 발생하는 코드
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage){
            Debug.Log("It's a Package");
            hasPackage = true;
            spriteRenderer.color= hasPackageColor;
            Destroy(other.gameObject, destroyTime);            
        }
        else if(other.tag == "Customer" && hasPackage){
            Debug.Log("It's a customer");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
        
    }
}
