using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitApp : MonoBehaviour
{
    public GameObject ExitPanel;
    public void QuitButton()
    {
        ExitPanel.SetActive(true);
    }
    public void ApplicationExit()
    {
        Application.Quit();
    }
    public void BackButton()
    {
        ExitPanel.SetActive(false);
    }

}
