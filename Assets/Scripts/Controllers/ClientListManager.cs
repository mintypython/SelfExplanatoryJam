using UnityEngine;

public class ClientListManager : MonoBehaviour
{
    [SerializeField]
    int progress = 0;

    void Start()
    {
        Clear();
        ActivateCurrentClient();
    }

    void ActivateCurrentClient()
    {
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
        Clear();
        if (progress < transform.childCount) {
            ActivateCurrentClient();
        }
        else
        {
            FindAnyObjectByType<Option>().transform.parent.gameObject.SetActive(false);
            Debug.Log("The game is over!");
        }
    }
}
