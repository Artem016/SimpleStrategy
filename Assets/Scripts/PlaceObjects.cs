using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjects : MonoBehaviour
{
	public LayerMask layer;
	public float rotateSpeed = 60.0f;
	private float _maxDistance = 1000.0f;

	private void Start()
	{
		PositionObject();
	}

	private void Update()
	{
		PositionObject();

		if (Input.GetMouseButtonDown(0))
		{
			Destroy(gameObject.GetComponent<PlaceObjects>());
			gameObject.GetComponent<GenerateUnit>().enabled = true;
		}


		if (Input.GetKey(KeyCode.LeftShift))
			transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
	}

	private void PositionObject()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, _maxDistance, layer))
			transform.position = hit.point;
	}
}
