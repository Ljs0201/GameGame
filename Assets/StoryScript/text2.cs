using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class text2 : MonoBehaviour
{

    private string nextSceneName = "Home";

    public TextMeshProUGUI dialogueText;
    public List<string> sentences = new List<string>();
    private int currentIndex = 0;
    private bool isTyping = false;
    private string currentSentence;

    [Header("Choice System")]
    public GameObject choicePanel;
    public Button choiceButton1;
    public Button choiceButton2;
    private bool isChoiceTime = false;
    private bool isBranchActive = false; // 분기 대사 진행 중인지 체크

    void Start()
    {
        if (choicePanel != null) choicePanel.SetActive(false);

        if (sentences.Count > 0)
        {
            currentSentence = sentences[currentIndex];
            StartCoroutine(TypeSentence(currentSentence));
        }
    }

    void Update()
    {
        if (isChoiceTime) return;

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = currentSentence;
                isTyping = false;
            }
            else
            {
                NextSentence();
            }
        }
    }

    void NextSentence()
    {
        currentIndex++;
        if (currentIndex < sentences.Count)
        {
            currentSentence = sentences[currentIndex];
            StartCoroutine(TypeSentence(currentSentence));
        }
        else
        {
            // 만약 분기 대사(A루트나 B루트)가 끝난 상태라면? -> 씬 전환
            if (isBranchActive)
            {
                EndDialogue();
            }
            // 처음 공통 대사가 끝난 상태라면? -> 선택지 표시
            else
            {
                ShowChoices("사줄게", "안 사줘");
            }
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        isTyping = false;
    }

    void ShowChoices(string c1, string c2)
    {
        isChoiceTime = true;
        choicePanel.SetActive(true);
        choiceButton1.GetComponentInChildren<TextMeshProUGUI>().text = c1;
        choiceButton2.GetComponentInChildren<TextMeshProUGUI>().text = c2;

        choiceButton1.onClick.RemoveAllListeners();
        choiceButton1.onClick.AddListener(() => OnClickChoice(1));
        choiceButton2.onClick.RemoveAllListeners();
        choiceButton2.onClick.AddListener(() => OnClickChoice(2));
    }

    void OnClickChoice(int index)
    {
        isChoiceTime = false;
        isBranchActive = true; // 이제부터는 분기 대사라는 것을 표시
        choicePanel.SetActive(false);

        if (index == 1) StartBranchA();
        else if (index == 2) StartBranchB();
    }

    void StartBranchA()
    {
        nextSceneName = "Shop"; // 목적지를 Shop으로 변경
        isBranchActive = true;

        sentences.Clear();
        sentences.Add("정말? 최고야! 넌 역시 내 친구야.");
        sentences.Add("그럼 지금 바로 편의점으로 가자!");
        sentences.Add("히히, 벌써부터 설레네.");

        currentIndex = -1;
        NextSentence();
    }

    void StartBranchB()
    {
        nextSceneName = "Home"; // 목적지를 Home으로 변경
        isBranchActive = true;

        sentences.Clear();
        sentences.Add("...뭐? 안 사준다고?");
        sentences.Add("방금 모찌모찌하게 애교도 떨었는데 너무해.");
        sentences.Add("됐어, 나 혼자 갈 거야! 흥!");

        currentIndex = -1;
        NextSentence();
    }

    // 씬 전환 함수
    void EndDialogue()
    {
        Debug.Log(nextSceneName + " 씬으로 이동합니다.");
        // 설정된 씬 이름으로 이동
        SceneManager.LoadScene(nextSceneName);
    }
}