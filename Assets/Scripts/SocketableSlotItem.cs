using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketableSlotItem : MonoBehaviour
{
    Collider2D col;
    SpriteRenderer sr;
    public slotItemType itemType;

    [SerializeField] Sprite[] sprites;


    private void OnEnable()
    {
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void init()
    {
        transform.position += new Vector3(Random.Range(-0.1f, 0.1f),Random.Range(-0.1f,0.1f));
        sr.sprite = sprites[(int)itemType];
    }


    private void Update()
    {
        
    }

    public void Attach(bool to)
    {

    }
    bool attached;

}
