using UnityEngine;
using System.Collections;

public class RocketContoller : MonoBehaviour {

	public float rocketForce = 75.0f;
	public float forwardMovementSpeed = 3.0f;
	 
	private bool dead = false;
	private uint coins = 0;
	
	public Texture2D coinIconTexture;
	
	public AudioClip coinCollectSound;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () 

	{
		bool rocketActive = Input.GetButton("Fire1");
		rocketActive = rocketActive && !dead;
		if (rocketActive)
		{
			rigidbody2D.AddForce(new Vector2(0, rocketForce));
		}
		
		if (!dead)
		{
			Vector2 newVelocity = rigidbody2D.velocity;
			newVelocity.x = forwardMovementSpeed;
			rigidbody2D.velocity = newVelocity;
		}
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Coins"))
			CollectCoin(collider);
		else
			HitByLaser(collider);
	}
	
	void HitByLaser(Collider2D laserCollider)
	{
		if (!dead)
			laserCollider.gameObject.audio.Play();
		
		dead = true;
		

	}
	
	void CollectCoin(Collider2D coinCollider)
	{
		coins++;
		
		Destroy(coinCollider.gameObject);
		
		AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
	}
	
	void OnGUI()
	{
		DisplayCoinsCount();
		
		DisplayRestartButton();
	}
	
	void DisplayCoinsCount()
	{
		Rect coinIconRect = new Rect(10, 10, 32, 32);
		GUI.DrawTexture(coinIconRect, coinIconTexture);                         
		
		GUIStyle style = new GUIStyle();
		style.fontSize = 30;
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.yellow;
		
		Rect labelRect = new Rect(coinIconRect.xMax, coinIconRect.y, 60, 32);
		GUI.Label(labelRect, coins.ToString(), style);
	}
	
	void DisplayRestartButton()
	{
		if (dead)
		{
			Rect buttonRect = new Rect(Screen.width * 0.35f, Screen.height * 0.45f, Screen.width * 0.30f, Screen.height * 0.1f);
			if (GUI.Button(buttonRect, "Tap to restart!"))
			{
				Application.LoadLevel (Application.loadedLevelName);
			}
			Rect buttonRect1 = new Rect(Screen.width * 0.35f, Screen.height * 0.57f, Screen.width * 0.30f, Screen.height * 0.1f);
			if (GUI.Button(buttonRect1, "Quit?"))
			{
				Application.Quit();
			}


		}
	}
}