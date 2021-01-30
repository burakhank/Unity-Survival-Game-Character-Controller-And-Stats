using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class inventoryslot : MonoBehaviour ,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{
    public Item item;
    public int slotsayi;

    public Image itemicon;
    public TextMeshProUGUI itemvalue;

    AllCode cd;

    void Start()
    {
        cd = GameObject.FindGameObjectWithTag("Codes").GetComponent<AllCode>();
    }

    void Update()
    {
        item = cd.inventor.items[slotsayi];
        if (item.itemname ==null)
        {
            itemicon.enabled = false;
            itemvalue.enabled = false;
        }
        else if (item.itemname != null)
        {
            itemicon.enabled = true;
            itemicon.sprite = item.itemicon;
            if (item.itemvalue > 1)
            {
                itemvalue.text = "" + item.itemvalue;
                itemvalue.enabled = true;
            }
            else
            {
                itemvalue.enabled = false;
            }
        }
        if (item.itemdurability <= 0)
        {
            cd.inventor.items[slotsayi].itemvalue -=1;
        }
        if (item.itemvalue <= 0)
        {
            cd.inventor.items[slotsayi] = new Item();
        }
        

    }

    public void OnPointerEnter (PointerEventData data)
    {
        if (item.itemname !=null )
        {
            cd.inventor.itemdetailopen(item);
        }
        
    }
    public void OnPointerExit(PointerEventData data)
    {
        cd.inventor.itemdetailexit();
    }
    public void OnPointerDown(PointerEventData data)
    {
        if (data.button.ToString() == "Left")
        {
            if (!cd.inventor.booldraggingitem && item.itemname != null)
            {
                cd.inventor.dragitemopen(item);
                cd.inventor.items[slotsayi] = new Item();
                cd.inventor.itemdetailexit();
            }
            if (cd.inventor.booldraggingitem && item.itemname == null)
            {
                cd.inventor.items[slotsayi] = cd.inventor.draggingitem;
                cd.inventor.dragitemexit();
            }
            else if(cd.inventor.draggingitem.itemname == item.itemname)
            {
                if (cd.inventor.items[slotsayi].itemvalue + cd.inventor.draggingitem.itemvalue <= cd.inventor.items[slotsayi].itemmaxstack)
                {
                    cd.inventor.items[slotsayi].itemvalue = cd.inventor.items[slotsayi].itemvalue + cd.inventor.draggingitem.itemvalue;
                    cd.inventor.dragitemexit();

                }                

            }
            else
            {
                Item newitem = cd.inventor.items[slotsayi];
                cd.inventor.items[slotsayi] = cd.inventor.draggingitem;
                cd.inventor.draggingitem = newitem;
            }
        }
        if (data.button.ToString() == "Right")
         if (!cd.inventor.booldraggingitem)
          if(item.itemtype == Item.ItemType.food || item.itemtype == Item.ItemType.material || item.itemtype == Item.ItemType.water)
           if (item.itemvalue > 1)
           {
                int deger = item.itemvalue / 2;
                Item newitem = new Item(item.itemname, item.itemdetail, item.itemid, deger, item.itemmaxstack, item.itemdamage, item.itemdurability, item.itemtype);
                cd.inventor.dragitemopen(newitem); //deðiþicek
                int deger2 = item.itemvalue - deger;
                cd.inventor.items[slotsayi].itemvalue = deger2;
           }
    }

}
