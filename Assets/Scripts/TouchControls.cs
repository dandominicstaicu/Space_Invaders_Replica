using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    public float speed = 30;

    public GameObject theBullet;

    Rigidbody2D rb2D;

    private bool left = false;
    private bool right = false;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(left == true)
            rb2D.velocity = new Vector2(-10, 0) * speed;
        else
            rb2D.velocity = new Vector2(-1, 0) * 0;

        if (right == true)
            rb2D.velocity = new Vector2(1, 0) * speed;
        else
            rb2D.velocity = new Vector2(1, 0) * 0;
    }

    public void MoveRight()
    {
        right = true;
    }

    public void StopMoveRight()
    {
        right = false;
    }

    public void MoveLeft()
    {
        left = true;
    }

    public void StopMoveLeft()
    {
        left = false;
    }

    public void Shoot()
    {
        Instantiate(theBullet, transform.position, Quaternion.identity);

        soundManager.Instance.playOneShot(soundManager.Instance.BulletFire);
    }
}