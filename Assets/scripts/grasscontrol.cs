using UnityEngine;
using System.Collections;

public class grasscontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject car = GameObject.Find("car");


        //当第一块背景出视野之后，重置到第二块背景后面
        if (car.transform.position.y>=(transform.position.y+10))
        {
            transform.position = new Vector3(0, car.transform.position.y + 10, 0);
        }
    }
}
