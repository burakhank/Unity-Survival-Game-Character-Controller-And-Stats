using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sources : MonoBehaviour
{
    public ItemDATA itemdata;
    [Header("Zeptun Sources System")]
    public float health;
    public int spawnlogvalue;
    public int sourcesitemid;
    [Range(1, 10)]
    public int spawnvalue1;
    [Range(0, 10)]
    public int spawnvalue2;

    public Transform[] spawnlocation;

    public GameObject spawngameobject;

    void Start()
    {
        itemdata = GameObject.FindGameObjectWithTag("DataItem").GetComponent<ItemDATA>();
        spawnlogvalue = Random.Range(spawnvalue1, spawnvalue2);
    }

    
    void Update()
    {
        if (health <= 0)
        {
            spawnobject(spawnlogvalue);
            Destroy(gameObject);
        }
        
    }


    public void spawnobject(int spawncount)
    {
        for (int i = 0; i < spawncount;i++)
        {
           GameObject instantsources = Instantiate(spawngameobject, spawnlocation[i].position, Quaternion.identity) as GameObject;
            instantsources.GetComponent<Obj>().item = itemdata.items[sourcesitemid];
        }
    }
}
