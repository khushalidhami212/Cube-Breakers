using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.touches[0].position.x < 0)
                OnLeftInput();
            else
                OnRightInput();
        }
    }
    public void OnLeftInput()
    {
        player.JumpLeft();
    }
    public void OnRightInput()
    {
        player.JumpRight();
    }

}
