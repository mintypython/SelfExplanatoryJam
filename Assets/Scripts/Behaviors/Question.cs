using System;
using UnityEngine;

/// <summary>
/// This is the brains of the branching dialogue system!
/// 
/// Every speech bubble a client has will have this component
/// In the editor, you can specify a default response and a list of special responses
/// </summary>
public class Question : MonoBehaviour
{
    [SerializeField]
    Answer defaultResponse;

    [SerializeField]
    Response[] responses;

    public Answer Resolve(string answer)
    {
        // All responses specify the name of the option you picked
        // ToLower and Trim just ensure that even tiny formatting changes don't break anything
        // This looks to see if you added a specific response, if it can't find one, it uses the Default Response instead
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

/// <summary>
/// A "Response" is a data packet that specifies what the button you pressed does
/// ResponseStatus controls if you're gonna take heart damage or not
/// leadsTo specifies what the next question is gonna be (you can even go backwards by linking to a previous question!)
/// </summary>
[Serializable]
public struct Response
{
    public string name;
    public ResponseStatus status;
    public GameObject leadsTo;
}

/// <summary>
/// I don't think there could be a fourth option here, but maybe?
/// </summary>
public enum ResponseStatus
{
    NEUTRAL,
    CORRECT,
    INCORRECT
}

/// <summary>
/// This is the same as the Response struct, but without a name, just to trim down the data we pass around
/// </summary>
[Serializable]
public struct Answer
{
    public ResponseStatus status;
    public GameObject leadsTo;
}