using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartController : MonoBehaviour
{
    public void StartGame()
    {
        Screen.SetResolution(720, 960, false);
        SceneManager.LoadScene("彈珠台草原場景");
    }
}
