using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHome : MonoBehaviour
{
    public List<GameObject> InterObjects = new List<GameObject>();
    public List<Vector2> InterPositions = new List<Vector2>();
    private void OnMouseUpAsButton()
    {
        SceneManager.LoadScene("Game");
    }
}
