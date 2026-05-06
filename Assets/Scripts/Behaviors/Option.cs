using UnityEngine;
using UnityEngine.EventSystems;

public class Option : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Wiggle wiggle; //This causes the text to wiggle? - Syd

    void Start()
    {
        wiggle = GetComponentInChildren<Wiggle>(); 
    }

    public void Submit()
    {
        var manager = GameObject.FindAnyObjectByType<ClientManager>();
        manager.SubmitAnswer(name);
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
