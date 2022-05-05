using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkylineCtrl : MonoBehaviour
{
    public GameObject Skyline1;
    public GameObject Skyline2;
    public GameObject Runway;

    public float Speed;
    float Skyline1Pos;
    float Skyline2Pos;


    // Start is called before the first frame update
    void Start()
    {
        Skyline1Pos = Skyline1.transform.position.x;
        Skyline2Pos = Skyline2.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Skyline1Pos += Speed * Time.deltaTime;
        if (Skyline1Pos < -16.0) Skyline1Pos += 32;
        if (Skyline1Pos > 16.0) Skyline1Pos -= 32;

        Skyline2Pos += Speed * Time.deltaTime;
        if (Skyline2Pos < -16.0) Skyline2Pos += 32;
        if (Skyline2Pos > 16.0) Skyline2Pos -= 32;

        Skyline1.transform.position = new Vector2(Skyline1Pos, Skyline1.transform.position.y);
        Skyline2.transform.position = new Vector2(Skyline2Pos, Skyline2.transform.position.y);
        Runway.transform.Translate(Speed * Time.deltaTime, 0f, 0f);
    }
}
