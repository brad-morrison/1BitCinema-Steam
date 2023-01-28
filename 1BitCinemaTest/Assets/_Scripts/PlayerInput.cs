using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Controller controller;
    public float speed = 10.0f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public Sprite vert, hori;
    public float offset= 0.5f;
    public Vector2 angleVector;

    public bool up, down, left, right;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //angleVector = VectorFromAngle(angleVectorDeg);
        
    }

    // Update is called once per frame
    void Update()
    {
        //angleVector = VectorFromAngle(angleVectorDeg);
        movement = new Vector2(0, 0);

        if (Input.GetKey("w") || up)
        {
            GetComponent<SpriteRenderer>().sprite = vert;
            GetComponent<SpriteRenderer>().flipX = true;
            movement = new Vector2(1, offset);
        }

        if (Input.GetKey("a") || left)
        {
            GetComponent<SpriteRenderer>().sprite = vert;
            GetComponent<SpriteRenderer>().flipX = false;
            movement = new Vector2(-1, offset);
        }

        if (Input.GetKey("s") || down)
        {
            GetComponent<SpriteRenderer>().sprite = hori;
            GetComponent<SpriteRenderer>().flipX = true;
            movement = new Vector2(-1, offset * -1);
        }

        if (Input.GetKey("d") || right)
        {
            GetComponent<SpriteRenderer>().sprite = hori;
            GetComponent<SpriteRenderer>().flipX = false;
            movement = new Vector2(1, offset * -1);
        }

        if (Input.GetKey("1"))
        {
            
        }

        if (Input.GetKey("2"))
        {
            

        }

    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    Vector2 VectorFromAngle(float theta)
    {
        return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)); // Trig is fun
        
    }
}
