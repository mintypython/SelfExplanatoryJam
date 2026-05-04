using UnityEngine;
using UnityEngine.EventSystems;

public class Option : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isRight = false;

    [SerializeField]
    ClientManager manager;

    Wiggle wiggle;

    void Start()
    {
        wiggle = GetComponentInChildren<Wiggle>();
    }

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        wiggle.active = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        wiggle.active = false;
    }
}
