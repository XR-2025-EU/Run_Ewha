using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quiz_2 : MonoBehaviour
{
    public void OnClickO()
    {
        PlayerPrefs.SetInt("Quiz2Correct", 1);
        Debug.Log("����2 ���� (O)");

    }

    public void OnClickX()
    {
        PlayerPrefs.SetInt("Quiz2Correct", 0);
        Debug.Log("����2 ���� (X)");

    }
}
