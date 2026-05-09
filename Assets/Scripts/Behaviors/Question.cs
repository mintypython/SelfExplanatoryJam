using System;
using UnityEngine;

public class Question : MonoBehaviour
{
    [SerializeField]
    Answer first;

    [SerializeField]
    Answer second;

    ClientController client;

    void Start()
    {
        client = GetComponentInParent<ClientController>();
    }

    public void SubmitAnswer(int position) => client.ReceiveAnswer(position == 0 ? first : second);
}

/// <summary>
/// I don't think there could be a fourth option here, but maybe?
/// </summary>
[Serializable]
public struct Answer
{
    public ClientReaction reaction;
    public GameObject leadsTo;
}