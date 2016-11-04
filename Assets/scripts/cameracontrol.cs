using UnityEngine;
using System.Collections;

public class cameracontrol : MonoBehaviour
{

    public Transform character;   //摄像机要跟随的人物
    public float smoothTime = 0.01f;  //摄像机平滑移动的时间
    private Vector3 cameraVelocity = Vector3.zero;
    private Camera mainCamera;  //主摄像机（有时候会在工程中有多个摄像机，但是只能有一个主摄像机吧）

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 ttt = new Vector3(0, character.position.y + 2.5f, 0);
        transform.position = Vector3.SmoothDamp(transform.position, ttt + new Vector3(0, 0, -5), ref cameraVelocity, smoothTime);
    }

}