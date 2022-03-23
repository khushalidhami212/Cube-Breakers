using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour //player is extended from monobehaviour an unity package class for game object
{

    public Rigidbody2D playerrb;
    public Vector3 leftforceDirection;
    public Vector3 rightforceDirection;
    public float forceMultiplier = 100;//multiply the force 100 times


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            JumpLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            JumpRight();
        }
    }
    public void JumpLeft()
    {
        playerrb.velocity = Vector3.zero;
        playerrb.AddForce(leftforceDirection * forceMultiplier);
    }
    public void JumpRight()
    {
        playerrb.velocity = Vector3.zero;
        playerrb.AddForce(rightforceDirection * forceMultiplier);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("collectible"))
        {
            collision.gameObject.GetComponent<collectible>().OnCollect();
        }
    }
}
