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
        Clear();
        transform.GetChild(progress).gameObject.SetActive(true);
    }

    void Clear()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
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
