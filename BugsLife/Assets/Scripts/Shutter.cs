using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shutter : MonoBehaviour
{
    [SerializeField] Text Conbo;
    public int conbo = 0;
    int conbo_check = 0;
    public float Speed = 60f;
    [SerializeField] Charge charge;
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
        GameObject f = Instantiate(flash, this.transform.position, this.transform.rotation);
        Rigidbody rb = f.GetComponent<Rigidbody>();
        rb.AddForce(this.transform.forward * Speed, ForceMode.Impulse); 
        yield return new WaitForSeconds(3f);
        Destroy(f);
    }

    public void FinalFlash_Button(GameObject flash)
    {
        if(charge.FinalFlashGage.fillAmount == 1) StartCoroutine( FinalFlash(flash));
        charge.power = 0;
    }
    IEnumerator FinalFlash(GameObject finalflash)
    {
        GameObject f = Instantiate(finalflash, this.transform.position, this.transform.rotation);
        Rigidbody rb = f.GetComponent<Rigidbody>();
        rb.AddForce(this.transform.forward * Speed, ForceMode.Impulse); 
        yield return new WaitForSeconds(3f);
        Destroy(f);
    }
}
