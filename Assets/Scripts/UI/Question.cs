using System;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    [SerializeField]
    Answer first;

    [SerializeField]
    Answer second;

    Client client;

    void Start()
    {
        client = GetComponentInParent<Client>();
    }

    void OnEnable()
    {
        var questions = transform.Find("Options");

        var positions = new List<Vector2>();
        foreach (Transform question in questions)
        {
            positions.Add((Vector2)question.localPosition);
        }

        for (var i = 0; i < questions.childCount && i < positions.Count; i++)
        {
            questions.GetChild(i).localPosition = positions[i];
        }
    }

    public void SubmitAnswer(int position) => client.ReceiveAnswer(position == 0 ? first : second);
}

/// <summary>
/// I don't think there could be a fourth option here, but maybe?
/// </summary>
[Serializable]
public struct Answer
{
    public Client.Reaction reaction;
    public GameObject leadsTo;
}