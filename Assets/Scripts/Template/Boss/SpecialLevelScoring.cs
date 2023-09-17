using UnityEngine;

public class SpecialLevelScoring : MonoBehaviour
{
    public bool isSpecialLevel = false; // 是否为特殊关卡
    public int scoreValue = 10; // 每次得分的分数值
    public string targetTag = "SpecialTarget"; // 特定物体的标签
    private GameScore gameScore;

    void Start()
    {
        gameScore = FindObjectOfType<GameScore>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 检查是否为特殊关卡和碰撞物体的标签是否匹配
        if (isSpecialLevel && collision.gameObject.CompareTag(targetTag))
        {
            // 在这里执行加分逻辑
            // 你可以根据需要调用任何与得分相关的功能或管理得分的组件

            // 例如，你可以查找得分管理器并增加分数
            if (gameScore != null)
            {
                gameScore.AddScore(scoreValue);
            }
        }
    }
}