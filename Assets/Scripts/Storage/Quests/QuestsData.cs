using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Storage.Keybinds
{
    public enum QuestLineID
    {
        None = 0,
        Tutorial = 100,
        Tutorial2 = 101,
        Test = 200
    }

    [Serializable]
    public struct Quest
    {
        public QuestLineID ID;
        public List<Quest> Quests;
    }
    
    [Serializable]
    public struct Questline
    {
        public QuestLineID ID;
        public List<Quest> Quests;
    }

    [CreateAssetMenu(fileName = "QuestsData", menuName = "Storage/QuestsData", order = 1)]
    public class QuestlineData : ScriptableObject
    {
        /*public List<Keybinding> keybindings;

        public Keybinding? GetKeybind( InteractionType type)
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