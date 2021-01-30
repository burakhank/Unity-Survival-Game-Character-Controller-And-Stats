using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildspawn : MonoBehaviour
{

    public int[] id;
    public int[] needvalue;
    public int[] completedvalue;
    public bool[] cheker;
    public GameObject finalobject;

    void Start()
    {
        
    }

   
    void Update()
    {
        startcheck();

        if (cheker[1] && cheker[2]  && cheker[3] && cheker[4] && cheker[5] && cheker[6] && cheker[7] )
        {
            Instantiate(finalobject,gameObject.transform.position,gameObject.transform.rotation);
            Destroy(gameObject);
        }

    }

    public void startcheck()
    {
        if (needvalue[0] <= completedvalue[0] )
        {
            cheker[0] = true;
        }
        if (needvalue[1] <= completedvalue[1])
        {
            cheker[1] = true;
        }
        if (needvalue[2] <= completedvalue[2])
        {
            cheker[2] = true;
        }
        if (needvalue[3] <= completedvalue[3])
        {
            cheker[3] = true;
        }
        if (needvalue[4] <= completedvalue[4])
        {
            cheker[4] = true;
        }
        if (needvalue[5] <= completedvalue[5])
        {
            cheker[5] = true;
        }
        if (needvalue[6] <= completedvalue[6])
        {
            cheker[6] = true;
        }
        if (needvalue[7] <= completedvalue[7])
        {
            cheker[7] = true;
        }

    }
}
