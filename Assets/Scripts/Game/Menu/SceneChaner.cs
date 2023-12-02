using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string targetSceneName; // Set this in the Inspector to the name of the scene you want to load

    // Call this method to change the scene
    public void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}