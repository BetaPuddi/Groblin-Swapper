using System;
using Managers;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCInfoPanel : MonoBehaviour
{
    public static NPCInfoPanel instance;

    public TextMeshProUGUI npcName;
    public Image npcIcon;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpdateNPCInfo()
    {
        npcName.text = NPCManager.instance.currentNpc.npcName;
        npcIcon.sprite = NPCManager.instance.currentNpc.icon;
    }
}
