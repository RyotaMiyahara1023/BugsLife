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
    public int conbo = 0;
    int conbo_check = 0;
    public float Speed = 60f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Conbo.text = "<size=80>" + conbo + " </size><size=50>Conbo</size>";
    }

    public void Shutter_Moment(GameObject Flash_Color)
    {
        StartCoroutine( Flash(Flash_Color));
    }

    IEnumerator Flash(GameObject flash)
    {

        /*switch(Flash_Color){
            case "Red":
            GameObject flash = Instantiate(Red_Flash, this.transform.position, Quaternion.identity);
            Rigidbody rb = flash.GetComponent<Rigidbody>();
            rb.AddForce(this.transform.forward * Speed); 
            yield return new WaitForSeconds(3f);
            Destroy(flash);
            ConboCheck();
            break;

            case "Blue":
            GameObject flash = Instantiate(Blue_Flash, this.transform.position, Quaternion.identity);
            Rigidbody rb = flash.GetComponent<Rigidbody>();
            rb.AddForce(this.transform.forward * Speed); 
            yield return new WaitForSeconds(3f);
            Destroy(flash);
            ConboCheck();
            break;

            case "Green":
            GameObject flash = Instantiate(Green_Flash, this.transform.position, Quaternion.identity);
            Rigidbody rb = flash.GetComponent<Rigidbody>();
            rb.AddForce(this.transform.forward * Speed); 
            yield return new WaitForSeconds(3f);
            Destroy(flash);
            ConboCheck();
            break;
        }*/
        GameObject f = Instantiate(flash, this.transform.position, Quaternion.identity);
        Rigidbody rb = f.GetComponent<Rigidbody>();
        rb.AddForce(this.transform.forward * Speed, ForceMode.Impulse); 
        yield return new WaitForSeconds(3f);
        Destroy(f);
        //ConboCheck();
    }

    void ConboCheck(){
            if(conbo != conbo_check) {
                //Conbo.text = "<size=80>" + conbo + " </size><size=50>Conbo</size>";
                conbo_check = conbo;
            }
            else {
                Conbo.text = null;
                conbo = 0;
                conbo_check = 0;
            }
            /*flash.conbo = 0;
            yield return new WaitForSeconds(1f);
            Conbo.text = null;*/
    }
}
