using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLife : MonoBehaviour
{
    public string whichPart;
    public AudioClip clickSound, pasteSound, generateSound;
    public List<Sprite> myImages = new List<Sprite>();

    private float startPosX, startPosY;
    private bool isHeld = false;
    private bool isInside = false;
    private bool isLeft = false;
    private bool isNew = true;
    private GameObject spr_object;
    private AudioSource myAudio;
    private SpriteRenderer mySprite;
    private void Start()
    {
        spr_object = GameObject.Find("spritesGen").gameObject;
        
        myAudio = gameObject.GetComponent<AudioSource>();
        myAudio.PlayOneShot(generateSound);
       
        mySprite = gameObject.GetComponent<SpriteRenderer>();
        mySprite.sprite = myImages[Random.Range(0, myImages.Count)];
    }
    private void Update()
    {
        if (isHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x-startPosX, mousePos.y- startPosY, 0);
        }
        
        if(isInside == true)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }

        if(gameObject.transform.position.y<-5.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isHeld = true;

            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            if (transform.position.x<0)
            {
                isLeft = true;
            }
            else if (transform.position.x > 0)
            {
                isLeft = false;
            }
            myAudio.PlayOneShot(clickSound);
            ScaleAnimation();
        }
    }

    public void ScaleAnimation()
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        StartCoroutine(ScaleAnim());
    }

    IEnumerator ScaleAnim()
    {
        yield return new WaitForSeconds(0.13f);
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void OnMouseUp()
    {
        isHeld = false;
        ScaleAnimation();
        myAudio.PlayOneShot(pasteSound);
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        if(isNew)
        {
            if(isLeft)
                spr_object.GetComponent<SpriteGenerator>().leftPart = false;
            else
                spr_object.GetComponent<SpriteGenerator>().rightPart = false;
            isNew = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(whichPart))
        {
            isInside = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(whichPart))
        {
            isInside = false;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(whichPart))
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

}

