using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable] public struct Conversation
{
    List<DialogueItem> dialogueItems;
}

[Serializable] public class DialogueItem
{
    
}
public enum SpeakerName
{
    None,
    Player,
    NPC1
}
public enum DialogueType
{
    Text,
    Check,
    Options,
}
[Serializable] public struct Speaker
{
    public SpeakerName SpeakerName;
    public Texture2D Portrait;
}
public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UISpeakerName;



    public void SetConversation(Conversation newConversation)
    {
        
    }
}
