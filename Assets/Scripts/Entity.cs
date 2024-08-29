using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum affectType { strength, poison, regeneration }

public class Entity : MonoBehaviour
{
    public string entityName = "Name";
    public int maxHealth = 1;
    public int currentHealth = 1;

}

public class Affect
{
    public affectType type;
    public int mult;
    public int duration;
}

public class Move
{
    public string Name;
    public string Description;
    public slotItemType type;
    public int damage;
    public float multiplier;
    public List<Affect> affects;
    public int heal;
    public int shield;


    public Move()
    {

    }
    public Move(slotItemType t, float m)
    {
        type = t;
        multiplier = m;
    }


}
