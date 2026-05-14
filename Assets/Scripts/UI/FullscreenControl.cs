using UnityEngine;

public class FullscreenControl : MonoBehaviour
{
    void Awake()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
    }
    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
