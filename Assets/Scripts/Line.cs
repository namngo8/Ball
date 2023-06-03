using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float moveSpeed, xDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxisRaw("Horizontal");
        if((transform.position.x<=-2.3 && xDirection<0) || (transform.position.x >= 2.3 && xDirection>0))
        {
            return;
        }
        transform.position = transform.position + new Vector3(moveSpeed*xDirection*Time.deltaTime,0,0);
    }
}
