using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HJW_moving_scene : MonoBehaviour
{
    public void OnClick_LoadScene(string SceneObject)
    {
        SceneManager.LoadScene(SceneObject);
    }

}