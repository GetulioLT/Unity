using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rig;
    public GameObject ball;
    public Transform ret;
    public float speedUp;

    // Start is called before the first frame update
    void Start()
    {

        speedUp = 1;

    }

    // Update is called once per frame
    void Update()
    {
        Lauch();
    }

    private void Lauch()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {

            float x = Random.Range(-1, 1) == 0 ? -1 : 1;
            float y = Random.Range(-1, 1) == 0 ? -1 : 1;

            rig.velocity = new Vector2(x * speed, y * speed);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Gol1" || collision.gameObject.tag == "Gol2")
        {

            speedUp = 1;

            ret.position = new Vector2(0, 0);

            rig.velocity = new Vector2(0, 0);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Wall")
        {

            speedUp += 0.05f;

            rig.velocity = new Vector2(rig.velocity.x * speedUp, rig.velocity.y * speedUp);

        }

    }

}
