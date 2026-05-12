using UnityEngine;

public class Response : MonoBehaviour
{
    [SerializeField]
    GameObject leadsTo = null;
    Client client;

    void Start()
    {
        client = GetComponentInParent<Client>();
    }

    public void Submit() => client.ReceiveAnswer(new Answer()
    {
        reaction = Client.Reaction.NEUTRAL,
        leadsTo = leadsTo
    });
}
