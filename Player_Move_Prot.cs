using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour {

    public float speed = 10, jumpVelocity = 1, fallMultiplier = 2.5f, elapsedTime, baseVelocity = 20;
    public LayerMask playerMask;
    bool isGrounded, isGrounded2, isGrounded3, isGrounded4, isGrounded5, jumpRequest;
    Transform myTrans, tagGround2, tagGround3, tagGround4, tagGround5;
    Rigidbody2D myBody;
    float hInput;
    Vector2 playerSize, boxSize;

    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myTrans = this.transform;
        tagGround2 = GameObject.Find(this.name + "/tag_ground2").transform;
        tagGround3 = GameObject.Find(this.name + "/tag_ground3").transform;
        tagGround4 = GameObject.Find(this.name + "/tag_ground4").transform;
        tagGround5 = GameObject.Find(this.name + "/tag_ground5").transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequest = true;
        }
    }

    void FixedUpdate()
    {
        hInput = Input.GetAxisRaw("Horizontal");

        isGrounded2 = Physics2D.Linecast(myTrans.position, tagGround2.position, playerMask);
        isGrounded3 = Physics2D.Linecast(myTrans.position, tagGround3.position, playerMask);
        isGrounded4 = Physics2D.Linecast(myTrans.position, tagGround4.position, playerMask);
        isGrounded5 = Physics2D.Linecast(myTrans.position, tagGround5.position, playerMask);

        isGrounded = (isGrounded2 || isGrounded3 || isGrounded4 || isGrounded5);

        // More Realistic Gravity (acceleration downward)
        /*if(myBody.velocity.y < 0)
        {
            myBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        */



        if (jumpRequest)
        {
            myBody.AddForce(Vector2.up * baseVelocity, ForceMode2D.Impulse);
            jumpRequest = false;
            isGrounded = false;
        }
        Move(hInput);
    }

    void Move(float horizonalInput)
    {
        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizonalInput * speed;
        myBody.velocity = moveVel;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyMove enemy = collision.collider.GetComponent<EnemyMove>();
        if(enemy != null)
        {
            gameObject.GetComponent<Player_Death>().hasDied = true;
        }
    }
}
