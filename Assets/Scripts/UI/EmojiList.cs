using UnityEngine;

public class EmojiList : MonoBehaviour
{
    [SerializeField]
    float delay;

    float time = 0f;

    int progress = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        time = 0;
        progress = 0;
        Next();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > delay)
        {
            Next();
            time -= delay;
        }
    }

    void Next() {
        if (progress >= transform.childCount)
        {
            return;
        }

        transform.GetChild(progress).gameObject.GetComponent<Animator>().SetTrigger("Grow");
        progress++;
    }
}
