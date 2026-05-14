using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyList : MonoBehaviour
{
    private Dictionary<string, Trophy> trophies;

    void Awake()
    {
        trophies = new();

        var images = GetComponentsInChildren<Image>(true);
        foreach (var image in images)
        {
            image.color = Color.black;
            trophies.Add(image.name, new Trophy(image));
        }
    }

    public void Unlock(string name)
    {
        if (!trophies.TryGetValue(name, out var trophy))
        {
            Debug.Log($"Cannot unlock trophy {name} because it doesn't exist");
            return;
        }

        if (trophy.unlocked)
        {
            Debug.Log($"Cannot unlock trophy {name} because it is already unlocked");
            return;
        }

        Debug.Log($"Unlocked trophy {name}");
        trophy.unlocked = true;
        trophy.image.color = Color.white;
    }

    protected struct Trophy
    {
        public Image image;
        public bool unlocked;

        public Trophy(Image image)
        {
            this.image = image;
            unlocked = false;
        }
    }
}
