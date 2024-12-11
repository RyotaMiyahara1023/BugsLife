using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charge : MonoBehaviour
{
    [SerializeField] Image FinalFlashGage;
    [SerializeField] Sprite[] Button_Image = new Sprite[2];
    public int power = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FinalFlashGage.fillAmount = (float)(power) / 10;
        if(FinalFlashGage.fillAmount < 1) this.gameObject.GetComponent<Image>().sprite = Button_Image[0];
        else this.gameObject.GetComponent<Image>().sprite = Button_Image[1];
    }
}
