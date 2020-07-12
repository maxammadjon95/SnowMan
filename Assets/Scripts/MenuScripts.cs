using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    public GameObject[] interObjects;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMenu();
        }
    }


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
            if(interObjects.transform.position.y>-2f)
            {
                interObjects.transform.parent = GameObject.Find("snowman").transform;
                interObjects.GetComponent<Collider2D>().enabled = false;
                interObjects.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
        GameObject.Find("snowman").transform.position = new Vector3(5.76f, -0.13f, 0.1f);
        GameObject.Find("snowman").transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }




}
