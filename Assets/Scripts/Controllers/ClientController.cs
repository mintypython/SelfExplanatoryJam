using UnityEngine;

/// <summary>
/// Every client will have this component!
/// Whenever you press a button response, this component handles the answer
/// You don't need to do anything special per client, just give them this component
/// </summary>
public class ClientManager : MonoBehaviour
{
    void Start()
    {
        // Even if we leave a few questions active in the editor, this code will deactivate them all
        var questions = transform.Find("Questions");
        foreach (Transform question in questions)
        {
            question.gameObject.SetActive(false);
        }

        // Order in the resource tree matters! Topmost question is the first one
        questions.GetChild(0).gameObject.SetActive(true);
    }

    // All option buttons now run this function
    // For more context on what's going on here, look at the Question class
    public void SubmitAnswer(string answer)
    {
        var question = GetComponentInChildren<Question>();

        // Theoretically this should never happen, we can only see this message if a client has zero questions
        if (question is null)
        {
            Debug.LogError("Question not found - is no question being asked?");
        }

        // "Resolve" checks to see if your answer is correct, incorrect, or neutral
        // A "correct" answer means you gain a heart, "incorrect" means you lose one, "neutral" means no change
        var response = question.Resolve(answer);
        switch (response.status)
        {
            case ResponseStatus.CORRECT:
                Debug.Log("That's right!");
                break;

            case ResponseStatus.INCORRECT:
                Debug.Log("That's right!");
                break;

            default:
                Debug.Log("That's fine");
                break;
        }

        // We then turn off the current question and move on to the next
        question.gameObject.SetActive(false);
        if (response.leadsTo == null)
        {
            EndClient();
        }
        else
        {
            response.leadsTo.SetActive(true);
        }
    }
    
    // We can add an animation here to make the client walk out or something when their convo is over
    public void EndClient()
    {
        Debug.Log("Hit a null path, the conversation with this client is over!");
        FindAnyObjectByType<ClientListManager>().NextClient();
    }
}
