using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [Header("UI 연결")]
    public GameObject guideMessage; 
    public GameObject noteWindow;   

    private bool isPlayerNearby = false;
    private bool isWindowOpen = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            isWindowOpen = !isWindowOpen;
            noteWindow.SetActive(isWindowOpen);

            if (guideMessage != null) guideMessage.SetActive(!isWindowOpen);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (!isWindowOpen && guideMessage != null) guideMessage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
            isWindowOpen = false;
            if (guideMessage != null) guideMessage.SetActive(false);
            if (noteWindow != null) noteWindow.SetActive(false);
        }
    }
}