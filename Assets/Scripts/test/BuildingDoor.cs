using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingDoor : MonoBehaviour
{
    public string nextSceneName;  // 下一個場景的名稱

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // 如果碰撞體標籤為"Ball"（彈珠），則加載下一個場景
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
