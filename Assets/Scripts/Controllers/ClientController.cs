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

    int progress = 0;
    Transform phases;

    Color neutral = Color.white;
    Color correct = Color.green;
    Color incorrect = Color.red;

    void Start()
    {
        clientList = GetComponentInParent<ClientListController>();

        body = transform.Find("Body");
        phases = transform.Find("Phases");
        
        // Order in the resource tree matters! Topmost question is the first one
        UpdateProgress();
    }

    void UpdateProgress()
    {
        // Even if we leave a few questions active in the editor, this code will deactivate them all
        for (var i = 0; i < phases.childCount; i++)
        {
            phases.GetChild(i).gameObject.SetActive(i == progress);
        }
    }

    public void NextQuestion()
    {
        Debug.Log("Moving on to the next question");
        progress++;
        UpdateProgress();

        if (progress >= phases.childCount)
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
        GetComponentInChildren<Image>().color = correct;
    }

    public void Wrong()
    {
        Debug.Log("That's the wrong answer!");
        GetComponentInChildren<Image>().color = incorrect;
    }
}
