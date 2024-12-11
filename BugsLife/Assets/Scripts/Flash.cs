using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public int conbo = 0;
    Shutter shutter;
    Charge charge;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        shutter = GameObject.Find("Main Camera").GetComponent<Shutter>();
        charge = GameObject.Find("Final_Flash").GetComponent<Charge>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1){
            time += Time.deltaTime;
            if(time >= 3f) {
                shutter.conbo = 0;
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision otaku)
    {
        if(this.gameObject.name.Contains(otaku.gameObject.tag)){
            Destroy(otaku.gameObject);
            Destroy(gameObject);
            Debug.Log("倒せた");
            shutter.conbo++;
            charge.power++;
        }
        else if(otaku.gameObject.name.Equals("Capsule")){
            Debug.Log("プレイヤーです");
        }
        else if(otaku.gameObject.name.Contains("Otaku") && !this.gameObject.name.Contains(otaku.gameObject.tag)){
            Debug.Log("別のオタクです");
            shutter.conbo = 0;
            Destroy(gameObject);
        }
        else if(otaku.gameObject.tag.Equals("Flash")){
            Debug.Log("フラッシュです");
        }
        else {
            Debug.Log("倒せない");
        }
    }
}
