using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (Globals.CurGameState == GameState.PlayingGame)
        {
            if (collider.gameObject.tag == "Ghost")
            {
                Globals.Score += (Globals.DifficultyLevel + 1) * 5;
                Destroy(collider.gameObject);
                Destroy(gameObject);
            }
        }
    }

    void Update ()
    {
        if (Globals.CurGameState == GameState.PlayingGame)
        {
            transform.Translate(Vector2.up * .1f);
            //destroy if at arena wall
            if (transform.position.x >= 5 || transform.position.x <= -5 ||
                transform.position.y >= 3.4 || transform.position.y <= -3.4)
            {
                Destroy(gameObject);
                //Debug.Log("destroying bullet");
            }
        }
    }
}
