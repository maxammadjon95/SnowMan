using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHome : MonoBehaviour
{
    public GameObject[] snowMans;
    int a = 0;
    private void Start()
    {
        snowMans = GameObject.FindGameObjectsWithTag("snowman");
        foreach (GameObject SnowMan in snowMans)
        {
            if (a != 0)
            {
                Destroy(SnowMan);
            }
            a++;
        }
    }
    private void OnMouseUpAsButton()
    {
        SceneManager.LoadScene("Game");
    }
}
