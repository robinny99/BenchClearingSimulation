using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("InGameBCS 2");
    }
}
