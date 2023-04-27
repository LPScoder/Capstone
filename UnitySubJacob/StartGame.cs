using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string MainFrame;

    public void Start()
    {
        //Change scene to main scene
        SceneManager.LoadScene(MainFrame);
    }
}
