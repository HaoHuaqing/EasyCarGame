using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class carcontrol : MonoBehaviour
{
    static List<string> mWriteTxt = new List<string>();
    private string outPath;
    public Text timetext;
    private float timer = 0f;
    private int time = 0;
    private int pixelcount = 25;//(car.y-startpostion.y)/0.2
    private float carmoveforward = 0;
    private float[] randNormal = new float[5000];
    private int countstart = 0;
    private float carspeedY = 0.4f;
    void Start()
    {
       
    }

    void Update()
    {
        //set car speed on the road 4,out of road 1.
        float JoystickX = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(10 * (JoystickX ), carmoveforward, 0);
        transform.position = move;
        if (move.x <= (Bezier.pixel[pixelcount].x + 1.5) && move.x >= (Bezier.pixel[pixelcount].x - 1.5))
        {
            carmoveforward += carspeedY;
            pixelcount += 4;
        }
        else
        {
            carmoveforward += carspeedY / 4;
            pixelcount++;
        }
        if (carmoveforward >= 950)
        {
            Application.Quit();
        }


        timer = Time.time;
        //Debug.Log(h);
        time = (int)timer;
        timetext.text = ("Time:" + time);

       

    }
}
