using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class enemy : MonoBehaviour {

	public Transform sightStart;
	public Transform sightEnd;
	public Transform leader;
	public Image seenBar;
	public GameObject alertMark;
	public float increase = 0.1f;
	public float speed;
	public bool switching;
	public bool seen;
	public bool alert;
	public bool turn;

	// Use this for initialization
	void Start () 
	{
		alert = false;
		turn = true;
		switching = true;
		seen = false;
		seenBar = GameObject.Find("seenBar").GetComponent<Image> ();
		InvokeRepeating ("Search", 0f, Random.Range (2f, 4f));
		Physics2D.IgnoreLayerCollision (0, 9);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Raycasting ();
		Logic ();
	
	}

	void Raycasting ()
	{
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
		seen = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer ("player"));
	}

	void Logic ()
	{
		if (seen == true) 
		{
			seenBar.fillAmount = Mathf.Lerp (seenBar.fillAmount, increase / 10f, Time.deltaTime);
			switching = false;
		} 

		else 
		{
			switching = true;	
		}
			

		if (seenBar.fillAmount >= 0.9) 
		{
			alert = true;
		}

		if (alert == true) 
		{
			transform.position = Vector2.MoveTowards (transform.position, leader.position, speed * Time.deltaTime);
			alertMark.SetActive (true);
			switching = false;

		}
	}

	void Search ()
	{
		if (switching == true) 
		{
			turn = !turn;

			if (turn == true) 
			{
				transform.eulerAngles = new Vector2 (0, 0);
			} 

			else 
			{
				transform.eulerAngles = new Vector2 (0, 180);
			}
		}
	}
}
