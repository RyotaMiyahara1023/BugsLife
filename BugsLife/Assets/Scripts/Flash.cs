using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public int conbo = 0;
    Shutter shutter;
    Charge charge;
    // Start is called before the first frame update
    void Start()
    {
        shutter = GameObject.Find("Main Camera").GetComponent<Shutter>();
        charge = GameObject.Find("Final_Flash").GetComponent<Charge>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider otaku)
    {
        if(this.gameObject.name.Contains(otaku.gameObject.tag)){
            Destroy(otaku.gameObject);
            Debug.Log("倒せた");
            shutter.conbo++;
            charge.power++;
        }
        else if(otaku.gameObject.name.Equals("Capsule")){
            Debug.Log("プレイヤーです");
        }
        else if(otaku.gameObject.name.Contains("Otaku") && !this.gameObject.name.Contains(otaku.gameObject.tag)){
            Debug.Log("別のオタクです");
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
