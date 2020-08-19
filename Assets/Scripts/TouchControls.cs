using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    public float speed = 30;

    public GameObject theBullet;

    public Rigidbody2D Rigidbody;


    public void Left()
    {
        float horzMove = -1;
        Rigidbody.velocity = new Vector2(horzMove, 0) * speed;
    }

    public void Right()
    {
        float horzMove = 1;
        Rigidbody.velocity = new Vector2(horzMove, 0) * speed;
    }

    public void Fire()
    {
        Instantiate(theBullet, transform.position, Quaternion.identity);

        soundManager.Instance.playOneShot(soundManager.Instance.BulletFire);
    }
}
