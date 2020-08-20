using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float speed = 30;

    public GameObject theBullet;

    void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed; 
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("SpaceShipShoot"))
        {
            Instantiate(theBullet, transform.position, Quaternion.identity);

            soundManager.Instance.playOneShot(soundManager.Instance.BulletFire);
        }
    }
}
