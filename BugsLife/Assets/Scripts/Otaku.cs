using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otaku : MonoBehaviour
{
    float speed = 2;
    GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gamemanager.pause && !gamemanager.clear) transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 1f, 0f), speed * Time.deltaTime);
    }
}
