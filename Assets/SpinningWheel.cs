using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningWheel : MonoBehaviour
{
    [SerializeField] GameObject slotItemPrefab;

    float yHeight = 4;

    [SerializeField] Transform slotItemOwner;
    [SerializeField] float yBounds;


    [SerializeField] GameObject[] itemIcons = new GameObject[5];

    private void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject Temp = Instantiate(slotItemPrefab, slotItemOwner);
            itemIcons[i] = Temp;
        }
    }

    public float currentValue;
    float goalValue;



    public void SpinWheel()
    {
        goalValue = currentValue + Random.Range(20f, 40f);
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
    void UpdatePositions()
    {
        for (int i = 0; i < itemIcons.Length; i++)
        {
            itemIcons[i].transform.localPosition = new Vector3(0, yBounds* Mathf.Sin((currentValue + (i / 5f) ) * Mathf.PI * 2), Mathf.Cos((currentValue + (i / 5f)) * Mathf.PI * 2));
            itemIcons[i].transform.localScale = new Vector3(1, Mathf.Cos((currentValue + (i / 5f)) * Mathf.PI * 2));
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
