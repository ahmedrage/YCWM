using UnityEngine;
using System.Collections;

public class hidingSpot : MonoBehaviour {
	public SpriteRenderer sprite;
	public Color transparentColor;
	public Color normalColor;

	public bool isHiding;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		normalColor = sprite.color;
	}
	
	// Update is called once per frame
	void OnTriggerExit2D(Collider2D other) {
		sprite.color = normalColor;

		if (other.gameObject.tag == "Player") {
			other.gameObject.layer = 8;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		sprite.color = transparentColor;

		if (other.gameObject.tag == "Player") {
			other.gameObject.layer = 9;
		}
	}
}
