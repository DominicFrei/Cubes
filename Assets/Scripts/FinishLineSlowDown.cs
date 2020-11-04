using UnityEngine;

public class FinishLineSlowDown : MonoBehaviour
{
    [SerializeField] GameManager gameManager = default;

    void OnTriggerEnter(Collider other)
    {
        gameManager.FinishLineApproachHit();
    }
}
