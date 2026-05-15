using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHomeManager : MonoBehaviour
{
    public void GameStartButtonAction()
    {
        SceneManager.LoadScene("Level_1");
    }
}
