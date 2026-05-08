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

    void Start()
    {
        UpdateClients();
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
        var progressBar = FindAnyObjectByType<ProgressBarController>();
        switch (progressBar.Evaluate())
        {
            case ProgressBarController.ClientSatisfaction.HAPPY:
                Debug.Log("The client was very satisfied!");
                break;

            case ProgressBarController.ClientSatisfaction.ANGRY:
                Debug.Log("The client was very angry with you!");
                break;

            default:
                break;
        }
        position++;
        UpdateClients();
        if (position >= transform.childCount)
        {
            progressBar.gameObject.SetActive(false);
            Debug.Log("The game is over!");
        }
    }
}
