using UnityEngine;

public class TrophyButton : MonoBehaviour
{
    Swoop swoop;
    bool open = false;

    void Awake()
    {
        swoop = transform.parent.GetComponentInChildren<Swoop>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Click() {
        open = !open;

        if (open)
        {
            GameObject.Find("Clients").GetComponent<CanvasGroup>().blocksRaycasts = false;
            swoop.In();
        }
        else
        {
            GameObject.Find("Clients").GetComponent<CanvasGroup>().blocksRaycasts = true;
            swoop.Out();
        }
    }
}
