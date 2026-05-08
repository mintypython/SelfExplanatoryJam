using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Every client will have this component!
/// Whenever you press a button response, this component handles the answer
/// You don't need to do anything special per client, just give them this component
/// </summary>
public class ClientController : MonoBehaviour
{
    ClientListController clientList;

    Transform body;

    int position = 0;
    Transform phases;

    Color neutral = Color.white;
    Color correct = Color.green;
    Color incorrect = Color.red;
    ProgressBarController progress;

    void Awake()
    {
        clientList = GetComponentInParent<ClientListController>();

        body = transform.Find("Body");
        phases = transform.Find("Phases");
    }

    void OnEnable()
    {
        // Order in the resource tree matters! Topmost question is the first one
        UpdateProgress();

        progress = FindAnyObjectByType<ProgressBarController>();
        progress.Initialize(phases.childCount);
    }

    void UpdateProgress()
    {
        // Even if we leave a few questions active in the editor, this code will deactivate them all
        for (var i = 0; i < phases.childCount; i++)
        {
            phases.GetChild(i).gameObject.SetActive(i == position);
        }
    }

    public void NextQuestion()
    {
        body.GetComponent<Image>().color = neutral;
        Debug.Log("Moving on to the next question");
        position++;
        UpdateProgress();

        if (position >= phases.childCount)
        {
            clientList.NextClient();
        }
    }
    
    // We can add an animation here to make the client walk out or something when their convo is over
    public void EndClient()
    {
        Debug.Log("Hit a null path, the conversation with this client is over!");
        FindAnyObjectByType<ClientListController>().NextClient();
    }

    public void Right()
    {
        Debug.Log("That's the correct answer!");
        body.GetComponent<Image>().color = correct;
        progress.SetProgress(position, true);
    }

    public void Wrong()
    {
        Debug.Log("That's the wrong answer!");
        body.GetComponent<Image>().color = incorrect;
        progress.SetProgress(position, false);
    }
}
