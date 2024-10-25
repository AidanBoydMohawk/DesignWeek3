using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float maxSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb2D.interpolation = RigidbodyInterpolation2D.Interpolate;

        PhysicsMaterial2D material = new PhysicsMaterial2D();
        material.friction = 0.5f;
        material.bounciness = 0f;
        GetComponent<Collider2D>().sharedMaterial = material;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Limit the maximum velocity of the ball        
        rb2D.velocity = Vector2.ClampMagnitude(rb2D.velocity, maxSpeed);
        SavePlayerPosition();
    }

    public void SavePlayerPosition()
    {
        Vector2 playerposition = transform.position;

        PlayerPrefs.SetFloat("PlayerPosX", playerposition.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerposition .y);
    }

    public void LoadPlayerPosition()
    {
        float x = PlayerPrefs.GetFloat("PlayerPosX");
        float y = PlayerPrefs.GetFloat("PlayerPosY");

        transform.position = new Vector2(x, y);
    }


    
}
