using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otaku : MonoBehaviour
{
    float speed = 1.5f;
    GameManager gamemanager;
    Shutter shutter;
    Material _material;
    Color32 mycolor;
    [SerializeField] GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        shutter = GameObject.Find("Main Camera").GetComponent<Shutter>();
        _material = GetComponent<Renderer>().material;
        mycolor = _material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gamemanager.pause && !gamemanager.clear && !gamemanager.gameover) transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 1f, 2.5f), speed * Time.deltaTime);

        if(shutter.flash || shutter.flashattack) _material.color = mycolor;
        else _material.color = new Color32 (0, 0, 0, 0);
    }

    public void Death()
    {
        GameObject e = Instantiate(Effect, this.transform.position, Quaternion.identity);
        Destroy(e, 2f);
    }
}
