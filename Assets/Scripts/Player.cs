using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ControllerPlayer2D))]

public class Player : MonoBehaviour
{
    float gravity = -20;
    Vector3 velocity;
    ControllerPlayer2D controller; //reference to controller
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ControllerPlayer2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
