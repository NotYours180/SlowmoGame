using UnityEngine;
using System.Collections;

public class BulletTimeout : MonoBehaviour {
	public float timeOutTime;

	private float startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime > timeOutTime) 
		{
			Destroy(this.gameObject);
		}
	}
}
