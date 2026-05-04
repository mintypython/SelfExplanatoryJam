using UnityEngine;

public class Option : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isRight = false;

    [SerializeField]
    ClientManager manager;

    public void Submit()
    {
        if (isRight)
        {
            manager.RightOption();
        }
        else
        {
            manager.WrongOption();
        }
    }
}
