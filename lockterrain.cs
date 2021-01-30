using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockterrain : MonoBehaviour
{
    AllCode cd;
    Vector3 pos;
    public float ypos;
    public GameObject spawnobject;
    void Start()
    {
        cd = GameObject.FindGameObjectWithTag("Codes").GetComponent<AllCode>();
    }

   
    void Update()
    {
        pos = transform.position;
        pos.y = Terrain.activeTerrain.SampleHeight(transform.position);
        pos.y = pos.y + ypos;
        transform.position = pos;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(spawnobject,gameObject.transform.position,gameObject.transform.rotation);
            cd.inventor.items[GetComponent<HandITem>().slotsayi].itemvalue -= 1;

        }

        //RaycastHit hitinfo;
        //if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.position, out hitinfo))
        //{

        //    currentobject.transform.position = hitinfo.point;
        //    currentobject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitinfo.normal);
        //}

        
    }
}
