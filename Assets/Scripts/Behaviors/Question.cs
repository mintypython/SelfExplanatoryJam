using UnityEngine;

public class Question : MonoBehaviour
{
    [SerializeField]
    Answer answer;

    ClientController client;

    Transform question;

    Transform response;
    Transform rightResponse;
    Transform wrongResponse;

    void Start()
    {
        client = GetComponentInParent<ClientController>();
        question = transform.Find("Question");

        response = transform.Find("Responses");
        rightResponse = response.Find("Right");
        wrongResponse = response.Find("Wrong");

        question.gameObject.SetActive(true);
        response.gameObject.SetActive(false);
        rightResponse.gameObject.SetActive(false);
        wrongResponse.gameObject.SetActive(false);
    }

    public void SubmitAnswer(Answer answer)
    {
        question.gameObject.SetActive(false);
        response.gameObject.SetActive(true);
        if (this.answer == answer)
        {
            client.Right();
            rightResponse.gameObject.SetActive(true);
        }
        else
        {
            client.Wrong();
            wrongResponse.gameObject.SetActive(true);
        }
    }
}

/// <summary>
/// I don't think there could be a fourth option here, but maybe?
/// </summary>
public enum Answer
{
    A,
    B
}