using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Bar bar;
    ChartSpawner chartSpawner;

    void Update()
    {
        bar = FindObjectOfType<Bar>();
        chartSpawner = FindObjectOfType<ChartSpawner>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("Work");

        if (collision.CompareTag("Finish"))
        {
            for(int i = 0; 0 < chartSpawner.arrows.Count; i++)
            {
                if(chartSpawner.arrows[i] == gameObject)
                {
                    bar.score -= 10;
                    bar.decreaseFill();
                    Destroy(gameObject);
                    chartSpawner.arrows.RemoveAt(i);
                    Debug.Log("Miss!");
                }
            }
        }
    }
}
