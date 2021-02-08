using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation2D : MonoBehaviour
{
    // Start is called before the first frame update
    //SpriteRenderer girl1RunningLeft;
    GameObject girl1RunningLeft;
    GameObject girl1KickingLeft;
    GameObject girl1RunningRight;
    GameObject girl1KickingRight;
    GameObject girl1ThrowingLeft;
    GameObject girl1ThrowingRight;

    GameObject girl2RunningLeft;
    GameObject girl2KickingLeft;
    GameObject girl2RunningRight;
    GameObject girl2KickingRight;
    GameObject girl2ThrowingLeft;
    GameObject girl2ThrowingRight;
    float timer;
    void Start()
    {
        //girl1RunningLeft = GameObject.Find("girl1RunningLeft").GetComponent<SpriteRenderer>();
        girl1RunningLeft = GameObject.Find("girl1RunningLeft");
        girl1RunningLeft.gameObject.SetActive(false);
        girl1RunningRight = GameObject.Find("girl1RunningRight");
        girl1RunningRight.gameObject.SetActive(false);
        girl1KickingLeft = GameObject.Find("girl1KickingLeft");
        girl1KickingLeft.gameObject.SetActive(false);
        girl1KickingRight = GameObject.Find("girl1KickingRight");
        girl1KickingRight.gameObject.SetActive(false);
        girl1ThrowingLeft = GameObject.Find("girl1ThrowingLeft");
        girl1ThrowingLeft.gameObject.SetActive(false);
        girl1ThrowingRight = GameObject.Find("girl1ThrowingRight");
        girl1ThrowingRight.gameObject.SetActive(false);

        girl2RunningLeft = GameObject.Find("girl2RunningLeft");
        girl2RunningLeft.gameObject.SetActive(false);
        girl2RunningRight = GameObject.Find("girl2RunningRight");
        girl2RunningRight.gameObject.SetActive(false);
        girl2KickingLeft = GameObject.Find("girl2KickingLeft");
        girl2KickingLeft.gameObject.SetActive(false);
        girl2KickingRight = GameObject.Find("girl2KickingRight");
        girl2KickingRight.gameObject.SetActive(false);
        girl2ThrowingLeft = GameObject.Find("girl2ThrowingLeft");
        girl2ThrowingLeft.gameObject.SetActive(false);
        girl2ThrowingRight = GameObject.Find("girl2ThrowingRight");
        girl2ThrowingRight.gameObject.SetActive(false);
        timer = 2f;
        changeAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        if(timer <= 0)
        {
            hideAnimations();
            changeAnimation();
        }
    }

    void hideAnimations()
    {
        girl1RunningLeft.gameObject.SetActive(false);
        girl1RunningRight.gameObject.SetActive(false);
        girl1KickingLeft.gameObject.SetActive(false);
        girl1KickingRight.gameObject.SetActive(false);
        girl1ThrowingLeft.gameObject.SetActive(false);
        girl1ThrowingRight.gameObject.SetActive(false);

        girl2RunningLeft.gameObject.SetActive(false);
        girl2RunningRight.gameObject.SetActive(false);
        girl2KickingLeft.gameObject.SetActive(false);
        girl2KickingRight.gameObject.SetActive(false);
        girl2ThrowingLeft.gameObject.SetActive(false);
        girl2ThrowingRight.gameObject.SetActive(false);
    }

    void changeAnimation()
    {
        timer = 2f;
        int animationNumber = Random.Range(0, 6);
        if(animationNumber == 0)
        {
            girl1RunningLeft.gameObject.SetActive(true);
            girl2RunningRight.gameObject.SetActive(true);
        } else if(animationNumber == 1)
        {
            girl2RunningLeft.gameObject.SetActive(true);
            girl1RunningRight.gameObject.SetActive(true);
        } else if(animationNumber == 2)
        {
            girl1KickingLeft.gameObject.SetActive(true);
            girl2KickingRight.gameObject.SetActive(true);
        } else if(animationNumber == 3)
        {
            girl1KickingRight.gameObject.SetActive(true);
            girl2KickingLeft.gameObject.SetActive(true);
        }
        else if (animationNumber == 4)
        {
            girl1ThrowingLeft.gameObject.SetActive(true);
            girl2ThrowingRight.gameObject.SetActive(true);
        }
        else if (animationNumber == 5)
        {
            girl1ThrowingRight.gameObject.SetActive(true);
            girl2ThrowingLeft.gameObject.SetActive(true);
        }
    }
}
