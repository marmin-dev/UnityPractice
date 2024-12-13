using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    // 이것이 카메라가 차를 따라다니게 해주는 코드 입니다.
    [SerializeField] GameObject thingToFollow;
    // Update is called once per frame
    void Update()
    {
        transform.position = thingToFollow.transform.position + new Vector3 (0,0, -10);
    }
}
