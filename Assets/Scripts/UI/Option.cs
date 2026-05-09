using UnityEngine;
using UnityEngine.EventSystems;

public class Option : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    int position = 0;

    Wiggle wiggle; //This causes the text to wiggle? - Syd
    // Yep! The wiggle class makes an object wiggle back and worth if you set its active variable to true

    void Start()
    {
        wiggle = GetComponentInChildren<Wiggle>(); 
    }

    public void Submit()
    {
        var question = GetComponentInParent<Question>();
        question.SubmitAnswer(position);
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
