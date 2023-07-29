using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("測試彈珠台");
    }
}
