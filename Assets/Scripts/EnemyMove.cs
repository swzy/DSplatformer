using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public LayerMask enemyMask;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth, myHeight;
    public int EnemySpeed = 3;
    public int XMoveDirection = 1;
	
    void Start ()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        myWidth = mySprite.bounds.extents.x;
        myHeight = mySprite.bounds.extents.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 lineCastPos = myTrans.position.toVector2() - myTrans.right.toVector2() * myWidth - Vector2.up * myHeight;
        Vector2 lineCastPos2 = myTrans.position.toVector2() - myTrans.right.toVector2() * myWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
        Debug.DrawLine(lineCastPos2, lineCastPos2 - myTrans.right.toVector2() * .02f);
        bool isBlocked = Physics2D.Linecast(lineCastPos2, lineCastPos2 - myTrans.right.toVector2() * .02f, enemyMask);

        // if no ground, turn around
        if (!isGrounded || isBlocked)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.localEulerAngles = currRot;
        }

        // always move forward
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * EnemySpeed;
        myBody.velocity = myVel;
    }
}
