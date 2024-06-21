using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [Header("Movement")]
    public GameObject[] arrows;

    public enum ArrowType { up, down, left, right };
    public ArrowType type;

    [Header("Player")]
    public GameObject player;

    bool pressed = false;
    bool animNNote;
    bool animNote;

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(type == ArrowType.up)
        {
            arrows = GameObject.FindGameObjectsWithTag("arrowUp");

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                arrowFunction();

                if (animNNote)
                {
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", true);
                }
                else if (animNote)
                {
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", true);
                }
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            {
                player.GetComponent<Animator>().SetBool("repeatAnim", false);

                if (animNNote)
                {
                    animNNote = false;
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", false);
                }
                else if (animNote)
                {
                    player.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

                    animNote = false;
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", false);
                }
            }
        }
        else if (type == ArrowType.down)
        {
            arrows = GameObject.FindGameObjectsWithTag("arrowDown");

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                arrowFunction();

                if (animNNote)
                {
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", true);
                }
                else if (animNote)
                {
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", true);
                }
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            {
                player.GetComponent<Animator>().SetBool("repeatAnim", false);

                if (animNNote)
                {
                    animNNote = false;
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", false);
                }
                else if (animNote)
                {
                    player.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

                    animNote = false;
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", false);
                }
            }
        }
        else if (type == ArrowType.left)
        {
            arrows = GameObject.FindGameObjectsWithTag("arrowLeft");

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                arrowFunction();

                if (animNNote)
                {
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", true);
                }
                else if (animNote)
                {
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", true);
                }
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                player.GetComponent<Animator>().SetBool("repeatAnim", false);

                if (animNNote)
                {
                    animNNote = false;
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", false);
                }
                else if (animNote)
                {
                    player.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

                    animNote = false;
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", false);
                }
            }
        }
        else if (type == ArrowType.right)
        {
            arrows = GameObject.FindGameObjectsWithTag("arrowRight");

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                arrowFunction();

                if (animNNote)
                {
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", true);
                }
                else if (animNote)
                {
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", true);
                }
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                player.GetComponent<Animator>().SetBool("repeatAnim", false);

                if (animNNote)
                {
                    animNNote = false;
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", false);
                }
                else if (animNote)
                {
                    player.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

                    animNote = false;
                    gameObject.GetComponent<Animator>().SetBool("repeatAnimNote", false);
                }
            }
        }
    }

    void arrowFunction()
    {
        for(int i = 0; i < arrows.Length; i++)
        {
            if (arrows[i] != null && arrows != null && transform.localPosition.y > arrows[i].GetComponent<RectTransform>().localPosition.y - 100 &&
                 transform.localPosition.y < arrows[i].GetComponent<RectTransform>().localPosition.y + 100)
            {
                Bar bar = FindObjectOfType<Bar>();
                bool animEnded = false;
                pressed = true;

                if(type == ArrowType.up)
                {
                    player.GetComponent<Animator>().SetTrigger("upPress");
                    player.GetComponent<Animator>().SetBool("repeatAnim", true);
                    player.transform.localPosition = new Vector3(0.41f, 0.24f, 0.0f);
                }
                else if (type == ArrowType.down)
                {
                    player.GetComponent<Animator>().SetTrigger("downPress");
                    player.GetComponent<Animator>().SetBool("repeatAnim", true);
                    player.transform.localPosition = new Vector3(0f, -0.4f, 0.0f);
                }
                else if (type == ArrowType.left)
                {
                    player.GetComponent<Animator>().SetTrigger("leftPress");
                    player.GetComponent<Animator>().SetBool("repeatAnim", true);
                    player.transform.localPosition = new Vector3(-0.27f, -0.07f, 0.0f);
                }
                else if (type == ArrowType.right)
                {
                    player.GetComponent<Animator>().SetTrigger("rightPress");
                    player.GetComponent<Animator>().SetBool("repeatAnim", true);
                    player.transform.localPosition = new Vector3(0.65f, -0.07f, 0.0f);
                }

                gameObject.GetComponent<Animator>().SetTrigger("pressed");

                if (transform.localPosition.y >= arrows[i].GetComponent<RectTransform>().localPosition.y - 100 &&
                    transform.localPosition.y < arrows[i].GetComponent<RectTransform>().localPosition.y - 50)
                {
                    Debug.Log("Shit");
                    bar.score += 50;
                    animEnded = true;
                    animNote = true;
                }
                else if (transform.localPosition.y >= arrows[i].GetComponent<RectTransform>().localPosition.y - 50 &&
                    transform.localPosition.y < arrows[i].GetComponent<RectTransform>().localPosition.y - 25)
                {
                    Debug.Log("Bad");
                    bar.score += 100;
                    animEnded = true;
                    animNote = true;
                }
                else if (transform.localPosition.y >= arrows[i].GetComponent<RectTransform>().localPosition.y - 25 &&
                    transform.localPosition.y < arrows[i].GetComponent<RectTransform>().localPosition.y - 10)
                {
                    Debug.Log("Good!");
                    bar.score += 200;
                    animEnded = true;
                    animNote = true;
                }
                else if (transform.localPosition.y >= arrows[i].GetComponent<RectTransform>().localPosition.y - 10 &&
                    transform.localPosition.y < arrows[i].GetComponent<RectTransform>().localPosition.y + 10)
                {
                    Debug.Log("Perfect!");
                    bar.score += 350;
                    animEnded = true;
                    animNote = true;
                }
                else if (transform.localPosition.y >= arrows[i].GetComponent<RectTransform>().localPosition.y + 10 &&
                    transform.localPosition.y < arrows[i].GetComponent<RectTransform>().localPosition.y + 25)
                {
                    Debug.Log("Good!");
                    bar.score += 200;
                    animEnded = true;
                    animNote = true;
                }
                else if (transform.localPosition.y >= arrows[i].GetComponent<RectTransform>().localPosition.y + 25 &&
                    transform.localPosition.y < arrows[i].GetComponent<RectTransform>().localPosition.y + 50)
                {
                    Debug.Log("Bad");
                    bar.score += 100;
                    animEnded = true;
                    animNote = true;
                }
                else if (transform.localPosition.y >= arrows[i].GetComponent<RectTransform>().localPosition.y + 50 &&
                    transform.localPosition.y < arrows[i].GetComponent<RectTransform>().localPosition.y + 100)
                {
                    Debug.Log("Shit");
                    bar.score += 50;
                    animEnded = true;
                    animNote = true;
                }

                StartCoroutine(bar.decreaseFill());

                StartCoroutine(checkForAnimEnded(animEnded));
                Destroy(arrows[i]);
                return;
            }
        }

        if (!pressed)
        {
            gameObject.GetComponent<Animator>().SetTrigger("pressedNN");
            animNNote = true;
        }
    }

    IEnumerator checkForAnimEnded(bool animEnded)
    {
        yield return new WaitUntil(() => animEnded);
        pressed = false;
    }
}
