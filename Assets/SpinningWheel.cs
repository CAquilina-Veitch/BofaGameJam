using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningWheel : MonoBehaviour
{
    [SerializeField] GameObject slotItemPrefab;

    float yHeight = 4;

    [SerializeField] Transform slotItemOwner;
    [SerializeField] float yBounds;


    [SerializeField] GameObject[] itemObjs = new GameObject[5];

    Sprite[] typeSprites;

    public SlotMachine sM;

    public void init()
    {
        typeSprites = sM.itemTypeSprites;
        for (int i = 0; i < 5; i++)
        {
            GameObject Temp = Instantiate(slotItemPrefab, slotItemOwner);
            itemObjs[i] = Temp;
        }
    }

    public float currentValue;
    float goalValue;



    public void SpinWheel()
    {
        goalValue = Mathf.RoundToInt(goalValue +Random.Range(20, 40));
    }

    private void FixedUpdate()
    {
        if(currentValue < goalValue)
        {
            currentValue = Mathf.Lerp(currentValue, goalValue, 0.01f);
            if (Mathf.Abs(currentValue - goalValue) < 0.01f)
            {
                currentValue = goalValue;
            }




        }
        UpdatePositions();

    }
    public void UpdateVisuals(List<slotItemType> wheelItems)
    {
        for(int i = 0;i < itemObjs.Length;i++)
        {
            Debug.Log((int)wheelItems[i]);
            itemObjs[i].GetComponent<SpriteRenderer>().sprite = typeSprites[ (int)wheelItems[i]];
        }

    }
    void UpdatePositions()
    {
        for (int i = 0; i < itemObjs.Length; i++)
        {
            itemObjs[i].transform.localPosition = new Vector3(0, -yBounds* Mathf.Sin((currentValue/5f + (i / 5f) ) * Mathf.PI * 2), -Mathf.Cos((currentValue/5f + (i / 5f)) * Mathf.PI * 2));
            itemObjs[i].transform.localScale = new Vector3(1, Mathf.Cos((currentValue/5 + (i / 5f)) * Mathf.PI * 2));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpinWheel();
        }
    }

}
