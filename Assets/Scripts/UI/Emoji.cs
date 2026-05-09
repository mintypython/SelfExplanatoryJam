using UnityEngine;

public class Emoji : MonoBehaviour
{
    [SerializeField]
    float waitTime;

    float time = 0f;

    Animator ac;

    void Awake()
    {
        ac = GetComponent<Animator>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= waitTime)
        {
            ac.SetTrigger("Grow");
            enabled = false;//What is enabled? - Syd
        }
    }
}
