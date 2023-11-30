using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMain : MonoBehaviour
{

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadScene(int sceneNr)
    {
        SceneManager.LoadScene(sceneNr);
    }

}
