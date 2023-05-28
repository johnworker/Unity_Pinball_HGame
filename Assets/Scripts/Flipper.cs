using UnityEngine;

public class Flipper : MonoBehaviour
{
    [Header("彈簧的原始位置")]
    public float restPosition = 0f;
    [Header("彈簧壓下的位置")]
    public float pressedPosition = 45f;
    [Header("彈簧的彈簧打擊力度")]
    public float hitStrenght = 10000f;
    [Header("彈簧的擋板控制器，用於減緩彈簧的運動")]
    public float flipperDamper = 150f;

    private HingeJoint hinge;
    [Header("輸入名稱")]
    public string inputName;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        // 合鏈接頭.使用彈簧 = 開啟;
        hinge.useSpring = true;
    }

    void Update()
    {
        JointSpring spring = new JointSpring();
        // 定義彈簧的彈簧打擊力度
        spring.spring = hitStrenght;
        // 定義彈簧的擋板控制器
        spring.damper = flipperDamper;

        if(Input.GetAxis(inputName) == 1)
        {
            print(inputName);
            // 彈簧的目標位置 = 壓力位置
            spring.targetPosition = pressedPosition;
            Debug.Log(pressedPosition);
        }
        else
        {
            // 彈簧的目標位置 = 恢復位置
            spring.targetPosition = restPosition;
        }

        // 應用彈簧到HingeJoint組件
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
