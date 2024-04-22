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
        foreach (SlotWheel w in wheels)
        {
            w.RandomItems();
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

    float armValue =1;
    float armGoal =1;
    void PullArm()
    {
        armGoal = 0;


        SpinWheels();
    }

    private void FixedUpdate()
    {
        if(!(((armValue==armGoal)&&(armValue==1))))
        {
            if(MathF.Round(armValue,3)==0) { armGoal = 1; }
            if(armGoal==0)
            {
                armValue = Mathf.Lerp(armValue, armGoal, 0.3f);
            }
            else
            {
                armValue = Mathf.Lerp(armValue, armGoal, Time.deltaTime*3);

            }

        }
        UpdateArmPosition();
    }
    [SerializeField] Transform armSquare;
    [SerializeField] Transform armBall;
    void UpdateArmPosition()
    {
        armBall.localPosition = new Vector3(0,2.5f * armValue);
        armSquare.localPosition = new Vector3(0, 1.25f * armValue);
        armSquare.localScale = new Vector3(0.3f, armValue*1.95f, 1) ;
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Arm")
                {
                    PullArm();

                }

            }
        }
        
    }







}
