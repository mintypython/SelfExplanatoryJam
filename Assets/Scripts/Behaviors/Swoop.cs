using System;
using UnityEngine;

public class Swoop : MonoBehaviour
{
    bool swooping = false;

    public event Action OnEnd;
    float at = 1.0f;

    [SerializeField]
    Vector2 offset;

    Vector2 origin;

    Vector2 start;
    Vector2 end;

    float time = 0f;

    [SerializeField]
    float inDuration = 1f;

    [SerializeField]
    float outDuration = 1f;

    float duration = 1f;

    bool initialized = false;

    private readonly Ease.Shape inShape = Ease.Shapes.OUT_ELASTIC;
    private readonly Ease.Shape outShape = Ease.Shapes.IN_SINE;

    private Ease.Shape shape;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (initialized)
        {
            return;
        }

        shape = inShape;
        time = 0f;
        origin = transform.localPosition;
        initialized = true;
        ToStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (!swooping)
        {
            return;
        }

        time += Time.deltaTime;

        var amt = shape(time / duration);
        transform.localPosition = start + (end - start) * amt;

        var p = time / duration;
        if (p >= at && OnEnd != null)
        {
            OnEnd?.Invoke();
            OnEnd = null;
        }

        if (time >= duration) {
            transform.localPosition = end;
            time = 0;
            swooping = false;
        }
    }

    public void In(Action action = null, float at = 1.0f)
    {
        Initialize();
        shape = inShape;
        start = origin + offset;
        end = origin;

        ToStart();
        swooping = true;
        if (action != null)
        {
            OnEnd = action;
            this.at = at;
        }
    }

    public void Out(Action action = null, float at = 1.0f)
    {
        Initialize();
        shape = outShape;
        start = origin + offset;
        end = origin;

        ToEnd();
        swooping = true;
        if (action != null)
        {
            OnEnd = action;
            this.at = at;
        }
    }
    
    public void ToStart()
    {
        Initialize();
        start = origin + offset;
        end = origin;

        transform.localPosition = start;
        time = 0;
        duration = inDuration;
        swooping = false;
    }

    public void ToEnd()
    {
        Initialize();
        start = origin;
        end = origin + offset;

        transform.localPosition = start;
        time = 0;
        duration = outDuration;
        swooping = false;
    }
}
