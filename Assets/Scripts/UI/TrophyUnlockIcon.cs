using System.Collections;
using UnityEngine;

public class TrophyUnlockIcon : MonoBehaviour
{
    [SerializeField]
    float duration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DelayedDestroy());
    }

    // Update is called once per frame
    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
