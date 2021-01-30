using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDATA : MonoBehaviour
{
    public List<Item> items;

    private void Awake()
    {
        items.Add(new Item("","",99,0,0,0,0,Item.ItemType.bos));
        items.Add(new Item("Stick","bu bir �ubuktur ",0,1,6,0,1,Item.ItemType.material));
        items.Add(new Item("Balta", "bu bir Balta ", 1, 1, 1, 0,100, Item.ItemType.tool));
        items.Add(new Item("Log", "bar�naklar yapabilirsin... ", 2, 1, 2, 0,1, Item.ItemType.material));
        items.Add(new Item("Apple", "elmay� yiyerek can�n� doldurabilirsin", 3, 1, 2, 0,2, Item.ItemType.food));
        items.Add(new Item("Mini house", "Ba�lang�� i�in m�kemmel evcik ", 100, 1, 1, 0, 1, Item.ItemType.build));




    }
}
