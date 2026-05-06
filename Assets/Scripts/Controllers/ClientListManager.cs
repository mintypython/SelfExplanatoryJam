using UnityEngine;

/// <summary>
/// This component handles changing from one client to another
/// When NextClient() is called, the current client is turned off and the next one turned on
/// If no clients are left, the game is over!
/// </summary>
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
