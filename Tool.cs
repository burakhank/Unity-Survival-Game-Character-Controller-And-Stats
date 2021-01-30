using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    private AudioSource soundmanager;
    [Header("Zeptun sound Randomizer")]
    public AudioClip[] sesler;
    [Header("Zeptun Tool System")]
    //public Animator tool;
    public Animator reference;
    public float damage1, damage2, raycastlenght;
    float cooldowntimer;
    public float cooldown,afteranimcooldown;
    public GameObject test;
    GameObject destroyreference;
    RaycastHit hit;
    AllCode cd;
    void Start()
    {
        cd = GameObject.FindGameObjectWithTag("Codes").GetComponent<AllCode>();
        soundmanager = GameObject.FindGameObjectWithTag("soundmanager").GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, raycastlenght))
            {
                if (hit.transform.tag == "Tree" && Time.time > cooldowntimer)
                {

                    cooldowntimer = Time.time + cooldown;
                    //tool.Play("Axe Wood cutting");
                    reference.Play("wood cutting handle axe");
                    sources source = hit.transform.gameObject.GetComponent<sources>();
                    source.health -= Random.Range(damage1, damage2);
                    cd.inventor.items[GetComponent<HandITem>().slotsayi].itemdurability -= Random.Range(1, 3);
                    Debug.Log(Random.Range(damage1, damage2));
                    Animator treeanim = hit.transform.gameObject.GetComponent<Animator>();
                    treeanim.Play("tree hit shaking");
                    destroyreference =  Instantiate(test, hit.transform.position, hit.transform.rotation);
                    Destroy(destroyreference, 3);
                    int soundnumber = Random.Range(0, sesler.Length);
                    soundmanager.PlayOneShot(sesler[soundnumber]);
                }
            }
        }
    }
}

