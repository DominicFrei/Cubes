using UnityEngine;
using UnityEngine.SceneManagement;

public class StartApplication : MonoBehaviour
{
    public void StartApplicationButtonClicked()
    {
        SceneManager.LoadScene("Level1");
    }
}
