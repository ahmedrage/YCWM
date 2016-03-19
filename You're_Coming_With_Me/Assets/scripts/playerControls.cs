using UnityEngine;
using System.Collections;

public class playerControls : MonoBehaviour {
	public float speed;
	public float horizontalMove;

	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		horizontalMove = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (horizontalMove * speed, rb.velocity.y);
			
	}
}
