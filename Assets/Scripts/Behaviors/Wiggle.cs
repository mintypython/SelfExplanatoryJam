using System;
using UnityEngine;

public class Wiggle : MonoBehaviour
{
    [SerializeField, Range(0, 1000)]
    float amplitude = 0f;

    [SerializeField, Range(0, 100)]
    float period = 1f;

    public bool active = false;
    float time = 0f;

    void Update()
    {
        if (active)
        {
            time += Time.deltaTime;
        }
        else
        {
            if (time > period)
            {
                time %= period;
            }
            else if (time <= float.Epsilon)
            {
                time = period;
            }

            var max = period;
            if (time <= period / 2)
            {
                max = period / 2;
            }

            time = Math.Min(time + Time.deltaTime * 5, max);
        }

        var angle = Math.Sin(time * 2 * Math.PI / period) * amplitude;
        transform.eulerAngles = new Vector3(0f, 0f, (float)angle);
    }
}
