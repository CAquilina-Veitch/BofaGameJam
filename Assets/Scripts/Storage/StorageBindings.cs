using Scripts.Storage.Keybinds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StorageBindings : MonoBehaviour
{
    public static StorageBindings Instance { get; private set; }

    [SerializeField] private KeybindingData keybindingData;
    public static KeybindingData KeybindingData => Instance?.keybindingData;

    

}
