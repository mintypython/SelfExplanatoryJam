using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fade() {
        var images = GetComponentsInChildren<Image>();
        foreach (var image in images)
        {
            var c = image.color;
            c.a = 1f;
            image.color = c;
        }
        yield return new WaitForEndOfFrame();
    }
}
