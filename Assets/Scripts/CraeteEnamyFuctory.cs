using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CraeteEnamyFuctory : MonoBehaviour
{
	public Transform[] points;
	public float time = 10f;
	public GameObject fuctory;

	private void Start()
	{
		StartCoroutine(CreateFuctory());
	}

	IEnumerator CreateFuctory()
	{
		for (int i = 0; i < points.Length; i++) 
		{
			yield return new WaitForSeconds(time);
			GameObject spawn = Instantiate(fuctory);
			Destroy(spawn.GetComponent<PlaceObjects>());
			spawn.transform.position = points[i].transform.position;
			spawn.transform.rotation = Quaternion.identity;
			spawn.GetComponent<GenerateUnit>().enabled = true;
			spawn.GetComponent<GenerateUnit>().IsEnemy = true;
		}
	}
}
