using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    AllCode cd;
    public PlayerStats playerstat;
    [Header("Zeptun Food System")]
    public float health;
    [Range(1, 55)]
    public int saturationvalu1;
    [Range(1, 75)]
    public int saturationvalue2;
    public void Start()
    {
        cd = GameObject.FindGameObjectWithTag("Codes").GetComponent<AllCode>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerstat.food += Random.Range(saturationvalu1, saturationvalue2);
            cd.inventor.items[GetComponent<HandITem>().slotsayi].itemvalue -= 1;
        }
    }
}
