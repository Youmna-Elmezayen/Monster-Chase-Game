using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    private float speed;

    private Rigidbody2D myBody;


    // Start is called before the first frame update

    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D> ();
        speed = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }

}
