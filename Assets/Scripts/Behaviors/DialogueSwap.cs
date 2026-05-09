using UnityEngine;

public class DialogueSwap : MonoBehaviour
{
    CanvasGroup group;

    float time = 0f;

    [SerializeField]
    float duration = 1;

    bool swapping = false;
    GameObject to;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        group = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (!swapping)
        {
            group.interactable = true;
            group.alpha = 1;
            time = 0;
            return;
        }

        var prev = percent;
        time += Time.deltaTime;

        if (prev < 0.5 && percent >= 0.5)
        {
            Clear();
            to.SetActive(true);
            group.interactable = true;
        }
        else if (percent >= 1)
        {
            swapping = false;
        }
        group.alpha = amount;
    }

    public void Swap(GameObject to)
    {
        group = group ?? GetComponent<CanvasGroup>();
        time = 0;
        swapping = true;
        this.to = to;
        group.interactable = false;
    }

    public void InstantSwap(GameObject to)
    {
        Clear();
        group = group ?? GetComponent<CanvasGroup>();
        time = duration / 2;
        swapping = true;
        this.to = to;
        to.SetActive(true);
        group.interactable = true;
    }

    public void Clear()
    {
        var questions = GetComponentsInChildren<Question>();
        foreach (var question in questions)
        {
            question.gameObject.SetActive(false);
        }

        var responses = GetComponentsInChildren<Response>();
        foreach (var response in responses)
        {
            response.gameObject.SetActive(false);
        }
    }

    float percent => time / duration;

    float amount => 4f * (percent - 0.5f) * (percent - 0.5f); 
}
