using UnityEngine;
using UnityEngine.SceneManagement;

public class UiHomeManager1 : MonoBehaviour
{
    public void GoHomeButtonAction()
    {
        SceneManager.LoadScene("Main 2");
    }
}
