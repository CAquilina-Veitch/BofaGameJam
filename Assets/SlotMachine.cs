using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum slotItemType { atk, def, glog}


public class SlotMachine : MonoBehaviour
{
    public List<SlotWheel> wheels = new List<SlotWheel>(3);

    [Serializable]
    public class SlotWheel
    {
        public List<slotItemType> items = new List<slotItemType>();
        public bool isSpinning = false;

        public float currentNum;

        public SpinningWheel spinningWheel;

        


    }

    public void SpinWheels()
    {
        for(int i = 0; i < wheels.Count; i++)
        {
            wheels[i].isSpinning = true;

        }
        foreach(SlotWheel wheel in wheels)
        {
        }
    }
    






}
