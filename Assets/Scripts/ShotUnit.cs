using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotUnit : MonoBehaviour
{
	[NonSerialized] public Vector3 position;
	public float speed = 30f;
	public int damage = 20;

	private void Update()
	{
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, position, step);

		if (transform.position == position)
			Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy") || other.CompareTag("Player"))
		{
			UnitAttack attack = other.GetComponent<UnitAttack>();
			attack.health -= damage;

			Transform healthBar = other.transform.GetChild(0).transform;
			healthBar.localScale = new Vector3 (
				transform.lossyScale.x - 0.3f,
				transform.lossyScale.y,
				transform.lossyScale.z);

			if(attack.health <= 0)
				Destroy(other.gameObject);
		}
	}
}
