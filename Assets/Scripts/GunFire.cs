using UnityEngine;
using System.Collections;



public class GunFire : MonoBehaviour {
	public float minInterval;
	public float maxInterval;
	public GameObject bullet;
	public float bulletForce;
	public Transform lookTarget;
	
	private Transform bulletSpawn;
	public float timeCounter;
	// Use this for initialization
	void Start () {
		bulletSpawn = transform.FindChild ("bulletPoint").gameObject.transform;
		timeCounter = 3;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.FindChild ("bulletPoint").LookAt (lookTarget.position);
		if(timeCounter<0)
		{
			Debug.Log("Fire Bullet");
			fireBullet();
			timeCounter=Random.Range(minInterval,maxInterval);
		}
		else
		{
			timeCounter-=Time.deltaTime;
		}
	
	}

	void fireBullet()
	{
		GameObject firedBullet = Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
		firedBullet.rigidbody.AddForce (bulletSpawn.transform.forward * bulletForce);
		gameObject.GetComponent<AudioSource> ().Play ();
	}
}
