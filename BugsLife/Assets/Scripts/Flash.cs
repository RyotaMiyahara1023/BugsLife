using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public int conbo = 0;
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
        if(otaku.gameObject.tag.Equals(this.gameObject.name)){
            Destroy(otaku.gameObject);
            conbo++;
        }
    }
}
