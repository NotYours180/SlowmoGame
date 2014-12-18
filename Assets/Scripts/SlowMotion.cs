using UnityEngine;
using System.Collections;

public class SlowMotion : MonoBehaviour {
	public float initialSlowTime;
	public float slowFactor;
	public float slowRecharge;
	public float slowDischarge;
	public float pillRecharge;
	public GUIText timeDisplay;

	private float currentSlowTime;
	private float originalFixedDeltaTime;
	// Use this for initialization
	void Start () {
		currentSlowTime = initialSlowTime;
		originalFixedDeltaTime = Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")) 
		{
			if(!gameObject.GetComponent<AudioSource>().isPlaying)
				gameObject.GetComponent<AudioSource>().Play();
		}
		if(Input.GetButton("Fire2"))
		{
			if(currentSlowTime>0)
			{
				Time.timeScale=slowFactor;
				currentSlowTime-=slowDischarge*Time.deltaTime;
			}
			else
			{
				Time.timeScale=1.0f;
			}
			Time.fixedDeltaTime=0.02f*Time.timeScale;
		}
		else
		{
			Time.timeScale=1.0f;
			/*if(Time.timeScale!=1.0)
			{
				Time.timeScale=1.0f;
			}*/
			Time.fixedDeltaTime=originalFixedDeltaTime;
		}
		if(Time.timeScale==1.0f)
		{
			currentSlowTime+=slowRecharge*Time.deltaTime;
		}
		currentSlowTime = Mathf.Clamp (currentSlowTime,-0.01f,10);
		timeDisplay.text = currentSlowTime+" ";
		/*if(Time.timeScale==slowFactor)
		{
			currentSlowTime-=Time.deltaTime;
		}
		if(currentSlowTime<0f)
		{
			currentSlowTime=slowTime;
			Time.timeScale=1.0f;
		}*/
	
	}
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.gameObject.tag == "pill")
		{
			currentSlowTime+=pillRecharge;
			Destroy(hit.gameObject);
		}
	}


}
