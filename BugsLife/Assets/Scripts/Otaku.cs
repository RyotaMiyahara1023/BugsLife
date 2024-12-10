using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otaku : MonoBehaviour
{
    float speed = 2;
    [SerializeField] Transform Idol_pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 1f, 0f), speed * Time.deltaTime);
    }
}
