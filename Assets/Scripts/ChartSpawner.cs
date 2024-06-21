using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChartSpawner : MonoBehaviour
{
    [Header("Chart")]
    public GameObject chartPrefab;
    public GameObject finish;
    public float arrowSpeed;
    public List<GameObject> arrows = new List<GameObject>();
    public Transform parent;

    [Header("Song")]
    public AudioSource song;

    bool startChecking = false;
    bool move = false;

    public void CreateChart()
    {
        GameObject chart = Instantiate(chartPrefab);
        chart.transform.parent = parent;
        chart.transform.localPosition = new Vector3(0, 0, 0);
        chart.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        foreach (Transform arrow in chart.transform)
        {
            if (arrow.gameObject.activeSelf == true)
            {
                arrows.Add(arrow.gameObject);
            }
        }
    }

    bool isOutOfScreen(GameObject arrow)
    {
        if (arrow.GetComponent<RectTransform>().localPosition.y > parent.GetComponent<RectTransform>().sizeDelta.y / 2)
        {
            return true;
        }

        return false;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < arrows.Count; i++)
        {
            if (startChecking == true)
            {
                if (!song.isPlaying)
                {
                    return;
                }
            }

            if (arrows[i] != null)
            {
                if (move)
                {
                    Vector3 vector = new Vector3(arrows[i].transform.position.x, arrows[i].transform.position.y + 1, arrows[i].transform.position.z);

                    arrows[i].transform.position = Vector3.MoveTowards(arrows[i].transform.position, vector, arrowSpeed * Time.deltaTime);
                }

                StartCoroutine(checkForArrow(arrows[i], i));
            }
            else if (arrows[i] == null)
            {
                arrows.RemoveAt(i);
            }
            else if(arrows == null)
            {
                move = false;
            }
        }
    }

    IEnumerator checkForArrow(GameObject arrow, int i)
    {
        yield return new WaitForEndOfFrame();

        if (arrow.transform.localPosition.y < 590.0f)
        {
            if (!song.isPlaying)
            {
                song.Play();
                startChecking = true;
            }

            move = true;
        }
        else if (arrow.transform.localPosition.y >= 590.0f)
        {
            Bar bar = FindObjectOfType<Bar>();

            bar.score -= 10;
            StartCoroutine(bar.increaseFill());
            Destroy(arrow);
            arrows.RemoveAt(i);
            Debug.Log("Miss!");
        }
    }
}
