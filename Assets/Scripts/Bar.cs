using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [Header("Stats")]
    public int score;
    public TMP_Text statsText;

    [Header("Bar Fill")]
    public GameObject fill;
    public float minFillValue = 0.0f;
    public float maxFillValue = 600.0f;

    Vector2 scale;
    bool change = true;

    void Update()
    {
        statsText.text = "Score:" + score.ToString();

        if(change)
        {
            scale = fill.GetComponent<RectTransform>().sizeDelta;
        }
    }

    public IEnumerator decreaseFill()
    {
        scale.x -= 15;

        while (fill.GetComponent<RectTransform>().sizeDelta.x != scale.x)
        {
            if (fill.GetComponent<RectTransform>().sizeDelta != new Vector2(maxFillValue, fill.GetComponent<RectTransform>().sizeDelta.y))
            {
                change = false;

                yield return new WaitForEndOfFrame();

                fill.GetComponent<RectTransform>().sizeDelta = Vector2.MoveTowards(fill.GetComponent<RectTransform>().sizeDelta,
                    new Vector2(scale.x, fill.GetComponent<RectTransform>().sizeDelta.y), 15.0f * Time.deltaTime);
            }
            if (fill.GetComponent<RectTransform>().sizeDelta == new Vector2(maxFillValue, fill.GetComponent<RectTransform>().sizeDelta.y))
            {
                change = true;
                yield break;
            }
        }
    }

    public IEnumerator increaseFill()
    {
        scale.x += 15;

        while (fill.GetComponent<RectTransform>().sizeDelta.x != scale.x)
        {
            if (fill.GetComponent<RectTransform>().sizeDelta != new Vector2(maxFillValue, fill.GetComponent<RectTransform>().sizeDelta.y))
            {
                change = false;

                yield return new WaitForEndOfFrame();

                fill.GetComponent<RectTransform>().sizeDelta = Vector2.MoveTowards(fill.GetComponent<RectTransform>().sizeDelta,
                    new Vector2(scale.x, fill.GetComponent<RectTransform>().sizeDelta.y), 15.0f * Time.deltaTime);
            }
            if (fill.GetComponent<RectTransform>().sizeDelta == new Vector2(maxFillValue, fill.GetComponent<RectTransform>().sizeDelta.y))
            {
                change = true;
                yield break;
            }
        }
    }
}
