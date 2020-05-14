using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTOGame : MonoBehaviour
{
    public void BackToGame()
    {
        SceneManager.LoadScene(0);
    }
}
