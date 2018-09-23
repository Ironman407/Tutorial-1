using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlocker : MonoBehaviour {

    public float speed = 2.5f;
   
    
	// Update is called once per frame
	void Update ()
    {

        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 5), transform.position.y, transform.position.z);
	}
}
