using UnityEngine;
using UnityEngine.EventSystems;

public class ContinueButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Wiggle wiggle; //This causes the text to wiggle? - Syd
    // Yep! The wiggle class makes an object wiggle back and worth if you set its active variable to true

    void Start()
    {
        wiggle = GetComponentInChildren<Wiggle>(); 
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
