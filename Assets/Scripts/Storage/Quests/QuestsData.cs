using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Storage.Keybinds
{

    [CreateAssetMenu(fileName = "QuestsData", menuName = "Storage/QuestsData", order = 1)]
    public class QuestsData : ScriptableObject
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