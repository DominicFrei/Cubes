using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject levelComplete = default;
    [SerializeField] PlayerMovement playerMovement = default;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void FinishLineHit()
    {
        levelComplete.SetActive(true);
    }

    public void FinishLineApproachHit()
    {
        playerMovement.StopMovement();
    }
}
