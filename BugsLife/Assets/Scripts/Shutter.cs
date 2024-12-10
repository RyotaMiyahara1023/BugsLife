using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shutter : MonoBehaviour
{
    [SerializeField] GameObject Red_Flash;
    [SerializeField] GameObject Blue_Flash;
    [SerializeField] GameObject Green_Flash;
    [SerializeField] Text Conbo;
    Flash flash;
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
        var c = 0;

        switch(Flash_Color){
            case "Red":
            flash = Red_Flash.GetComponent<Flash>();
            Red_Flash.SetActive(true);
            yield return new WaitForSeconds(0.05f);
            Red_Flash.SetActive(false);
            c = flash.conbo;
            Conbo.text = c + " conbo";
            flash.conbo = 0;
            yield return new WaitForSeconds(1f);
            Conbo.text = null;
            break;

            case "Blue":
            flash = Blue_Flash.GetComponent<Flash>();
            Blue_Flash.SetActive(true);
            yield return new WaitForSeconds(0.05f);
            Blue_Flash.SetActive(false);
            c = flash.conbo;
            Conbo.text = c + " conbo";
            flash.conbo = 0;
            yield return new WaitForSeconds(1f);
            Conbo.text = null;
            break;

            case "Green":
            flash = Green_Flash.GetComponent<Flash>();
            Green_Flash.SetActive(true);
            yield return new WaitForSeconds(0.05f);
            Green_Flash.SetActive(false);
            c = flash.conbo;
            Conbo.text = c + " conbo";
            flash.conbo = 0;
            yield return new WaitForSeconds(1f);
            Conbo.text = null;
            break;
        }
    }
}
