using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class test : MonoBehaviour
{
    public void OnClick_LoadScene(string SceneObject)
    {
        SceneManager.LoadScene(SceneObject);
    }

}