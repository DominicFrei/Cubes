using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player = default;
    [SerializeField] Vector3 cameraOffset = new Vector3(0f, 3f, -5f);

    void Update()
    {
        transform.position = player.transform.position + cameraOffset;
    }
}
