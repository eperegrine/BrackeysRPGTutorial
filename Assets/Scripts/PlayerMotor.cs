using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

    Transform target;
    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 target, float stoppingDistance = 0f)
    {
        agent.stoppingDistance = stoppingDistance;
        agent.SetDestination(target);
    }

    public void FollowTarget(Transform newTarget, float stoppingDistance = 1f)
    {
        agent.updateRotation = false;
        agent.stoppingDistance = stoppingDistance;
        target = newTarget;
    }

    public void StopFollowingTarget()
    {
        target = null;
        agent.updateRotation = true;
    }

    void FaceTarget ()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRoation = Quaternion.LookRotation(new Vector3(dir.x, 0f, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRoation, Time.deltaTime * 5f);
    }
}
