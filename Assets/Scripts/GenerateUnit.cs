using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateUnit : MonoBehaviour
{
	[NonSerialized] public bool IsEnemy = false;
	public GameObject unit;
	public float time = 5f;

	private void Start()
	{
		StartCoroutine(SpawnUnit());
	}

	IEnumerator SpawnUnit()
	{
		for (int i = 1; i <= 3; i++) 
		{ 
			yield return new WaitForSeconds(time);
			var pos = new Vector3(
				transform.GetChild(0).position.x + UnityEngine.Random.Range(5f, 10f),
				transform.GetChild(0).position.y,
				transform.GetChild(0).position.z + UnityEngine.Random.Range(5f, 10f)
				);
			GameObject spawn = Instantiate(unit, pos, Quaternion.identity);
			if (IsEnemy)
				spawn.tag = "Enemy";
			
		}
	}
}
