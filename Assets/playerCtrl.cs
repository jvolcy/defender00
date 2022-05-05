using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerCtrl : MonoBehaviour
{
    public SkylineCtrl skylineCtrl;
    public float VSpeed = 1f;
    public float HSpeed = 0f;
    public float HorzAcceleration = 0.02f;
    public float MinHSpeed = 0f;
    public float MaxHSpeed = 10f;
    public float HDrag = 0.999f;
    public float VDragCoef = 0.03f;
    public TMP_Text SpeedText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))  //go up
        {
            transform.Translate(0f, VSpeed * Time.deltaTime * HSpeed / MaxHSpeed, 0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))    //go down
        {
            transform.Translate(0f, -VSpeed * Time.deltaTime * HSpeed / MaxHSpeed, 0f);
        }
        else
        {
            transform.Translate(0f, VSpeed * Input.GetAxis("Vertical") * Time.deltaTime * HSpeed / MaxHSpeed, 0f);
        }


        if (Input.GetKey(KeyCode.LeftArrow))    //slow down
        {
            HSpeed -= HorzAcceleration;
        }
        else if (Input.GetKey(KeyCode.RightArrow))   //speed up
        {
            HSpeed += HorzAcceleration;
        }
        else
        {
            HSpeed += HorzAcceleration * Input.GetAxis("Horizontal");
        }

        float VDrag = 1f - (HSpeed / MaxHSpeed);
        if (transform.position.y > -4.25)
        {
            transform.Translate(0f, -VDragCoef * VDrag, 0f);
        }

        HSpeed = Mathf.Clamp(HSpeed, MinHSpeed, MaxHSpeed);

        HSpeed *= HDrag;
        SpeedText.text = "Speed: " + HSpeed.ToString("0.00");

        skylineCtrl.Speed = -HSpeed;
    }
}
