using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Transform playerTransform = default;
    [SerializeField] Text text = default;

    void Update()
    {
        text.text = "Score: " + playerTransform.position.z.ToString("0");
    }
}
