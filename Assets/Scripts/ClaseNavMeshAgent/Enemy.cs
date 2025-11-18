using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform TargetObject;
    private Queue<Vector3> waypoints = new Queue<Vector3>();
    [SerializeField] private bool finishNavegation = false; //>> esta bug, no true?

    //*updateRotation (True = Rotacion manual, Falso = Rotacion automatica)
    //*updatePosition (True = Movimiento Automatico, Falso = Movimiento Manual)
    //*isStopped (True = Detene el movimiento, Falso = segui el camino)
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = true;
        agent.isStopped = true;
    }

    //*haspath (True = Camino calculado, Falso = no tiene camino)
    //*pathPending (True = Tiene un camino, Falso = no tiene camino)
    //*CalculatePath ( para verificar el camino sin mover la entidad )
    //*path.corners (matriz de curvas)
    //*destination ( usalo como lectura )
    void Update() {
        if (!agent.hasPath && !agent.pathPending) {
            NavMeshPath path = new NavMeshPath();
            if (agent.CalculatePath(TargetObject.position, path)) {
                if(waypoints.Count <= 0) {
                    foreach (Vector3 point in path.corners) {
                        waypoints.Enqueue(point);
                    }
                }
                for (int i = 0; i < path.corners.Length - 1; i++) {
                    Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.blue);
                }
                agent.SetDestination(TargetObject.position);
            }
            
        }

        if (agent.hasPath && !agent.pathPending) {
            if (waypoints.Count > 0) {
                Vector3 nextTarget = waypoints.Peek();

                Vector3 dir = (nextTarget - transform.position).normalized;
                dir.y = 0f; // elimina inclinación vertical
                dir = dir.normalized;

                float angle = Vector3.Angle(transform.forward, dir);

                if (angle < 5f) {
                    waypoints.Dequeue();
                    agent.isStopped = false;
                    //agent.updatePosition = true;
                } else {
                    agent.isStopped = true;
                    //agent.updatePosition = false; // Pausa movimiento automático
                    Quaternion lookRot = Quaternion.LookRotation(dir);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5f);
                }

            }
        }
        float distance = Vector3.Distance(transform.position, TargetObject.position);
        finishNavegation = distance <= agent.stoppingDistance && !agent.pathPending && agent.velocity.sqrMagnitude <= 0.01f;

    }
    //*stoppingDistance = distancia de frenado
}
