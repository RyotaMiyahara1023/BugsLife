using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charge : MonoBehaviour
{
    public Image FinalFlashGage;
    [SerializeField] Sprite[] Button_Image = new Sprite[2];
    public int power = 0;
    AudioSource audiosource;
    [SerializeField] AudioClip[] ChargeSE = new AudioClip[9];
    SoundManager soundmanager;
    [SerializeField] Shutter shutter;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        soundmanager = GameObject.Find("Manager").GetComponent<SoundManager>();
        shutter = GameObject.Find("Main Camera").GetComponent<Shutter>();
    }

    // Update is called once per frame
    void Update()
    {
        FinalFlashGage.fillAmount = (float)(power) / 8;
        if(FinalFlashGage.fillAmount < 1) this.gameObject.GetComponent<Image>().sprite = Button_Image[0];
        else this.gameObject.GetComponent<Image>().sprite = Button_Image[1];
        audiosource.volume = soundmanager.master * soundmanager.se;
    }

    public void SE(){
        /*if(power == 8) {
            audiosource.PlayOneShot(ChargeSE[7]);
            audiosource.PlayOneShot(ChargeSE[8]);
        }
        else if(power < 8) audiosource.PlayOneShot(ChargeSE[power - 1]);
        else audiosource.PlayOneShot(ChargeSE[7]);
        Debug.Log(power);*/
        if(power == 8) audiosource.PlayOneShot(ChargeSE[8]);
        if(shutter.conbo <= 7) audiosource.PlayOneShot(ChargeSE[shutter.conbo - 1]);
        else audiosource.PlayOneShot(ChargeSE[7]);
    }
}
