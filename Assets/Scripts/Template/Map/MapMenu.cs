using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapMenu : MonoBehaviour
{
    public RawImage[] mapImages;
    public Button[] buttons;

    // 設定點擊事件處理程序
    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int mapIndex = i; // 創建一個臨時變數以避免閉包問題
            buttons[i].onClick.AddListener(() => ShowMap(mapIndex));
        }
    }

    // 顯示選定的地圖
    public void ShowMap(int mapIndex)
    {
        // 根據地圖索引在 mapImages 中更新對應的 RawImage
        for (int i = 0; i < mapImages.Length; i++)
        {
            mapImages[i].gameObject.SetActive(i == mapIndex);
        }
    }

}