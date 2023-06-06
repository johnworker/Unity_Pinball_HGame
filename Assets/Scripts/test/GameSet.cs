using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSet : MonoBehaviour
{
	// instance�G�o�O�@���R�A�ݩʡA�Ω�s�x Game ���O���ߤ@��ҡC
	// �i�H�q�L Game.instance �ӳX�ݳo�ӹ�ҡC
	public static GameSet instance { get; private set; }

	[Header("�C���O�_�B�󬡰ʪ��A")]
	public bool isActive = false;
	[Header("�u�]�O�_�ǳƦn�g��")]
	public bool ballReady = true;
	[Header("�C�����Ѿl���u�]�ƶq")]
	public int ballCount = 3;
	[Header("�C���O�_�B�󬡰ʪ��A")]
	public TextMeshProUGUI ballCountText;

	[Header("�C�� UI")]
	[Header("�C���������")]
	public RectTransform menuPanel;
	[Header("�C���e��")]
	public RectTransform gamePanel;
	[Header("�����e��")]
	public RectTransform endPanel;

	[Header("�u�]")]
	[Header("��l�u�]�ƶq")]
	public int ballStartCount = 3;

	// �޲z�C��������
	public GameScore score { get; private set; }
	// �Ω󱱨�C�����欰
	public GameController controller { get; private set; }
	[Header("��ܨ�L�� Canvas�]�e���^")]
	public GameObject otherCanvas;

	void Awake()
	{
		instance = this;

		score = GetComponent<GameScore>();
		controller = GetComponent<GameController>();
	}

	/*�b Awake() ��k���A�����N instance �ݩʳ]�m����e�� Game ��ҡC
	 * �o�˥i�H�b��L�a��q�L Game.instance �X�ݳo�ӹ�ҡC

	 *���U�ӡA�ϥ� GetComponent<T>() ��k�A�q��e����W��� GameScore �ե�ñN���ȵ� score �ݩʡC
	 *�o�N���۷�e�� Game ����㦳�@�� GameScore �ե�A�åB�i�H�q�L score �ݩʨӳX�ݸӲե�C

	 *�P�˦a�A�ϥ� GetComponent<T>() ��k�A�q��e����W��� GameController �ե�ñN���ȵ� controller �ݩʡC
	 *�o�N���۷�e�� Game ����㦳�@�� GameController �ե�A�åB�i�H�q�L controller �ݩʨӳX�ݸӲե�C

	 *�`���ӻ��AAwake() ��k�b�C������Q�ЫخɳQ�եΡA���N�]�m Game ���O�� instance �ݩʡB����ó]�m GameScore �M GameController �ե󪺰ѦҡC
	 *�o�˥i�H�b�C���B��������P�a�X�ݳo�ǲե�ð���������ާ@�C
	 */

	void Start()
	{
		isActive = false;


		// ��ܥk���� UI ���O
		menuPanel.gameObject.SetActive(true);
		gamePanel.gameObject.SetActive(false);
		endPanel.gameObject.SetActive(false);

		otherCanvas.SetActive(true);
	}
	/*
	 * �b Start() ��k���A�����N isActive �ݩʳ]�m�� false�A��ܹC���ثe���B�󬡰ʪ��A�C
	 * ���U�ӡA�ե� SetBallReady(false) ��k�A�N ballReady �ݩʳ]�m�� false�A��ܼu�]�ثe���ǳƮg���C
	 * �M��A�q�L�]�m menuPanel�BgamePanel �M endPanel �� gameObject.SetActive(true/false)�A����ܩ����ù����� UI ���O�C
	 * �o�̱N menuPanel �]�m����ܡA�� gamePanel �M endPanel �]�m�����áC
	 * �̫�A�N otherCanvas �� SetActive(true) �]�m���ҥΡA�H��ܨ�L�� Canvas�]�e���^�C

	 �`���ӻ��AStart() ��k�b�C������ҥήɳQ�եΡA���]�m�F�C������l���A�A�]�A�]�m�C�����D���ʪ��A�B
	 �u�]���ǳƮg���B��ܬ����� UI ���O�H�αҥΨ�L�� Canvas�C
	 �o�ǳ]�m�i�H�b�C���}�l�ɧe�{���T����l�e���M���A�C
	*/

	/// <summary>
	/// �}�l�C��, �N�M�Υ��T�����ʨ���ܥk�����O
	/// </summary>
	public void StartGame()
	{
		isActive = true;
		ballCount = ballStartCount;
		ballCountText.text = ballCount.ToString();

		score.ClearScore();

		// ���åk�����O
		menuPanel.gameObject.SetActive(false);
		gamePanel.gameObject.SetActive(true);
		endPanel.gameObject.SetActive(false);

		otherCanvas.SetActive(false);
	}

	/// <summary>
	/// �����C��, �N�M�Υ��T�����ʨ���ܥk�����O
	/// </summary>
	public void EndGame()
	{

		isActive = false;

		otherCanvas.SetActive(true);


		// ���åk�����O
		menuPanel.gameObject.SetActive(false);
		gamePanel.gameObject.SetActive(false);
		endPanel.gameObject.SetActive(true);


	}

}
