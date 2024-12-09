using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutter : MonoBehaviour
{
    [SerializeField] GameObject Red_Flash;
    [SerializeField] GameObject Blue_Flash;
    [SerializeField] GameObject Green_Flash;
    /*Dictionary<GameObject, int> dic = new Dictionary<GameObject, int>(){
        {Red_Flash, 1},
        {Blue_Flash, 2},
        {Green_Flash, 3},
    };*/
    string Flash_Color = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shutter_Moment(GameObject Shutter_Button)
    {
        Flash_Color = Shutter_Button.name;
        StartCoroutine("Flash");
    }

     IEnumerator Flash()
    {
        switch(Flash_Color){
            case "Red":
            Red_Flash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            Red_Flash.SetActive(false);
            break;

            case "Blue":
            Blue_Flash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            Blue_Flash.SetActive(false);
            break;

            case "Green":
            Green_Flash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            Green_Flash.SetActive(false);
            break;
        }
    }
}
