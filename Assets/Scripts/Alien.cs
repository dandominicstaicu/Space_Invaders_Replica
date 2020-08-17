using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody2D rigidBody;

    public Sprite startingImage;
    public Sprite altImage;

    private SpriteRenderer spriteRenderer;

    public float secBeforeSpriteChange = 0.5f;

    public GameObject alienBullet;

    public float minFireRateTime = 1.0f;
    public float maxFireRateTime = 3.0f;
    public float baseFireWaitTime = 3.0f;

    public Sprite explodedShipImage;

    float sceneTime;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = new Vector2(1, 0) * speed;

        spriteRenderer = GetComponent<SpriteRenderer>();

        sceneTime = 0.0f;

        StartCoroutine(ChangeAlienSprite());

        baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

    }

    void Turn(int direction)
    {
        Vector2 newVelocity = rigidBody.velocity;
        newVelocity.x = speed * direction;
        rigidBody.velocity = newVelocity;
    }

    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 1;
        transform.position = position;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "leftWall")
        {
            Turn(1);
            MoveDown();
        }
        if (col.gameObject.name == "rightWall")
        {
            Turn(-1);
            MoveDown();
        }

        if (col.gameObject.tag == "Bullet")
        {
            soundManager.Instance.playOneShot(soundManager.Instance.AlienDies);
            Destroy(gameObject);
        }


    }

    public IEnumerator ChangeAlienSprite()
    {
        while (true)
        {
            if (spriteRenderer.sprite == startingImage)
            {
                spriteRenderer.sprite = altImage;
                soundManager.Instance.playOneShot(soundManager.Instance.AlienBuzz1);
            }
            else
            {
                spriteRenderer.sprite = startingImage;
                soundManager.Instance.playOneShot(soundManager.Instance.AlienBuzz2);
            }

            yield return new WaitForSeconds(secBeforeSpriteChange);
        }
    }

    void FixedUpdate()
    {
        sceneTime += Time.fixedDeltaTime;
        if (sceneTime > baseFireWaitTime)
        {
            baseFireWaitTime += Random.Range(minFireRateTime, maxFireRateTime);

            Instantiate(alienBullet, transform.position, Quaternion.identity);
        }
    }

        void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            soundManager.Instance.playOneShot(soundManager.Instance.ShipExplosion);

            col.GetComponent<SpriteRenderer>().sprite = explodedShipImage;

            Destroy(gameObject);

            DestroyObject(col.gameObject, 0.5f);
        }
    }


}