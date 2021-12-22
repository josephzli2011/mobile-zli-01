using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    // Start is called before the first frame update

    

    public void Destroy()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        agent = GetComponent<NavMeshAgent>();    
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            
            collision.collider.attachedRigidbody.AddForce(-(transform.position - target.position).normalized * 10000, ForceMode.VelocityChange);
            collision.collider.GetComponent<Health>().TakeDamage(5f);
        }
        if(collision.collider.CompareTag("TaserBullet"))
        {
            GetComponent<Health>().TakeDamage(1f);
        }
    }
}
