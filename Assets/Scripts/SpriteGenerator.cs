using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpriteGenerator : MonoBehaviour
{
    public bool leftPart=false, rightPart=false;
    public bool itsFirst = false;
    public List<GameObject> Prefab = new List<GameObject>();
    public GameObject[] interObjects;
    public GameObject[] snowMans;
    int a = 0;
    private void Start()
    {

        GameObject.Find("snowman").transform.position = new Vector3(0, -0.71f, 0.1f);
        GameObject.Find("snowman").transform.localScale = new Vector3(1, 1, 1);

        interObjects = GameObject.FindGameObjectsWithTag("interactive");

        foreach (GameObject interObjects in interObjects)
        {
            if (interObjects.transform.position.y > -2f)
            {
                interObjects.GetComponent<Collider2D>().enabled = true;
            }
        }

        snowMans = GameObject.FindGameObjectsWithTag("snowman");
        foreach (GameObject SnowMan in snowMans)
        {
            if(a!=0)
            {
                Destroy(SnowMan);
            }
            a++;
        }
    }
    void Update()
    {
        if(leftPart==false)
        {
            leftPart = true;
            GameObject sprite = Instantiate(Prefab[Random.Range(0, Prefab.Count)], new Vector2(-5f,-2.79f), transform.rotation) as GameObject;
            sprite.GetComponent<SpriteLife>().ScaleAnimation();
        }

        if (rightPart == false)
        {
            rightPart = true;
            GameObject sprite = Instantiate(Prefab[Random.Range(0, Prefab.Count)], new Vector2(5f, -2.79f), transform.rotation) as GameObject;
            sprite.GetComponent<SpriteLife>().ScaleAnimation();
        }

    }

    

}
