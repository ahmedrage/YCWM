using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class seenBar : MonoBehaviour {

	public enemy script;
	public Image SeenBar;
	public GameObject eye;
	public bool alert;
	public float increase = 0.1f;

	void Start () 
	{
		SeenBar = GetComponent <Image> ();
		script = GameObject.Find("enemy").GetComponent<enemy>();
		alert = false;
	}
	
	void Update () 
	{
		seen ();
	}

	void seen ()
	{
		if (script.seen) {
			eye.SetActive (true);
			SeenBar.fillAmount = Mathf.Lerp (SeenBar.fillAmount, increase / 10f, Time.deltaTime);
		} else {
			eye.SetActive (false);
		}

		if (SeenBar.fillAmount >= 0.9) 
		{
			eye.SetActive (true);
			alert = true;
		}
	}
}
