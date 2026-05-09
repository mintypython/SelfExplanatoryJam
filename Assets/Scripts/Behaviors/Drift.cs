using System;
using UnityEngine;

public class Drift : MonoBehaviour
{
    [SerializeField]
    Vector2 amplitude;

    [SerializeField]
    Vector2 period;

    Vector2 start;

    Vector2 offset;

    float time = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        start = transform.localPosition;
        offset = new Vector2(
            UnityEngine.Random.Range(0f, period.x),
            UnityEngine.Random.Range(0f, period.y)
        );
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        var sine = new Vector2(
            period.x == 0f ? 0 : (float)Math.Sin((time + offset.x) * 2 * Math.PI / period.x),
            period.y == 0f ? 0 : (float)Math.Sin((time + offset.y) * 2 * Math.PI / period.y)
        );
        transform.localPosition = start + amplitude * sine;
    }
}
