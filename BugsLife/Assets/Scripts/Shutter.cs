using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shutter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Conbo;
    [SerializeField] Image Conbo_Back;
    [SerializeField] Image Filter;
    [SerializeField] Image ReloadImage;
    [SerializeField] Slider ScoreCharge;
    public int conbo = 0;
    int conbo_check = 0;
    float Speed = 10f;
    float chargeTime = 0f;
    [SerializeField] Charge charge;
    [SerializeField] GameManager gamemanager;
    public bool flash = false;
    public bool flashattack = false;
    bool reload = false;
    [SerializeField] Light FlashLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(conbo != 0){
            Conbo_Back.GetComponent<RectTransform>().anchoredPosition = new Vector2(-290 + (((int)Mathf.Log10(conbo))*70), 0f);
            Conbo.text = "<size=120>" + conbo + "</size><size=80>COMBO</size>";
        }
        else Conbo.text = null;

        if(!gamemanager.pause){
            if(flash){
                /*Filter.color += new Color32 (0, 0, 0, 2);
                if(Filter.color == new Color32 (0, 0, 0, 240)) flash = false;*/
                //RenderSettings.fogDensity += 0.5f*Time.deltaTime;
                FlashLight.intensity -= 40*Time.deltaTime;;
                //if(RenderSettings.fogDensity >= 0.25f) flash = false;
                if(FlashLight.intensity == 0f) flash = false;
            }
            else if(flashattack){
                if(!flash){
                    //RenderSettings.fogDensity += Time.deltaTime;
                    FlashLight.intensity -= 80*Time.deltaTime;;
                    //if(RenderSettings.fogDensity >= 0.25f) flashattack = false;
                    if(FlashLight.intensity == 0f) flashattack = false;
                }
            }

            if(chargeTime > 0f){
                chargeTime -= Time.deltaTime;
                ReloadImage.fillAmount = chargeTime;
            }
            else reload = true;
        }

        ScoreCharge.value = (int)(conbo%10);
    }

    public void Shutter_Moment(GameObject Flash_Color)
    {
        //StartCoroutine( Flash(Flash_Color));
        GameObject f = Instantiate(Flash_Color, this.transform.position, this.transform.rotation);
        Rigidbody rb = f.GetComponent<Rigidbody>();
        rb.AddForce(this.transform.forward * Speed, ForceMode.Impulse); 
        flashattack = true;
        //RenderSettings.fogDensity = 0f;
        FlashLight.intensity = 40;
    }

    /*IEnumerator Flash(GameObject flash)
    {
        GameObject f = Instantiate(flash, this.transform.position, this.transform.rotation);
        Rigidbody rb = f.GetComponent<Rigidbody>();
        rb.AddForce(this.transform.forward * Speed, ForceMode.Impulse); 
        //yield return new WaitForSeconds(3f);
        //Destroy(f);
    }*/

    public void FinalFlash_Button(GameObject finalflash)
    {
        if(reload){
            flash = true;
        
            //RenderSettings.fogDensity = 0f;
            FlashLight.intensity = 40;

            if(charge.FinalFlashGage.fillAmount == 1) {
                StartCoroutine( FinalFlash(finalflash));
                charge.power = 0;
            }

            reload = false;
            chargeTime = 1f;
        }
    }
    IEnumerator FinalFlash(GameObject finalflash)
    {
        GameObject f = Instantiate(finalflash, this.transform.position, this.transform.rotation);
        Rigidbody rb = f.GetComponent<Rigidbody>();
        //rb.AddForce(this.transform.forward * Speed, ForceMode.Impulse); 
        rb.velocity = transform.forward * Speed;
        yield return new WaitForSeconds(3f);
        Destroy(f);
    }
}
