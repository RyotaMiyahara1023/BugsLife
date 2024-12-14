using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otaku : MonoBehaviour
{
    float speed = 1.5f;
    GameManager gamemanager;
    Shutter shutter;
    [SerializeField] Material[] _material;
    //Color32 bobycolor;
    //Color32 uchiwacolor;
    //Color32 lightcolor;
    [SerializeField] GameObject Effect;
    GameObject Idol;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        shutter = GameObject.Find("Main Camera").GetComponent<Shutter>();
        Idol = GameObject.Find("Main Camera");
        this.transform.LookAt(new Vector3(Idol.transform.position.x,this.transform.position.y,Idol.transform.position.z));
        //mycolor = _material.color;
        //bobycolor = _material[0].color;
        //uchiwacolor = _material[1].color;
        //lightcolor = _material[2].color;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gamemanager.pause && !gamemanager.clear && !gamemanager.gameover) transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0f, 0f), speed * Time.deltaTime);

        if(shutter.flash || shutter.flashattack) {
            //_material.color = mycolor;
            _material[0].color = new Color32 (255, 255, 255, 0);
            _material[1].color = new Color32 (255, 255, 255, 0);
            _material[2].color = new Color32 (255, 255, 255, 0);
        }
        else{
            _material[0].color = new Color32 (0, 0, 0, 0);
            _material[1].color = new Color32 (0, 0, 0, 0);
            _material[2].color = new Color32 (0, 0, 0, 0);
        }
    }

    public void Death()
    {
        GameObject e = Instantiate(Effect, this.transform.position, Quaternion.identity);
        Destroy(e, 2f);
    }
}
