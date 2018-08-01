using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyMove enemy = collision.collider.GetComponent<EnemyMove>();
        if (enemy != null)
        {
            gameObject.GetComponent<Player_Death>().hasDied = true;
        }
    }
}
