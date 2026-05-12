using System.Collections;
using UnityEngine;

/// <summary>
/// This component handles changing from one client to another
/// When NextClient() is called, the current client is turned off and the next one turned on
/// If no clients are left, the game is over!
/// </summary>
public class ClientListController : MonoBehaviour
{
    [SerializeField]
    int position = 0;

    Client current;

    void Start()
    {
        ClearClients();

        var swoops = GetComponentsInChildren<Swoop>(true);
        foreach (var swoop in swoops)
        {
            swoop.Initialize();
            swoop.ToStart();
        }
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(1);
        UpdateClients();
    }

    void ClearClients()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    void UpdateClients()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == position);
        }
    }

    public void NextClient()
    {
        var progressBar = FindAnyObjectByType<ProgressBar>();
        position++;
        UpdateClients();
        if (position >= transform.childCount)
        {
            progressBar?.gameObject?.SetActive(false);
            Debug.Log("The game is over!");
        }
    }
}
