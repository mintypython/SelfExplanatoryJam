using UnityEngine;

public class Client : MonoBehaviour
{
    [SerializeField]
    string answer;

    // This method runs when the gameobject is enabled!
    private void OnEnable()
    {
        var choices = GameObject.FindGameObjectsWithTag("Option");


        //Answer Option
        bool hasAnswer = false;
        foreach (var choice in choices)
        {
            if (choice.name == answer)
            {
                hasAnswer = true;
            }
            choice.GetComponent<Option>().isRight = choice.name == answer;
        }

        if (!hasAnswer)
        {
            Debug.LogError($"No valid option! {name}'s answer is {answer}");
        }


    }
}