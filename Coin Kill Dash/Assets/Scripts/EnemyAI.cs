using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    //NavMeshAgent agent;
    public Transform target;
    public float damage = 5f;
    public float speed = 5f;
    // Start is called before the first frame update

    

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
    void Awake()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        //agent = GetComponent<NavMeshAgent>();    
        GetComponent<AIDestinationSetter>().target = target;
    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(target.position);   
        //GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            
            collision.collider.attachedRigidbody.AddForce(-(transform.position - target.position).normalized * 10000, ForceMode.VelocityChange);
            collision.collider.GetComponent<Health>().TakeDamage(damage);
        }
        if(collision.collider.CompareTag("TaserBullet"))
        {
            GetComponent<Health>().TakeDamage(1f);
        }
         else if(collision.collider.CompareTag("PistolBullet"))
        {
            GetComponent<Health>().TakeDamage(5f);
        }
    }
}
