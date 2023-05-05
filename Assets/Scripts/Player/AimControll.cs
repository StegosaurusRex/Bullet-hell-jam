using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimControll : MonoBehaviour
{
    bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // using mousePosition and player's transform (on orthographic camera view)
        var delta = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (delta.x >= 0 && !facingRight)
        { // mouse is on right side of player
            transform.rotation = Quaternion.Euler(0,0,0); // or activate look right some other way
            facingRight = true;
            Debug.Log("Right");
        }
        else if (delta.x < 0 && facingRight)
        { // mouse is on left side
            transform.rotation = Quaternion.Euler(0 , 180 , 0); // or activate look right some other way
            facingRight = false;
            Debug.Log("Left");
        }

    }
   
}
