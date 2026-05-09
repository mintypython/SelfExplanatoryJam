using System;
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
    Color positive = Color.green;
    Color negative = Color.red;
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
        Clear();
        
        progress = FindAnyObjectByType<ProgressBarController>();
        progress.Initialize(phases.childCount);

        var firstQuestion = GetComponentInChildren<Question>(true);
        firstQuestion.gameObject.SetActive(true);
    }

    void Clear()
    {
        var questions = GetComponentsInChildren<Question>();
        foreach (var question in questions)
        {
            question.gameObject.SetActive(false);
        }

        var responses = GetComponentsInChildren<Response>();
        foreach (var response in responses)
        {
            response.gameObject.SetActive(false);
        }
    }

    public void NextQuestion(GameObject next)
    {
        body.GetComponent<Image>().color = neutral;
        Debug.Log("Moving on to the next question");
        position++;

        Clear();
        if (next == null)
        {
            clientList.NextClient();
        }
        else
        {
            next.SetActive(true);
        }
    }
    
    // We can add an animation here to make the client walk out or something when their convo is over
    public void EndClient()
    {
        Debug.Log("Hit a null path, the conversation with this client is over!");
        FindAnyObjectByType<ClientListController>().NextClient();
    }

    public void ReceiveAnswer(Answer answer)
    {
        switch (answer.reaction)
        {
            case ClientReaction.POSITIVE:
                body.GetComponent<Image>().color = positive;
                break;

            case ClientReaction.NEGATIVE:
                body.GetComponent<Image>().color = negative;
                break;
            default:
                break;
        }
        progress.SetProgress(position, true);
        NextQuestion(answer.leadsTo);
    }
}

[Serializable]
public enum ClientReaction
{
    NEUTRAL,
    POSITIVE,
    NEGATIVE
}

public enum ClientSatisfaction
{
    NEUTRAL,
    HAPPY,
    ANGRY
}