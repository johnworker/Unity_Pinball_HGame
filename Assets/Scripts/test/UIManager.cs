using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public RectTransform menuPanel;
    public RectTransform gamePanel;
    public RectTransform endPanel;
    public TextMeshProUGUI ballCountText;
    public GameObject ballDisplay;

    public UIManager uiManager;

    void Start()
    {
        uiManager.ShowMenuPanel();
    }

    public void ShowMenuPanel()
    {
        menuPanel.gameObject.SetActive(true);
        gamePanel.gameObject.SetActive(false);
        endPanel.gameObject.SetActive(false);
    }

    public void ShowGamePanel()
    {
        menuPanel.gameObject.SetActive(false);
        gamePanel.gameObject.SetActive(true);
        endPanel.gameObject.SetActive(false);
    }

    public void ShowEndPanel()
    {
        menuPanel.gameObject.SetActive(false);
        gamePanel.gameObject.SetActive(false);
        endPanel.gameObject.SetActive(true);
    }

    public void UpdateBallCount(int count)
    {
        ballCountText.text = count.ToString();
    }

    public void SetBallDisplayActive(bool active)
    {
        ballDisplay.SetActive(active);
    }
}