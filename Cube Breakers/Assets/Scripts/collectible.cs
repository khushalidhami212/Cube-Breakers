using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    public bool canBeCollected = true;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollect()
    {
        if (!canBeCollected)
            return;
        Destroy(gameObject);
        collectibleManager.instance.UpdateScore();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Boundry") || collision.gameObject.CompareTag("collectible"))
        {
            canBeCollected = false;
            gameObject.layer = LayerMask.NameToLayer("Obstacle");
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("TopCollider"))
        {
            //Game Over
            collectibleManager.instance.GameOver();
        }
    }

}
