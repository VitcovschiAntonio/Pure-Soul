using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public string targetSceneName; // Set this in the Inspector to the name of the scene you want to load

    // Call this method to change the scene
    public void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
    
public class NewGameButton : MonoBehaviour
{
    public SceneChanger sceneChanger;

    // Attach this method to the button's onClick event in the Inspector
    public void OnButtonClick()
    {
        sceneChanger.ChangeScene();
    }
}

}