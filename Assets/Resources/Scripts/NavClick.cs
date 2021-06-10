using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavClick : MonoBehaviour
{
	NavMeshAgent agent;
	RaycastHit hitInfo = new RaycastHit();
	public Transform hitInfoPoint;

	void Start()
	{

		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			agent.destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}
}
