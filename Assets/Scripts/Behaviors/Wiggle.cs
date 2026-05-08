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
        var rate = 1f;
        if (active)
        {
            if (Math.Abs(Math.Sin(time * 2 * Math.PI / period)) > 0.75f)
            {
                rate /= 3;
            }
            time += Time.deltaTime * rate;
        }
        else
        {
            rate = 5f;
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

            time = Math.Min(time + Time.deltaTime * rate, max);
        }

        var angle = Math.Sin(time * 2 * Math.PI / period) * amplitude;
        transform.eulerAngles = new Vector3(0f, 0f, (float)angle);
    }
}
