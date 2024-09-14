using Scripts.Storage.Keybinds;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private List<Speaker> speakers;

    public Speaker? GetSpeaker(SpeakerName speakerName)
    {
        if(speakerName is SpeakerName.None) return null;

        if (!speakers.Any(x => x.SpeakerName == speakerName))
        {
            Debug.LogError($"Keybinding of type {speakerName} has not been defined.");
            return null;
        }
        return speakers.FirstOrDefault(x => x.SpeakerName == speakerName);
    }

    //how should i store conversations, based off who its talking too? and an enum that defines what the topic/purpose of the conversation is?
    // in which situation i need to define what a quest is 
    // maybe just the events and affects and requirements that happen in a conversation so conversation can just have text and  links to quest

    public static DialogueManager Instance { get; private set; }

}
