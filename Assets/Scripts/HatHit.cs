using UnityEngine;
using System.Collections;

public class HatHit : MonoBehaviour {

	public GameObject character;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision hit)
	{
		if (hit.gameObject.tag == "bullet") 
		{
			character.GetComponent<MovementScript1>().win=true;
			GameObject.Find("gameEndText").guiText.text="Oh no! You lost yout hat of power!";
			character.transform.FindChild("characterModel").GetComponent<Animator>().SetBool("hitBullet",true);
		}
	}
}
