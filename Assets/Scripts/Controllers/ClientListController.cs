using UnityEngine;

/// <summary>
/// This component handles changing from one client to another
/// When NextClient() is called, the current client is turned off and the next one turned on
/// If no clients are left, the game is over!
/// </summary>
public class ClientListController : MonoBehaviour
{
    [SerializeField]
    int progress = 0;

    void Start()
    {
        UpdateClients();
    }

    void UpdateClients()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == progress);
        }
    }

    public void NextClient()
    {
        progress++;
        UpdateClients();
        if (progress >= transform.childCount)
        {
            Debug.Log("The game is over!");
        }
    }
}
