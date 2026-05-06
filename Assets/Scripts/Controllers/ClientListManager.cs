using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class ClientListManager : MonoBehaviour
{
    [SerializeField]
    int progress = 0;

    void Start()
    {
        UpdateProgress();
    }

    void UpdateProgress()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        transform.GetChild(progress).gameObject.SetActive(true);
    }

    public void NextClient()
    {
        progress++;

        if (progress < transform.childCount) {
            UpdateProgress();
        }
        else
        {
            Debug.Log("The game is over!");
        }
    }
}
