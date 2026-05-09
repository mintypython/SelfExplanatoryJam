using UnityEngine;

public class Response : MonoBehaviour
{
    [SerializeField]
    GameObject leadsTo;

    ClientController client;

    void Start()
    {
        client = GetComponentInParent<ClientController>();
    }

    public void Submit() => client.ReceiveAnswer(new Answer()
    {
        reaction = ClientReaction.NEUTRAL,
        leadsTo = leadsTo
    });
}
