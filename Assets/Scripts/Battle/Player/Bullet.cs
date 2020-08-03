using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
	public GameObject impactEffect;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;
	}
	
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		if (hitInfo.name == "Boss" || hitInfo.name == "Ground")
		{
			BossHealth enemy = hitInfo.gameObject.GetComponent<BossHealth>();
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
			}

			GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation);

			Destroy(gameObject);   // destroy the fireball
			Destroy(impact, .5f);  // destroy the explosion after .5 seconds
		}
	}
}
