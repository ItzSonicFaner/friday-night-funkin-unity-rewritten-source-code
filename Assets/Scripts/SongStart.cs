using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongStart : MonoBehaviour
{
    [Header("Sounds")]
    public AudioSource source;
    public AudioClip[] audios;

    [Header("Sprite")]
    public Sprite[] sprites;

    [Header("Chart Spawner")]
    ChartSpawner chartSpawner;

    int current = -1;

    void Update()
    {
        chartSpawner = FindObjectOfType<ChartSpawner>();
    }

    public IEnumerator nextAudio()
    {
        current++;

        if (current == 0)
        {
            source.clip = audios[0];
            source.Play();
            gameObject.GetComponent<Animator>().SetTrigger("play");
            gameObject.GetComponent<Image>().SetNativeSize();
        }
        else if (current == 1)
        {
            yield return new WaitUntil(() => !source.isPlaying);

            source.clip = audios[1];
            source.Play();
            gameObject.GetComponent<Animator>().SetTrigger("play");
            gameObject.GetComponent<Image>().sprite = sprites[0];
            gameObject.GetComponent<Image>().SetNativeSize();
        }
        else if (current == 2)
        {
            yield return new WaitUntil(() => !source.isPlaying);

            source.clip = audios[2];
            source.Play();
            gameObject.GetComponent<Animator>().SetTrigger("play");
            gameObject.GetComponent<Image>().sprite = sprites[1];
            gameObject.GetComponent<Image>().SetNativeSize();
        }
        else if (current == 3)
        {
            yield return new WaitUntil(() => !source.isPlaying);

            source.clip = audios[3];
            source.Play();
            gameObject.GetComponent<Animator>().SetTrigger("play");
            gameObject.GetComponent<Image>().sprite = sprites[2];
            gameObject.GetComponent<Image>().SetNativeSize();
        }
        else if (current == 4)
        {
            chartSpawner.CreateChart();
            Destroy(gameObject);
        }
    }
}
