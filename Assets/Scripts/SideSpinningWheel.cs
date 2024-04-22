using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideSpinningWheel : MonoBehaviour
{

    [SerializeField] SpinningWheel leftWheel;

    [SerializeField] GameObject itemSocketPrefab;




    float r = 1.76f;
    float _itemSizeMult = 1;

    public bool OnScreen;

    /*[SerializeField]*/ GameObject[] sockets = new GameObject[5];

    [SerializeField] SideFaceMenu menu;


    SocketableSlotItem[] attachedItems = new SocketableSlotItem[5];

    


    Sprite[] typeSprites;

    public SlotMachine sM;
    public void init()
    {
        typeSprites = sM.itemTypeSprites;
        for (int i = 0; i < 5; i++)
        {
            GameObject Temp = Instantiate(itemSocketPrefab, transform);
            sockets[i] = Temp;
            Temp.name = $"{i}";
        }
        _itemSizeMult = sM.itemSizeMult;
        UpdatePositions();
    }

    public float currentValue;

    void UpdatePositions()
    {
        for (int i = 0; i < sockets.Length; i++)
        {
            sockets[i].transform.localPosition = new Vector3(-r * Mathf.Sin((currentValue / 5f + (i / 5f)) * Mathf.PI * 2), r*-Mathf.Cos((currentValue / 5f + (i / 5f)) * Mathf.PI * 2), 0);
            //itemObjs[i].transform.localScale = new Vector3(_itemSizeMult, _itemSizeMult * Mathf.Cos((currentValue / 5 + (i / 5f)) * Mathf.PI * 2));
        }
    }

    public void UpdateVisuals(List<slotItemType> wheelItems)
    {
        for (int i = 0; i < sockets.Length; i++)
        {
            sockets[i].GetComponent<SpriteRenderer>().sprite = typeSprites[(int)wheelItems[i]];
        }

    }

    public void ChangeValue(int of, SocketableSlotItem item)
    {
        attachedItems[of] = item;
    }
    public List<slotItemType> GetTypeList()
    {
        List<slotItemType> typeList = new List<slotItemType>();
        for(int i = 0; i < 5; i++)
        {
            if (attachedItems[i] != null)
            {
                typeList.Add(attachedItems[i].itemType);
            }
            else
            {
                typeList.Add(slotItemType.coin);
            }
        }
        return typeList;
    }


}
