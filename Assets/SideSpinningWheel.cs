using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideSpinningWheel : MonoBehaviour
{

    [SerializeField] SpinningWheel leftWheel;

    [SerializeField] GameObject itemSocketPrefab;

    float r = 4;
    float _itemSizeMult = 1;


    /*[SerializeField]*/ GameObject[] itemObjs = new GameObject[5];

    Sprite[] typeSprites;

    public SlotMachine sM;
    public void init()
    {
        typeSprites = sM.itemTypeSprites;
        for (int i = 0; i < 5; i++)
        {
            GameObject Temp = Instantiate(itemSocketPrefab, transform);
            itemObjs[i] = Temp;
        }
        _itemSizeMult = sM.itemSizeMult;
        UpdatePositions();
    }

    public float currentValue;

    void UpdatePositions()
    {
        for (int i = 0; i < itemObjs.Length; i++)
        {
            itemObjs[i].transform.localPosition = new Vector3(-r * Mathf.Sin((currentValue / 5f + (i / 5f)) * Mathf.PI * 2), r*-Mathf.Cos((currentValue / 5f + (i / 5f)) * Mathf.PI * 2), 0);
            //itemObjs[i].transform.localScale = new Vector3(_itemSizeMult, _itemSizeMult * Mathf.Cos((currentValue / 5 + (i / 5f)) * Mathf.PI * 2));
        }
    }

    public void UpdateVisuals(List<slotItemType> wheelItems)
    {
        for (int i = 0; i < itemObjs.Length; i++)
        {
            itemObjs[i].GetComponent<SpriteRenderer>().sprite = typeSprites[(int)wheelItems[i]];
        }

    }




}
