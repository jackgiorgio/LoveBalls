using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Tooltip("Average number of seconds between appearance")]
    public float seenEverySeconds;


    [Range(-1f, 1.5f)]
    public float currentSpeed;
    private GameObject currentTarget;

    private Animator anim;
    
    // Use this for initialization
	void Start () {
        Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody.isKinematic = true;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (!obj.GetComponent<Defender>())
        {
            return;
        }
        else
        {
            anim.SetBool("IsAttacking", true);
            SetSpeed(0);
            Attack(obj);
        }
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
        else
        {
            anim.SetBool("IsAttacking", false);
            SetSpeed(0.4f);
        }
        
        
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
        StrikeCurrentTarget(2);

    }
}
