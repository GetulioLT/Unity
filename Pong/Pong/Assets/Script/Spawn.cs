using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ball, new Vector2(0, 0), Quaternion.identity);
    }

}
