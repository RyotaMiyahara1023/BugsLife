using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idol : MonoBehaviour
{
    [SerializeField] GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider otaku)
    {
        if(otaku.gameObject.name.Contains("Otaku")) gamemanager.GameOver();
        else Debug.Log("Otakuは文章の中に含まれていません。");
    }
}
