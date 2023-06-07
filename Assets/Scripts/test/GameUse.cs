using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GameSet))]
public class GameUse : MonoBehaviour
{

	/* �o�̨ϥΤF RequireComponent �ݩʡA�o�O�@�� Unity �������Ѫ��S���ݩʡC
	 * ���i�H�T�O���[��P�@�� GameObject �W�����O�㦳���w���ե�C
	 * �b�o�ӨҤl���ARequireComponent(typeof(Game)) ��ܳo�� GameController ���O�ݭn���[�@�� Game �ե�C
	 * �o�� Game �ե�i��O�@�Ӧ۩w�q���ե�A�i��]�t�F�C���޿�B�C�����A�޲z�������\��C
	 * �o�� GameController ���O�i��t�d��թM�����ӹC�����欰�A�æb�C���B��ɻP Game �ե�i��椬�C
	 * �q�L�ϥ� RequireComponent �ݩʡA�i�H�T�O��A�N GameController �}�����[�� GameObject �W�ɡA���N�۰ʪ��[�@�� Game �ե�C
	 * �o���U��T�O�C���B��һݪ������ե�l�צs�b�ä@�_�ϥΡC
	 
	 * �`���ӻ��A�o�� GameController ���O�O�@�ӱ���C���欰�����O�A�ín�D���[�@�� Game �ե�C
	 * �o�� Game �ե�i��]�t�F�C�����֤��޿�M���A�޲z�C */

	[Header("�u®")]
	public HingeJoint leftFlipper;
	public HingeJoint rightFlipper;
	[Header("�u®���ʨ���")]
	public float flipperActiveAngle = 60;

	[Header("�u�]")]
	[Header("�O�q�d��")]
	public Vector2 minMaxForce = new Vector2(10, 20);
	[Header("�O�q�W�q")]
	public float powerGain = 1.2f;
	[Header("UI �Ϲ�")]
	public Image powerImage;

	// �Ω��x�s Game ���O�����
	private GameSet gameSet;

	// �B�I�� �O�q
	private float power;

	void Awake()
	{
		// ���|����o�Ӹ}���Ҫ��[�� GameObject �W�� Game ���O�ե�ñN���ȵ� game �ܼ�
		gameSet = GetComponent<GameSet>();
	}

	void Update()
	{
		// �b�C���B��ɰ��ڭ̷Q������
		if (gameSet.isActive)
		{
			if (gameSet.ballReady)
			{
				ShootInput();
			}
		}
		/*�����A���ˬd game.isActive ���ȡC
		 * game �O���e�b Awake() ��k����Ȫ� Game ���O����ҡC
		 * �p�G game.isActive ���u�A�h��ܹC�����b�B�椤�C
		 * ���U�ӡA���ˬd game.ballReady ���ȡC
		 * �o�i��O�@�ӥ��L�]bool�^���O���ܼơA�Ω��ˬd�y�O�_�ǳƦn�g���C
		 * �p�G game.ballReady ���u�A�h���� ShootInput() ��k�C
		 * �Ӥ�k�i��]�t�F�B�z�g���y���޿�C*/

		// �b�D��椤���\�תO
		FlipperInput();
	}

	/// <summary>
	/// �ھڿ�J�޲z�u®���׭�
	/// </summary>
	void FlipperInput()
	{
		// ���u®
		JointSpring leftSpring = leftFlipper.spring;
		/*�ϥα���B��� ? �Ӯھګ����J�]�m���u®���ؼЦ�m�C
		 * �p�G���U A ��Υ��b�Y��A�h�N�ؼЦ�m�]�m�� flipperActiveAngle�A�_�h�]�m�� 0�C
		 */
		leftSpring.targetPosition = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ? flipperActiveAngle : 0f;
		leftFlipper.spring = leftSpring;

		// �k�u®
		JointSpring rightSpring = rightFlipper.spring;
		/*�ϥα���B��� ? �Ӯھګ����J�]�m�k�u®���ؼЦ�m�C
		 * �p�G���U A ��Υk�b�Y��A�h�N�ؼЦ�m�]�m�� flipperActiveAngle�A�_�h�]�m�� 0�C
		 */
		rightSpring.targetPosition = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ? flipperActiveAngle : 0f;
		rightFlipper.spring = rightSpring;
	}

	/// <summary>
	/// ���s��J�g���u�]�޲z
	/// </summary>
	void ShootInput()
	{
		// �p�G���U����o�o�g ��q
		if (Input.GetKey(KeyCode.Space))
		{
			power += powerGain * Time.deltaTime;
		}

		// ����ɦb minMaxForce �����K�[��� 0..1
		if (Input.GetKeyUp(KeyCode.Space))
		{
			gameSet.ShootBall(minMaxForce.x + (Mathf.Clamp01(power) * (minMaxForce.y - minMaxForce.x)));
			power = 0f;
		}

		// ��s UI�]�N�۰ʧ��b 0..1 �����^
		powerImage.fillAmount = power;
	}

	/*
	 �b�o�Ӥ�k���A���X���޿�P�_�G
	 
	 �����A���ˬd�O�_���U�F�ť���]KeyCode.Space�^�C
	 �p�G�O�A�h�ھ� powerGain �ȩM Time.deltaTime�]��e�V���ɶ����j�^�ӼW�[ power �ܼƪ��ȡC
	 �o�q�{���X���ت��O�b����ť���ɼW�[�O�q�ȡ]power�^�C
	 
	 ���U�ӡA���ˬd�O�_����F�ť���C
	 �p�G�O�A�h�ھ� power ���ȭp��X�g���O�q�A�éI�s game.ShootBall() ��k�N�y�g�X�C
	 �g���O�q���p��O��� minMaxForce ���d��A�èϥ� Mathf.Clamp01() ��k�N power ����b 0 �� 1 �����C
	 �M��A�ϥνu�ʴ��Ȩӭp��b minMaxForce �d�򤺪�����O�q�ȡA�ñN��@���Ѽƶǻ��� game.ShootBall() ��k�C

	 �̫�A���N power ���ȥΩ��s UI�A����ӻ��O��s powerImage �� fillAmount �ݩʡC
	 �o���ݩʪ�ܶ�R�Ϲ�����ҡA�o�̨ϥ� power ���ȧ@����R��ҡA�]����O�q�W�[�ɡAUI �|�ϬM�X�O�q���ܤơC

	 �`���ӻ��A�o�Ӥ�k�b���U�M����ť���ɺ޲z�g���u�]���޿�C
	 ���l�ܨüW�[�O�q�ȡA�ھڤO�q�ȭp��g���O�q��Ĳ�o�g���欰�A�P�ɤ]��s�F UI �H�ϬM�O�q���ܤơC
	*/
}
