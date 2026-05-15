using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, "안녕? 나는 NPC야.");
        talkData.Add(2000, "이 상자는 낡았네.");
    }

    public string GetTalk(int id)
    {
        return talkData.ContainsKey(id) ? talkData[id] : "데이터가 없어.";
    }
}