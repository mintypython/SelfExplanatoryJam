using System;
using UnityEngine;

public class Question : MonoBehaviour
{
    [SerializeField]
    Answer defaultResponse;

    [SerializeField]
    Response[] responses;

    public Answer Resolve(string answer)
    {
        var index = Array.FindIndex(responses, e => e.name.ToLower().Trim() == answer.ToLower().Trim());
        if (index == -1)
        {
            return defaultResponse;
        }
        
        var response = responses[index];
        return new Answer()
        {
            status = response.status,
            leadsTo = response.leadsTo
        };
    }
}

[Serializable]
public struct Response
{
    public string name;
    public ResponseStatus status;
    public GameObject leadsTo;
}

public enum ResponseStatus
{
    NEUTRAL,
    CORRECT,
    INCORRECT
}

[Serializable]
public struct Answer
{
    public ResponseStatus status;
    public GameObject leadsTo;
}