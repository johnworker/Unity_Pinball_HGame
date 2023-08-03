using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartController : MonoBehaviour
{
    public void StartGame()
    {
        Screen.SetResolution(720, 1280, false);
        SceneManager.LoadScene("測試彈珠台");
    }
}
