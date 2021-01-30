using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour , IPointerDownHandler
{

    AllCode cd;

    public GameObject droptransform;
    void Start()
    {
        cd = GameObject.FindGameObjectWithTag("Codes").GetComponent<AllCode>();
    }

    
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (data.button.ToString() == "Left")
        {
            if (cd.inventor.booldraggingitem)
            {
                voiddropitem(cd.inventor.draggingitem);
                cd.inventor.dragitemexit();
            }
        }
    }

    public void voiddropitem(Item item)
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>(item.itemname), droptransform.transform.position,Quaternion.identity) as GameObject;
        obj.GetComponent<Obj>().item = item;
        cd.inventor.dragitemexit();
    }
}
