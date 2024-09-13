using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Storage.Keybinds
{
    [Serializable]
    public enum InteractionType
    {
        None = 0,
        Dialogue = 1
    }
    [Serializable]
    public struct Keybinding
    {
        public InteractionType Type;
        public KeyCode Key;
    }

    [CreateAssetMenu(fileName = "KeybindingData", menuName = "Keybinding/KeybindingData", order = 1)]
    public class KeybindingData : ScriptableObject
    {
        public List<Keybinding> keybindings;

        public Keybinding? GetKeybind( InteractionType type)
        {
            if (!keybindings.Any(x => x.Type == type)) 
            { 
                Debug.LogError($"Keybinding of type {type} has not been defined."); 
                return null; 
            }

            return keybindings.FirstOrDefault(x => x.Type == type);
        }
    }
}