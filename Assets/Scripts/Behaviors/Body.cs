using System;
using UnityEngine;
using UnityEngine.UI;

public class Body : MonoBehaviour
{
    [SerializeField]
    float duration = 1f;
    float time = 0f;

    [SerializeField]
    float amplitude = 1f;

    Image image;

    Sprite newSprite = null;

    bool swapping = false;

    void Awake()
    {
        image = GetComponent<Image>();
        time = 0f;

        transform.localScale = Vector3.one;
    }

    void Update()
    {
        if (swapping)
        {
            time += Time.deltaTime;
            time = Math.Min(time, duration);
            if (newSprite != null && time / duration >= 0.5)
            {
                image.sprite = newSprite;
                newSprite = null;
            }

            transform.localScale = new Vector3(1f, (1 - amplitude) + amplitude * equation(time / duration), 1f);

            if (time >= duration)
            {
                time = duration;
                swapping = false;
            }
        }
        else
        {
            time = 0f;
        }
    }

    public void ChangeSprite(Sprite sprite)
    {
        if (sprite == null || image.sprite == sprite)
        {
            return;
        }

        newSprite = sprite;
        time = 0f;
        swapping = true;
    }

    private float equation(float percentage)
    {
        if (percentage <= 0.5)
        {
            return 1 - (percentage * 2) * (percentage * 2);
        }

        return 1 - ((percentage - 1) * 2) * ((percentage - 1) * 2);
    }
}
