using UnityEngine;

public class Flipper : MonoBehaviour
{
    [Header("�u®����l��m")]
    public float restPosition = 0f;
    [Header("�u®���U����m")]
    public float pressedPosition = 45f;
    [Header("�u®���u®�����O��")]
    public float hitStrenght = 10000f;
    [Header("�u®���תO����A�Ω��w�u®���B��")]
    public float flipperDamper = 150f;

    private HingeJoint hinge;
    [Header("��J�W��")]
    public string inputName;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        // �X�챵�Y.�ϥμu® = �}��;
        hinge.useSpring = true;
    }

    void Update()
    {
        JointSpring spring = new JointSpring();
        // �w�q�u®���u®�����O��
        spring.spring = hitStrenght;
        // �w�q�u®���תO���
        spring.damper = flipperDamper;

        if(Input.GetAxis(inputName) == 1)
        {
            print(inputName);
            // �u®���ؼЦ�m = ���O��m
            spring.targetPosition = pressedPosition;
            Debug.Log(pressedPosition);
        }
        else
        {
            // �u®���ؼЦ�m = ��_��m
            spring.targetPosition = restPosition;
        }

        // ���μu®��HingeJoint�ե�
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
