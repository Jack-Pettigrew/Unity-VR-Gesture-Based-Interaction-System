using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcNav : MonoBehaviour
{
    private Animator ani;
    private NavMeshAgent nma;
    public Transform[] npcWalkPoints;
    public const float TIMER_CONST = 5.0f;
    public float pointTimer;

    private Transform nextPoint;


    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();

        pointTimer = TIMER_CONST;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position == nma.pathEndPosition)
        {
            pointTimer -= Time.deltaTime;

            if(pointTimer <= 0)
            {
                pointTimer = TIMER_CONST;
                NextPoint();
            }
        }
    }

    void NextPoint()
    {
        nextPoint = npcWalkPoints[Random.Range(0, npcWalkPoints.Length)];

        nma.SetDestination(nextPoint.position);
    }
}
