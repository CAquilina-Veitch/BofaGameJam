using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketableSlotItem : MonoBehaviour
{
    Collider2D col;
    SpriteRenderer sr;


    public slotItemType itemType;

    [SerializeField] Sprite[] sprites;
    public Rigidbody2D rb;

    SideSpinningWheel sSW;

    private void OnEnable()
    {
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        sSW = GameObject.FindGameObjectWithTag("SideSpinningWheel").GetComponent<SideSpinningWheel>();
    }

    public void init()
    {
        transform.position += new Vector3(Random.Range(-0.1f, 0.1f),Random.Range(-0.1f,0.1f));
        sr.sprite = sprites[(int)itemType];
    }


    private void FixedUpdate()
    {
        if (stuckTo != null&& rb.simulated)
        {
            Vector3 temp = Vector3.Lerp(transform.position, stuckTo.position, 0.1f);
            transform.position = temp;
        }
    }

    public void AttachMouse(bool to)
    {
        col.enabled = !to;
        if (stuckTo != null)
        {
            stuckTo.GetComponent<Collider2D>().enabled = to;
            if (to)
            {
                stuckTo = null;
            }

        }
    }

    public void Stick(Transform to)
    {
        stuckTo = to;
        int.TryParse(stuckTo.parent.name, out int success);
        sSW.ChangeValue(success, this);
    }

    Transform stuckTo;

    bool stuck;
    public void Sim(bool to)
    {
        rb.simulated = to;
    }

}
