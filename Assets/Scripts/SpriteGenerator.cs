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
