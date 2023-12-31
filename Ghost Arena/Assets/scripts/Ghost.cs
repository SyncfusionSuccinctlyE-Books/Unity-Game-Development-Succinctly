﻿using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {

    public GameObject Player;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Globals.CurGameState == GameState.PlayingGame)
        {
            float step = Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step);

            Vector3 player = Camera.main.WorldToScreenPoint(Player.transform.position);
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
            Vector2 offset = new Vector2(player.x - screenPoint.x, player.y - screenPoint.y);
            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg - 90.0f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (Globals.CurGameState == GameState.GameOver)
            Destroy(gameObject);

    }
    
}
