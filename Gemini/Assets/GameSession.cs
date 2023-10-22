using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] int[] deathTimers;
    [SerializeField] Player normal;
    [SerializeField] Player flipped;

    int pointer;

    // Start is called before the first frame update
    void Start()
    {
        pointer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death(bool isFlipped)
    {
        //Debug.Log(isFlipped);
        pointer += 1;
        if (pointer == deathTimers.Length)
        {
            //TODO: Lose
        }

        else if (isFlipped)
        {
            //Debug.Log("flipped");
            flipped.GetComponent<SpriteRenderer>().enabled = false;
            //flipped.GetComponent<BoxCollider2D>().enabled = false;
            flipped.isActive = false;
            flipped.GetComponent<BoxCollider2D>().isTrigger = true;
            StartCoroutine(TimerActivation(isFlipped));
        }
        else
        {
            //Debug.Log("normal");
            normal.GetComponent<SpriteRenderer>().enabled = false;
            normal.GetComponent<BoxCollider2D>().enabled = false;
            normal.isActive = false;
            //normal.GetComponent<BoxCollider2D>().isTrigger = true;
            StartCoroutine(TimerActivation(isFlipped));
        }
    }

    IEnumerator TimerActivation(bool isFlipped)
    {
        yield return new WaitForSecondsRealtime(deathTimers[pointer]);
        if (isFlipped)
        {
            flipped.GetComponent<SpriteRenderer>().enabled = true;
            //flipped.GetComponent<BoxCollider2D>().enabled = true;
            flipped.isActive = true;
            flipped.GetComponent<BoxCollider2D>().isTrigger = false;
            //flipped.gameObject.SetActive(true);
        }
        else
        {
            normal.GetComponent<SpriteRenderer>().enabled = true;
            normal.GetComponent<BoxCollider2D>().enabled = true;
            normal.isActive = true;
            //normal.GetComponent<BoxCollider2D>().isTrigger = false;
            //normal.gameObject.SetActive(true);
        }   
    }
}
