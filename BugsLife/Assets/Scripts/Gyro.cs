using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gyro : MonoBehaviour
{
    Quaternion rot;
    [SerializeField] Text gy_text;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        var rotRH = Input.gyro.attitude;

        rot = (new Quaternion(-rotRH.x, -rotRH.y, -rotRH.z, rotRH.w)) * Quaternion.Euler(90f, 0f, 0f);
        rot.z = 0f;
        transform.localRotation = rot;

        gy_text.text = "x : " + (transform.localEulerAngles.x).ToString("f1") + " , " + (rot.x).ToString("f1") + "\ny : " + (transform.localEulerAngles.y).ToString("f0") + " , " + (rot.y).ToString("f0") + "\nz : " + (transform.localEulerAngles.z).ToString("f0") + " , " + (rot.z).ToString("f0");
    }
}
