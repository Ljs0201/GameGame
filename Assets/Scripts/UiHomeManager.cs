using UnityEngine;
using UnityEngine.SceneManagement;

public class UiHomeManager : MonoBehaviour
{
    public void GoHomeButtonAction()
    {
        SceneManager.LoadScene("Main");
    }
}
