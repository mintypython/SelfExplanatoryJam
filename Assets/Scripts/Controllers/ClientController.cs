using UnityEditor.PackageManager;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    void Start()
    {
        var questions = transform.Find("Questions");
        foreach (Transform question in questions)
        {
            question.gameObject.SetActive(false);
        }

        questions.GetChild(0).gameObject.SetActive(true);
    }

    public void SubmitAnswer(string answer)
    {
        var question = GetComponentInChildren<Question>();
        if (question is null)
        {
            Debug.LogError("Question not found - is no question being asked?");
        }

        var response = question.Resolve(answer);
        if (response.status == ResponseStatus.CORRECT)
        {
            Debug.Log("That's right!");
        }
        else if (response.status == ResponseStatus.CORRECT)
        {
            Debug.Log("That's wrong!");
        }
        else
        {
            Debug.Log("That's... fine...");
        }

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
    
    public void EndClient()
    {
        Debug.Log("Hit a null path, the conversation with this client is over!");
        FindAnyObjectByType<ClientListManager>().NextClient();
    }
}
