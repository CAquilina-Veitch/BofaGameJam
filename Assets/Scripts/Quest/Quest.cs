using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Quests
{
    public enum QuestStatus
    {
        Null,
        Exists,
        Active,
        Completed
    }
    public abstract class Quest : MonoBehaviour
    {
        [SerializeField] private int questNumber;
        private QuestStatus status;
        [SerializeField] public int QuestNum => questNumber;
        [SerializeField] public QuestStatus CurrentStatus => status;
        public void Activate()
        {
            if(status is not QuestStatus.Exists)
            {
                Debug.LogError($"While learning Quest {questNumber}, Status is {status}, expected exists.");
                return;
            }
            status = QuestStatus.Active;
        }
        public void Complete()
        {
            if(status is not QuestStatus.Active)
            {
                Debug.LogError($"While completing Quest {questNumber}, Status is {status}, expected Active.");
                return;
            }
            status = QuestStatus.Completed;
        }
    }
}