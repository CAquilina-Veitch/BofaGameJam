using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum slotItemType { sword,shield,hp,coin}


public class SlotMachine : MonoBehaviour
{
    public List<SlotWheel> wheels = new List<SlotWheel>(3);
    public Sprite[] itemTypeSprites;

    [Serializable]
    public class SlotWheel
    {
        public List<slotItemType> items = new List<slotItemType>();
        public bool isSpinning = false;

        public float currentNum;

        public SpinningWheel spinningWheel;


        public void RandomItems()
        {
            items.Clear();
            for(int i = 0; i < 5; i++)
            {
                items.Add((slotItemType)UnityEngine.Random.Range(0, 4));
            }
            spinningWheel.UpdateVisuals(items);
        }




    }

    private void Start()
    {
        foreach(SlotWheel wheel in wheels)
        {
            wheel.spinningWheel.sM = this;
            wheel.spinningWheel.init();
        }
    }
    public void SpinWheels()
    {
        for(int i = 0; i < wheels.Count; i++)
        {
            wheels[i].isSpinning = true;
            wheels[i].spinningWheel.SpinWheel();

        }
        foreach(SlotWheel wheel in wheels)
        {

        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach(SlotWheel w in wheels)
            {
                w.RandomItems();
            }
        }
    }







}
