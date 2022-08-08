using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{

    public bool isPlayerOne;
    public float speed;
    public Rigidbody2D rig;
    
    private float mov;

    

    // Update is called once per frame
    void Update()
    {

        if (isPlayerOne)
        {

            mov = Input.GetAxisRaw("Vertical");

        }
        else
        {
            mov = Input.GetAxisRaw("Vertical1");
        }

        rig.velocity = new Vector2(rig.velocity.x, mov * speed);

    }
}
