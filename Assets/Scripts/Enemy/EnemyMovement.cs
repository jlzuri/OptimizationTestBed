using UnityEngine;
using System.Collections;
using UnityEngine.Profiling;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        // Profiler.BeginSample("My Sample");
        Debug.Log("Updating Enemy movement");
        // Profiler.EndSample();
        
        nav.SetDestination (player.position);
    }
}
