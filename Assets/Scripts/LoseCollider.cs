using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
    public LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
    void OnTriggerEnter2D(Collider2D collider)
    {
        levelManager.LoadLevel("Lose");
    }
}
