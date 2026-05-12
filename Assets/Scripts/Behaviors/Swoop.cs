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

    [SerializeField]
    SWOOP_TYPE inShape;

    [SerializeField]
    SWOOP_TYPE outShape;

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

        shape = GetShape(inShape);
        time = 0f;
        origin = transform.localPosition;
        initialized = true;
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
        shape = GetShape(inShape);
        start = transform.localPosition;
        end = origin + offset;
        swooping = true;
        time = 0f;
        duration = inDuration;
        if (action != null)
        {
            OnEnd = action;
            this.at = at;
        }
    }

    public void Out(Action action = null, float at = 1.0f)
    {
        Initialize();
        shape = GetShape(outShape);
        start = transform.localPosition;
        end = origin;
        swooping = true;
        time = 0f;
        duration = outDuration;
        if (action != null)
        {
            OnEnd = action;
            this.at = at;
        }
    }
    
    public void ToStart()
    {
        Initialize();
        start = origin;
        end = origin + offset;

        transform.localPosition = start;
        time = 0;
        duration = inDuration;
        swooping = false;
    }

    public void ToEnd()
    {
        Initialize();
        start = origin + offset;
        end = origin;

        transform.localPosition = start;
        time = 0;
        duration = outDuration;
        swooping = false;
    }

    public Ease.Shape GetShape(SWOOP_TYPE type)
    {
        switch (type)
        {
            case SWOOP_TYPE.ELASTIC:
                return Ease.Shapes.OUT_ELASTIC;

            case SWOOP_TYPE.BACK:
                return Ease.Shapes.OUT_BACK;

            case SWOOP_TYPE.BOUNCE:
                return Ease.Shapes.OUT_BOUNCE;

            default:
                return Ease.Shapes.IN_SINE;
        }
    }
}

public enum SWOOP_TYPE
{
    ELASTIC,
    SINE,
    BACK,
    BOUNCE
}