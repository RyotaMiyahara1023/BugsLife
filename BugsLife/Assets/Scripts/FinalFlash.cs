using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFlash : MonoBehaviour
{
    public int conbo = 0;
    Shutter shutter;
    GameManager gamemanager;
    public int scoreAdd;
    // Start is called before the first frame update
    void Start()
    {
        shutter = GameObject.Find("Main Camera").GetComponent<Shutter>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0,0,3);
    }

    void OnTriggerEnter(Collider otaku)
    {
        if(otaku.gameObject.name.Contains("Otaku")){
            otaku.gameObject.GetComponent<Otaku>().Death();
            Destroy(otaku.gameObject);
            Debug.Log("オタクです");
            shutter.conbo++;
            scoreAdd = 100*((shutter.conbo/10)+1);
            gamemanager.score += scoreAdd;
            gamemanager.StartCoroutine("ScorePlus", scoreAdd);
        }
        else if(otaku.gameObject.name.Equals("Capsule")){
            Debug.Log("プレイヤーです");
        }
        else if(otaku.gameObject.tag.Equals("Flash")){
            Debug.Log("フラッシュです");
        }
        else {
            Debug.Log("倒せない");
        }
    }
}
