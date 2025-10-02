using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void ExitGame1()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}