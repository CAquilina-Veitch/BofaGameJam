using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Storage.Keybinds
{
    [Serializable]
    public struct Conversation
    {
        List<DialogueItem> dialogueItems;
    }

    [Serializable]
    public class DialogueItem
    {

    }
    [Serializable]
    public enum SpeakerName
    {
        None,
        Player,
        NPC1
    }
    [Serializable]
    public enum DialogueType
    {
        Text,
        Check,
        Options,
    }
    [Serializable]
    public struct Speaker
    {
        public SpeakerName SpeakerName;
        public Sprite Portrait;
    }

    [CreateAssetMenu(fileName = "DialogueData", menuName = "Storage/DialogueData", order = 1)]
    public class DialogueData : ScriptableObject
    {
        /*public List<Conversation> keybindings;

        public Conversation? GetConversation( InteractionType type)
        {
            if (!keybindings.Any(x => x.Type == type)) 
            { 
                Debug.LogError($"Keybinding of type {type} has not been defined."); 
                return null; 
            }

            return keybindings.FirstOrDefault(x => x.Type == type);
        }*/
    }
}