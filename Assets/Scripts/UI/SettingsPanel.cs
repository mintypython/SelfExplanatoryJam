using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Swoop swoop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        swoop = GetComponent<Swoop>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        swoop.In();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        swoop.Out();
    }
}