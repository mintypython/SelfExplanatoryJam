using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(SmoothLoad());
    }

    IEnumerator SmoothLoad() {
        var operation = SceneManager.LoadSceneAsync("Office", LoadSceneMode.Single);

        while (!operation.isDone) {
            yield return null;
        }
    }
}
