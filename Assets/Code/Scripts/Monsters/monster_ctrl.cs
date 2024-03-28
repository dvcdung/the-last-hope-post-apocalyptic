using UnityEngine;
using System.Collections;

public class monster_ctrl : MonoBehaviour
{


	private Animator anim;
	private CharacterController controller;
	Rigidbody rb;
	private int battle_state = 0;
	public float speed = 6.0f;
	public float runSpeed = 6.0f;
	public float turnSpeed = 60.0f;
	public float gravity = 20.0f;
	public float moveRadius = 30f;
	private int HP = 100;
	private int ATK = 20;
	private int ARMOR = 200; // MAX = 1000, MIN = 0, assume that armor = 500 -> dmg reduce 50%
	private Vector3 moveDirection = Vector3.zero;
	private float w_sp = 0.0f;
	private float r_sp = 0.0f;
	public string PLAYER_NAME = "FirstPersonController";
	private GameObject player = null;
	private bool mercy = true;
	private bool howling = false;
	private bool attacked = false;
	private bool moving = false; // using for random movement
	private bool die = false;


	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
		player = GameObject.Find(PLAYER_NAME);
		rb = GetComponent<Rigidbody>();
		w_sp = 2f; //read walk speed
		r_sp = 6f; //read run speed
		battle_state = 0;
		runSpeed = w_sp;
	}

	void move()
	{
		gameObject.transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
	}

	void isDamaged(int income_dmg)
	{
		HP -= income_dmg * (int)(ARMOR / 1000);
	}

	int getDamage()
	{
		return ATK;
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log("mercy: " + mercy + ",howling: " + howling + ",attacked: " + attacked);
		Debug.Log("battle: " + anim.GetInteger("battle") + ", moving: " + anim.GetInteger("moving"));
		Vector3 monster_vec = gameObject.transform.position;
		Vector3 player_vec = player.transform.position;
		float distance = Vector3.Distance(monster_vec, player_vec);
		Vector3 direction = (player.transform.position - gameObject.transform.position).normalized;
		// Debug.Log("distance: " + distance);

		if (HP <= 0)
		{
			die = true;
			StartCoroutine(Die());
		}

		if (!die)
		{
			if (distance < 30f && mercy)
			{
				mercy = false;
				StartCoroutine(Howl());
			}

			else if (distance <= 3f && !mercy && howling && !attacked)
			{
				attacked = true;
				gameObject.transform.LookAt(player.transform);
				StartCoroutine(Attack());
				attacked = false;
			}
			else if (!mercy && howling && !attacked)
			{
				gameObject.transform.LookAt(player.transform);
				anim.SetInteger("moving", 1);
				move();
			}

			else if (distance > 50f && !mercy)
			{
				mercy = true;
				howling = false;
				anim.SetInteger("battle", 0);
				anim.SetInteger("moving", 0);
				battle_state = 0;
				runSpeed = w_sp;
			}

			else if (mercy && !moving)
			{
				int randomNum = Random.Range(1, 5001);

				if (randomNum < 2)
				{
					// Move
					moving = true;
					StartCoroutine(RandomMovement());
				}
				else
				{
					// Idle
					anim.SetInteger("moving", 0);
				}
			}
		}

	}

	IEnumerator Howl()
	{
		anim.SetInteger("battle", 1);
		anim.SetInteger("moving", 7);
		battle_state = 1;
		runSpeed = r_sp;
		yield return new WaitForSeconds(3f);
		howling = true;
		Debug.Log("Howled");
	}

	IEnumerator Attack()
	{
		int rand = Random.Range(22, 25);
		anim.SetInteger("moving", rand);
		yield return new WaitForSeconds(1f);
		attacked = false;
		Debug.Log("Attacked");
	}

	IEnumerator RandomMovement()
	{
		float t = 0;
		Vector3 monster_vec = gameObject.transform.position;
		Vector3 player_vec = player.transform.position;
		float distance = Vector3.Distance(monster_vec, player_vec);

		anim.SetInteger("moving", 1);

		Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

		float moveDuration = 5f;
		t = 0;
		while (t < moveDuration && distance > 30f)
		{
			t += Time.deltaTime;
			gameObject.transform.rotation = Quaternion.LookRotation(rotation * Vector3.forward);
			move();
			yield return null;
		}

		if (distance < 30f)
		{
			anim.SetInteger("moving", 0);
		}

		moving = false;
	}

	IEnumerator Die()
	{

		anim.SetInteger("moving", 100);
		yield return new WaitForSeconds(5f);
		Destroy(gameObject);
	}
}