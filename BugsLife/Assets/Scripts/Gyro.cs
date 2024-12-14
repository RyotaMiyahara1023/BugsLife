using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gyro : MonoBehaviour
{
    Quaternion rot;
    [SerializeField] Text gy_text;
    [SerializeField] GameManager gamemanager;
    bool rot_set = false;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gamemanager.pause && !gamemanager.clear && !gamemanager.gameover && Input.gyro.enabled){
            /*var rotRH = Input.gyro.attitude;

            rot = (new Quaternion(-rotRH.x, -rotRH.y, -rotRH.z, rotRH.w)) * Quaternion.Euler(90f, 0f, 0f);
            rot.z = 0f;
            transform.localRotation = rot;*/
            StartCoroutine("GyroCamera");

            /*if(!rot_set){
                rot_set = true;
                gamemanager.OtakuGenerater.transform.eulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);
            }*/

            //gy_text.text = "rot_first:(" + rot_first.x + ", " + rot_first.y + ", " + rot_first.z + ")\nrot:(" + rot.x + ", " + rot.y + ", " + rot.z + ")";
        }
    }

    IEnumerator GyroCamera()
    {

        IEnumerator enumerator = Set_rot();
        yield return enumerator;

        if(!rot_set){
            rot_set = true;
            gamemanager.OtakuGenerater.transform.eulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);
            //gamemanager.OtakuGenerater.transform.position = new Vector3(-2.5f*Mathf.Sin(transform.localEulerAngles.y * Mathf.Deg2Rad), 1f, -2.5f*Mathf.Cos(transform.localEulerAngles.y * Mathf.Deg2Rad));
        }
    }

    IEnumerator Set_rot()
    {
        var rotRH = Input.gyro.attitude;
        rot = (new Quaternion(-rotRH.x, -rotRH.z, -rotRH.y, rotRH.w)) * Quaternion.Euler(90f, 0f, 0f);
        //rot.z = 0f;
        transform.localRotation = rot;
        yield return null;
    }
}
