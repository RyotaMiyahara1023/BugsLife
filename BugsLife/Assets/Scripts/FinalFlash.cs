using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFlash : MonoBehaviour
{
    public int conbo = 0;
    Shutter shutter;
    // Start is called before the first frame update
    void Start()
    {
        shutter = GameObject.Find("Main Camera").GetComponent<Shutter>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,3*Time.timeScale);
    }

    void OnTriggerEnter(Collider otaku)
    {
        if(otaku.gameObject.name.Contains("Otaku")){
            Destroy(otaku.gameObject);
            Debug.Log("オタクです");
            shutter.conbo++;
        }
        else if(otaku.gameObject.name.Equals("Capsule")){
            Debug.Log("プレイヤーです");
        }
        else if(otaku.gameObject.tag.Equals("Flash")){
            Debug.Log("フラッシュです");
        }
        else {
            Debug.Log("倒せない");
            shutter.conbo = 0;
        }
    }
}
