using UnityEngine;

public class Response : MonoBehaviour
{
    [SerializeField]
    GameObject leadsTo = null;

    [SerializeField]
    Sprite sprite;

    Client client;

    void Start()
    {
        client = GetComponentInParent<Client>();
    }

    void OnEnable()
    {
        GetComponentInParent<Client>().GetComponentInChildren<Body>().ChangeSprite(sprite);
    }

    public void Submit() => client.ReceiveAnswer(new Answer()
    {
        reaction = Client.Reaction.NEUTRAL,
        leadsTo = leadsTo
    });
}
