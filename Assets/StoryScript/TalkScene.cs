using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkScene : MonoBehaviour
{
    public void TalkSceneButtonAction()
    {
        SceneManager.LoadScene("Talk");
    }
}
