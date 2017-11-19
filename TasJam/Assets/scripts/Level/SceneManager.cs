using UnityEngine;
using UnityEngine.SceneManagement;

public static class Scenes {
    public static void SwitchScene(string sceneName)
    {
		SceneManager.LoadScene (sceneName);
    }
}
