using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    public GameObject[] interObjects;
    public static List<GameObject> InterObjects = new List<GameObject>();
    public static List<Vector2> InterPositions = new List<Vector2>();

    public void BackToMenu()
    {
        ObjectsPositions();
        SceneManager.LoadScene("Menu");
    }

    private void ObjectsPositions()
    {
        interObjects = GameObject.FindGameObjectsWithTag("interactive");

        foreach (GameObject interObjects in interObjects)
        {
            if (interObjects.transform.position.y > -2f)
            {
                InterObjects.Add(interObjects);
                InterPositions.Add(interObjects.transform.position);
            }
        }
    }

    private void Start()
    {
        if(InterObjects!=null)
        Debug.Log(InterObjects[0]);
    }


}
