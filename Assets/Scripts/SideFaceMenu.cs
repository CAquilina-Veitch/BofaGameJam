using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideFaceMenu : MonoBehaviour
{
    List<SocketableSlotItem> looseIcons = new List<SocketableSlotItem>();

    [SerializeField] GameObject socketableItemPrefab;
    [SerializeField] Transform sideFace;

    [SerializeField] SideSpinningWheel sideWheel;

    public void GenerateRandomIcons(int num)
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject Temp = Instantiate(socketableItemPrefab, sideFace);
            SocketableSlotItem tempItem = Temp.GetComponent<SocketableSlotItem>();
            tempItem.itemType = (slotItemType) Random.Range(0, 4);
            tempItem.init();
            looseIcons.Add(tempItem);
        }
    }

    private void Start()
    {
        GenerateRandomIcons(6);
    }

    public void EnablePhysics(bool enable)
    {
        foreach(SocketableSlotItem item in looseIcons)
        {
            item.Sim(enable);
        }
    }


}
