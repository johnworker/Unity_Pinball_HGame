using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    // UI���sĲ�o�C���������J
    public void StartGame()
    {
        SceneManager.LoadScene("���ռu�]�x");

        /*
        Scene otherScene = SceneManager.GetSceneByName("OtherScene");

        GameObject[] rootObjects = otherScene.GetRootGameObjects();

        foreach (GameObject obj in rootObjects)
        {
            Game gameSet = obj.GetComponent<Game>();
            if (gameSet != null)
            {
                // �X�ݥ��L���ܶq
                bool otherBoolValue = gameSet.isActive;
                // �b�o�̨ϥ�otherBoolValue���A�Q�n���ާ@

                otherBoolValue = true;
                break;
            }
        }
        */

    }


    public void EndGame()
    {
        SceneManager.LoadScene("�}�l�e��");
    }
}