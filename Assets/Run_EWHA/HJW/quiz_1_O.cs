using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quiz_1_O : MonoBehaviour
{

    public void OnClickO()
    {
        PlayerPrefs.SetInt("Quiz1Correct", 1);
        Debug.Log("ДыБо1 Б¤ґд (O)");
        
    }

    public void OnClickX()
    {
        PlayerPrefs.SetInt("Quiz1Correct", 0);
        Debug.Log("ДыБо1 їАґд (X)");
        
    }
}
