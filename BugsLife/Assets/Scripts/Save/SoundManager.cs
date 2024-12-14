using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    //public Setting setting;
    public float master = 0.7f;
    public float bgm = 0.7f;
    public float se = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(setting != null){
            if (SceneManager.GetActiveScene().name == "TitleScene" && setting.set){
                master = setting.master;
                bgm = setting.masbgmter;
                se = setting.se;
            }
        }
        else if (SceneManager.GetActiveScene().name == "TitleScene") setting = GameObject.Find("SettingManager").GetComponent<Setting>();*/
    }
}
