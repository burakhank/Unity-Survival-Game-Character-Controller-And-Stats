using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Item
{
    public string itemname,itemdetail;
    public int itemid, itemvalue,itemmaxstack,itemdamage;
    public float itemdurability;
    public Sprite itemicon;
    public GameObject itemdropmodel;

    public ItemType itemtype;

    public enum ItemType
    {
        bos,
        gun,
        food,
        water,
        material,
        build,
        tool

    }

    public Item(string iname , string idetail , int iid , int ivalue , int imaxstack , int idamage,float durability, ItemType itype)
    {
        itemname = iname;
        itemdetail = idetail;
        itemid = iid;
        itemvalue = ivalue;
        itemmaxstack = imaxstack;
        itemdamage = idamage;
        itemtype = itype;
        itemdurability = durability;
        itemicon = Resources.Load<Sprite>(iid.ToString());
        itemdropmodel = Resources.Load<GameObject>(iname.ToString());
   
    }

    public Item()
    {

    }

}
