using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl2 : MonoBehaviour
{
    public float speed = 30;

    Rigidbody2D rb2D;

    bool left = false;

    private void FixedUpdate()
    {
        if (left == true)
            rb2D.velocity = new Vector2(-1, 0) * speed;
        else
            rb2D.velocity = new Vector2(-1,0) * 0;
    }


}
