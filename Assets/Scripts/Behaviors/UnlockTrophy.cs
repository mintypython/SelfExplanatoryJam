using UnityEngine;

public class UnlockTrophy : MonoBehaviour
{
    [SerializeField]
    string trophy;

    public void Activate()
    {
        var trophyList = FindAnyObjectByType<TrophyList>();
        if (trophyList == null)
        {
            return;
        }

        trophyList.Unlock(trophy);
    }
}
