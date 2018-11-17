using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardSnap : MonoBehaviour {
    Rigidbody rb;
    bool chosen = false;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Table")
        {
            Vector3 oldpos = transform.position;
            transform.rotation = Quaternion.Euler(0, -90, 0);
            transform.position = new Vector3(oldpos.x, -0.45f, oldpos.z); 
            rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.detectCollisions = false;
            chosen = true;
        }
    }

}
