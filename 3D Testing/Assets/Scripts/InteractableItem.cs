using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2") && transform.parent != null)
        {
            transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Collider>().isTrigger = false;
        }
        if(transform.parent != null)
        {
            transform.position = transform.parent.position +
                transform.parent.transform.forward * offset.z +
                transform.parent.transform.right * offset.x -
                transform.parent.transform.up * offset.y;
        }
    }
}
