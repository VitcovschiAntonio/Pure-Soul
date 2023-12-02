using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SceneChanger sceneChanger;

    // Attach this method to the button's onClick event in the Inspector
    public void OnButtonClick()
    {
        sceneChanger.ChangeScene();
    }
}