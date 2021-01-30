using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    public List<GameObject> slotlar;

    public int slotsayi;

    public Sprite selectedbar, emptybar;

    AllCode cd;
    Handtems hand;
    void Start()
    {
        cd = GameObject.FindGameObjectWithTag("Codes").GetComponent<AllCode>();
        hand = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Handtems>();
    }

    // Update is called once per frame
    void Update()
    {
        seticon();
        Selecthotbar();
        itemselect(cd.inventor.items[slotsayi]);
        
    }

    public void seticon()
    {
        for(int i =0;i< slotlar.Count; i++)
        {
            slotlar[i].GetComponent<Image>().sprite = emptybar;
        }
        slotlar[slotsayi].GetComponent<Image>().sprite = selectedbar;
    }

    public void Selecthotbar()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotsayi = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotsayi = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slotsayi = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            slotsayi = 3;

        }
    }

    public void itemselect(Item item)
    {
        for (int i = 0; i < hand.handmodel.Count; i++)
        {
            if (hand.handmodel[i].name == item.itemname)
            {
                hand.handmodel[i].SetActive(true);
                hand.handmodel[i].GetComponent<HandITem>().slotsayi = slotsayi;
            }
            else
            {
                hand.handmodel[i].SetActive(false);

            }
        }
    }
}
