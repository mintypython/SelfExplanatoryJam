using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField]
    Sprite onSprite;

    [SerializeField]
    Sprite offSprite;

    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void ToggleVolume()
    {
        var listener = FindAnyObjectByType<AudioListener>();
        listener.enabled = !listener.enabled;

        image.sprite = listener.enabled ? onSprite : offSprite;
    }
}
