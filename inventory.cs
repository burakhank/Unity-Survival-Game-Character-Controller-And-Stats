using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inventory : MonoBehaviour
{
    public List<Item> items;
    public int hotbarslot,slotmiktar;
    public GameObject slot,itemdetailUI,dragitemUI;

    public bool boolitemdetail,booldraggingitem;

    ItemDATA itemdata;

    public Item itemfordetailpanel,draggingitem;

    void Start()
    {
        itemdata = GameObject.FindGameObjectWithTag("DataItem").GetComponent<ItemDATA>();

        for (int i = hotbarslot; i < slotmiktar;i++)
        {
            GameObject slotobj = (GameObject)Instantiate(slot);
            slotobj.transform.SetParent(gameObject.transform);
            slotobj.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
            slotobj.GetComponent<inventoryslot>().slotsayi = i;
        }
        for (int i = 0;i<slotmiktar;i++)
        {
            items.Add(new Item());
        }

        additem(0,1);
        additem(1,1);
        additem(3,2);
        additem(100,2);

    }
    public void additem(int id,int additemcount)
    {
        for (int i = 0; i < itemdata.items.Count; i++)
        {
            if (itemdata.items[i].itemid == id)
            {
                Item newitem = new Item(itemdata.items[i].itemname, itemdata.items[i].itemdetail, itemdata.items[i].itemid, additemcount, itemdata.items[i].itemmaxstack, itemdata.items[i].itemdamage, itemdata.items[i].itemdurability, itemdata.items[i].itemtype);
                //addslotitem(newitem);
                if (newitem.itemtype == Item.ItemType.food || newitem.itemtype == Item.ItemType.material || newitem.itemtype == Item.ItemType.water)
                {
                    addslotitem(newitem);
                    break;
                }
                else if(newitem.itemvalue > 1)
                {
                    int deger = newitem.itemvalue - 1;
                    Item newitem2 = new Item(newitem.itemname, newitem.itemdetail, newitem.itemid, deger, newitem.itemmaxstack, newitem.itemdamage, newitem.itemdurability, newitem.itemtype);
                    newitem2.itemvalue = 1;

                    addslotitem(newitem2);
                    additem(newitem2.itemid, newitem2.itemvalue);
                    //break;

                }
                else
                {
                    changeemptyitem(newitem);
                }


            }
        }
    }

    public void changeemptyitem(Item item)
    {
        for (int i = 0; i < items.Count; i++)
            if (items[i].itemname ==null)
            {
                items[i] = item;
                break;
            }

    }

    public void itemdetailopen(Item item)
    {
        if (!booldraggingitem)
        {
            boolitemdetail = true;
            itemfordetailpanel = item;

            itemdetailUI.SetActive(true);
            itemdetailUI.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = itemfordetailpanel.itemname;
            itemdetailUI.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = itemfordetailpanel.itemdetail;
            itemdetailUI.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = itemfordetailpanel.itemicon;
        }
    }
    public void itemdetailexit()
    {
        boolitemdetail = false;
        itemfordetailpanel = null;
        itemdetailUI.SetActive(false);
    }
    public void dragitemopen(Item item)
    {
        booldraggingitem = true;
        draggingitem = item;
        dragitemUI.SetActive(true);
    }
    public void dragitemexit()
    {
        booldraggingitem = false;
        draggingitem = null;
        dragitemUI.SetActive(false);
    }

    public void addslotitem(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemname == item.itemname)
            {
                if (items[i].itemvalue + item.itemvalue <= items[i].itemmaxstack)
                {
                    items[i].itemvalue += item.itemvalue;
                    break;
                }

            }
            else if(i == items.Count -1)
            {
                changeemptyitem(item);
                break;
            }
        }
        //for (int i = 0; i < items.Count; i++)
        //    if (items[i].itemname == item.itemname)
        //    {
        //        items[i].itemvalue += item.itemvalue;
        //        changeemptyitem(item);
        //        break;
        //    }

    }

    public void Update()
    {
        if (booldraggingitem)
        {
            dragitemUI.GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            dragitemUI.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = draggingitem.itemicon;
            if (draggingitem.itemvalue > 1)
            {
                dragitemUI.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
                dragitemUI.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = draggingitem.itemvalue.ToString();
            }
            else
            {
                dragitemUI.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
            }




        }
        if (boolitemdetail)
        {

            itemdetailUI.GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        

    }
}
