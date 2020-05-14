using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    float dirX, moveSpeed = 3f;
    bool moveUP = true;

    private void Update()
    {
        if (transform.position.x > 5f)
            moveUP = false;
        if (transform.position.x < -5f)
            moveUP = true;

        if (moveUP)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);

    }
}
