using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIWalk : AIBehaviour {

    public float normalSpeed = 0, fastSpeed = 2, maxSpeedupTime = 4, minDistance = 2;
    protected NavMeshAgent agent;
    private Coroutine speedupRoutine;

    // Use this for initialization
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = normalSpeed;
    }

    void Update()
    {
        Vector3 playerPos = Vector3.zero;
        if (Vector3.Distance(transform.position, playerPos) < minDistance)
        {
            if (speedupRoutine != null)
            {
                StopCoroutine(speedupRoutine);
                agent.speed = fastSpeed;
                Vector3 pos = playerPos;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(playerPos, out hit, 5, NavMesh.AllAreas))
                {
                    pos = hit.position;
                }
                agent.SetDestination(pos);
            }
        }
        else
        {
            if (speedupRoutine == null)
            {
                agent.speed = normalSpeed;
            }
        }
    }

    public override void ReceivePlayerSound(Vector3 position, float factor)
    {
        Vector3 pos = position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, 5, NavMesh.AllAreas))
        {
            pos = hit.position;
        }
        agent.SetDestination(pos);
        if (speedupRoutine != null) { StopCoroutine(speedupRoutine); }
        speedupRoutine = StartCoroutine(speedup((maxDistance - Vector3.Distance(transform.position, position)) / maxDistance));
    }

    IEnumerator speedup(float factor)
    {
        float time = factor * maxSpeedupTime;
        float speed = fastSpeed * factor;
        agent.speed = speed;
        yield return new WaitForSeconds(time * 0.5f);
        for (float i = time * 0.5f; i >= 0; i -= 0.02f)
        {
            agent.speed = normalSpeed + (speed - normalSpeed) * (i / time);
            yield return new WaitForSeconds(0.02f);
        }
        agent.speed = normalSpeed;
    }
}
