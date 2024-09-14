using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Quest
{
    public enum QuestStatus
    {
        Null,
        Exists,
        Recieved,
        Active,
        Completed
    }
    public abstract class BaseQuest : MonoBehaviour
    {
        [SerializeField] private int questNumber;
        private QuestStatus status;
        [SerializeField] public int QuestNum => questNumber;
        [SerializeField] public QuestStatus CurrentStatus => status;
        public void Learn()
        {
            if(status is not QuestStatus.Exists)
            {
                Debug.LogError($"While learning Quest {questNumber}, Status is {status}, expected exists");
                return;
            }
            status = QuestStatus.Recieved;
        }
    }
}