using UnityEngine;
using System.Collections;


public class MovementScript1 : MonoBehaviour {

	public float moveSpeed;
	public float joyMoveSpeed;
	public float dizzyMoveSpeed;
	public float g;
	public float jumpSpeed;
	public float knockbackIntensity;
	public GameObject spookyTree;
	public GameObject atmosphericEffects;
	public GameObject steadyLight;

	private Transform mainCameraTransfrom;
	private Vector3 verticalMoveVector;
	private Vector3 horizontalMoveVector;
	private Vector3 moveVector;
	private CharacterController con;
	private Animator animator;
	private float vSpeed=0;
	private bool isDizzy=false;
	private Vector3 knockBack=Vector3.zero;
	private Vector3 distToSpooky;
	private bool atmos=true;
	public bool win=false;
	// Use this for initialization
	void Start () {
		mainCameraTransfrom = Camera.main.transform;
		con = gameObject.GetComponent<CharacterController> ();
		animator = transform.FindChild("characterModel").GetComponent<Animator> ();
		gameObject.GetComponent<SlowMotion> ().enabled = false;
		Time.timeScale = 0.0f;
		GameObject.Find("gameEndText").guiText.text="Instructions: Hold Right Click to slow down Time, WASD+Mouse Look, Space to Dodge, Press P to play";

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.P))
		{
			Time.timeScale=1.0f;
			gameObject.GetComponent<SlowMotion> ().enabled = true;
			GameObject.Find("gameEndText").guiText.text="";
		}
		verticalMoveVector = new Vector3 (mainCameraTransfrom.forward.x,0 , mainCameraTransfrom.forward.z).normalized*Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
		horizontalMoveVector = new Vector3 (mainCameraTransfrom.right.x,0 , mainCameraTransfrom.right.z).normalized*Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
				if (!win) {
						if(Time.timeScale<1.0)
							horizontalMoveVector*=5;
						moveVector = verticalMoveVector + horizontalMoveVector;
						
				}
				else
						moveVector = Vector3.zero;
		if (!con.isGrounded) 
		{
			vSpeed -= g*Time.deltaTime;
		} 
		else 
		{
			vSpeed=-0.1f;
		}

		transform.forward = new Vector3 (mainCameraTransfrom.forward.x,0 , mainCameraTransfrom.forward.z).normalized;
		//Debug.Log (moveVector.magnitude);
		if(Input.GetAxis("Vertical")!=0 || Input.GetAxis("Horizontal")!=0)
		{
			animator.SetBool("isMoving", true);
		}
		else
		{
			animator.SetBool("isMoving", false);
		}
		if(Input.GetButtonDown("Jump") && Time.timeScale<1.0)
		{
			animator.SetBool("jumped",true);
		}
		con.Move (moveVector);



	}
	void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "laser") 
		{
			win=true;
			Destroy(hit.gameObject);
			GameObject.Find("Guns").SetActive(false);
			GameObject.Find("gameEndText").guiText.text="Congratulations! You Won!";
		}
	}


}
