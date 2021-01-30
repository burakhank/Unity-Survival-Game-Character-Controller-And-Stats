using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class equipdropitem : MonoBehaviour
{
    RaycastHit hit;
    AllCode cd;
    Obj oe;
    buildspawn bs;


    public TextMeshProUGUI uishowitemname;
    void Start()
    {
        cd = GameObject.FindGameObjectWithTag("Codes").GetComponent<AllCode>();
        
    }

    
    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,6))
        {
            if (hit.transform.gameObject.tag == "droppeditem")
            {
                oe = hit.transform.gameObject.GetComponent<Obj>();

                if (oe.item.itemvalue >1)
                {
                    uishowitemname.text = oe.item.itemname + " x" + oe.item.itemvalue;
                }
                else
                {
                    uishowitemname.text = oe.item.itemname;
                }
    
                if (Input.GetKeyDown(KeyCode.E))
                {
                    cd.inventor.additem(oe.item.itemid,oe.item.itemvalue);
                    Destroy(hit.transform.gameObject);
                }

            }
            if (hit.transform.gameObject.tag == "Spawner")
            {
                bs = hit.transform.gameObject.GetComponent<buildspawn>();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (cd.inventor.items[cd.hb.slotsayi].itemid == bs.id[0])
                    {
                        if (bs.completedvalue[0] < bs.needvalue[0])
                        {
                            bs.completedvalue[0] += 1;
                            cd.inventor.items[cd.hb.slotsayi].itemvalue -= 1;
                        }
                    }
                    if (cd.inventor.items[cd.hb.slotsayi].itemid == bs.id[1])
                    {
                        if (bs.completedvalue[1] < bs.needvalue[1])
                        {
                            bs.completedvalue[1] += 1;
                            cd.inventor.items[cd.hb.slotsayi].itemvalue -= 1;
                        }
                    }
                    if (cd.inventor.items[cd.hb.slotsayi].itemid == bs.id[2])
                    {
                        if (bs.completedvalue[2] < bs.needvalue[2])
                        {
                            bs.completedvalue[2] += 1;
                            cd.inventor.items[cd.hb.slotsayi].itemvalue -= 1;
                        }
                    }
                    if (cd.inventor.items[cd.hb.slotsayi].itemid == bs.id[3])
                    {
                        if (bs.completedvalue[3] < bs.needvalue[3])
                        {
                            bs.completedvalue[3] += 1;
                            cd.inventor.items[cd.hb.slotsayi].itemvalue -= 1;
                        }
                    }
                    if (cd.inventor.items[cd.hb.slotsayi].itemid == bs.id[4])
                    {
                        if (bs.completedvalue[4] < bs.needvalue[4])
                        {
                            bs.completedvalue[4] += 1;
                            cd.inventor.items[cd.hb.slotsayi].itemvalue -= 1;
                        }
                    }
                    if (cd.inventor.items[cd.hb.slotsayi].itemid == bs.id[5])
                    {
                        if (bs.completedvalue[5] < bs.needvalue[5])
                        {
                            bs.completedvalue[5] += 1;
                            cd.inventor.items[cd.hb.slotsayi].itemvalue -= 1;
                        }
                    }
                    if (cd.inventor.items[cd.hb.slotsayi].itemid == bs.id[6])
                    {
                        if (bs.completedvalue[6] < bs.needvalue[6])
                        {
                            bs.completedvalue[6] += 1;
                            cd.inventor.items[cd.hb.slotsayi].itemvalue -= 1;
                        }
                    }
                    if (cd.inventor.items[cd.hb.slotsayi].itemid == bs.id[7])
                    {
                        if (bs.completedvalue[7] < bs.needvalue[7])
                        {
                            bs.completedvalue[7] += 1;
                            cd.inventor.items[cd.hb.slotsayi].itemvalue -= 1;
                        }
                    }


                }
            }
            else
            {
                uishowitemname.text = "";

            }
        }
    }
}
