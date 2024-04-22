using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum slotItemType { sword, shield, hp, coin}


public class SlotMachine : MonoBehaviour
{
    [SerializeField] int goalFace;
    [SerializeField] Transform arrow;
    [SerializeField] SpriteRenderer arrowTriangle;

    [SerializeField] float currentFace;

    [SerializeField] Transform[] sideFaces;


    [SerializeField] SideSpinningWheel sideSpinningWheel;

    [SerializeField] SideFaceMenu sideFaceMenu;

    public void TurnMachine(int by)
    {
        goalFace += by;
        sideSpinningWheel.OnScreen = goalFace == 1;
        foreach(SlotWheel wheel in wheels )
        {
            wheel.SetItems(sideSpinningWheel.GetTypeList());
        }
    }
    public void UpdateVisualTurn()
    {
        for(int i = 0; i < sideFaces.Length; i++)
        {
            sideFaces[i].transform.localScale = new Vector3(1- Mathf.Abs(i-currentFace), 1, 1);
            sideFaces[i].transform.localPosition = new Vector3((i - currentFace) * -4.85f, 0, 0);
            arrow.transform.localPosition = new Vector3( -5.79f * 2 * ((0.5f - currentFace)),0);
            arrowTriangle.flipY = currentFace > 0.5f;
        }
        sideFaceMenu.transform.localScale = new Vector3(currentFace, 1, 1);
        sideFaceMenu.EnablePhysics(currentFace == 1);
    }

    public List<SlotWheel> wheels = new List<SlotWheel>(3);
    public Sprite[] itemTypeSprites;

    [Serializable]
    public class SlotWheel
    {
        public List<slotItemType> items = new List<slotItemType>();

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

        public void SetItems(List<slotItemType> to)
        {
            spinningWheel.UpdateVisuals(to);
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
        sideSpinningWheel.init();
        UpdateVisualTurn();

    }

    public void CheckSpinFinish()
    {
        for (int i = 0; i < wheels.Count; i++) 
        {
            if (wheels[i].spinningWheel.isSpinning)
            {
                return;
            }
        }
        //spin is finished, get values

        Debug.LogError("SPUN");
        StopArm();


    }


    public void SpinWheels()
    {
        for(int i = 0; i < wheels.Count; i++)
        {
            wheels[i].spinningWheel.SpinWheel();

        }
    }

    float armValue =1;
    float armGoal =1;
    void PullArm()
    {
        armGoal = 0;


        SpinWheels();
    }
    public void StopArm()
    {
        armGoal = 1;
        armValue = 1;
    }


    [SerializeField] Transform armSquare;
    [SerializeField] Transform armBall;

    public float itemSizeMult = 1.5f;


    private void Awake()
    {
        armBallStart = armBall.localPosition;
        armSquareStart = armSquare.localPosition;
    }
    Vector3 armBallStart;
    Vector3 armSquareStart;

    void UpdateArmPosition()
    {
        armBall.localPosition = new Vector3(armBallStart.x, armBallStart.y * armValue);
        armSquare.localPosition = new Vector3(armSquareStart.x, armSquareStart.y * armValue);
        armSquare.localScale = new Vector3(1, armValue* 2.6f, 1) ;
    }

    private void FixedUpdate()
    {
        if (!(((armValue == armGoal) && (armValue == 1))))
        {
            if (MathF.Round(armValue, 3) == 0)
            {
                armGoal = 1;
            }
            if (armGoal == 0)
            {
                armValue = Mathf.Lerp(armValue, armGoal, 0.3f);
            }
            else
            {
                armValue = Mathf.Lerp(armValue, armGoal, Time.deltaTime * 3);

            }

        }
        if (currentFace != goalFace)
        {
            currentFace = Mathf.Lerp(currentFace, goalFace, 0.2f);
            if (MathF.Round(currentFace, 3) % 1 == 0)
            {
                currentFace = Mathf.Round(currentFace);
            }


        }

        UpdateVisualTurn();
        UpdateArmPosition();

        if (attached != null)
        {
            Vector3 tempMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tempMousePos.z = 0;
            attached.transform.position = tempMousePos;
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Arm")
                {
                    PullArm();

                }
                else if(hit.collider.tag == "Arrow")
                {
                    int dir = hit.collider.transform.position.x > 0 ? -1 : 1;
                    TurnMachine(dir);
                }
                else if(hit.collider.tag == "SocketableItem")
                {
                    attached = hit.collider.GetComponent<SocketableSlotItem>();
                    attached.AttachMouse(true);


                }
            }
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0)&&attached!=null)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Socket")
                {
                    attached.Stick(hit.collider.transform);
                }
            }
            attached.AttachMouse(false);
            attached = null;
        }
        
    }
    SocketableSlotItem attached;







}
