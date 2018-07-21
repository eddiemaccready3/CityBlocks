using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Set score to zero
        // Set timer to 60 seconds
        // Set level to 1
        // Spawn random block
        // Spawn 3 random patterns
	}
	
	// Update is called once per frame
	void Update () {
		// Classes
            // Timer()
            // Gravity()
            // CheckBlockCollision()
                // SpawnNewBlock()
            // CheckLMBClick()
            // CheckLMBRelease()
            // CheckPatternMatch()
                // DestroyBlock()
                // ScoreKeeper
                // SpawnNewPattern()
                //NextLevel
            // PaintSprayer()
            // EndGame()
        // Game loop
            // Every second decrease Timer() by 1
            // Every frame, CheckBlockCollision().  If no collision, Gravity()
            // If CheckLMBClick() returns true, PaintSprayer()
            // If CheckLMBReleased() returns true, CheckPatternMatch()
            // If Timer() returns 0, EndGame()

	}
}
