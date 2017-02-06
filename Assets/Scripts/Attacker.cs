using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {
    [Tooltip ("Average number of seconds between appearances.")]
    public float seenEverySeconds;

//    [Range (-1f, 1.5f)]
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget || currentTarget == null)
        {
            anim.SetBool("isAttacking", false);
        }

        //print(Button.selectedDefender);
    }

    void OnTriggerEnter2D ()
    {
//        Debug.Log(name + " trigger enter");
    }

    public void setSpeed (float speed)
    {
        currentSpeed = speed;
    }

    // Called form Animator at time of actual blow.
    public void StrikeCurrentOpponent (float damage)
    {
        //currentTarget.GetComponent<Health>().DealDamage();
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }

        // Debug.Log(name + " caused damage: " + damage);
    }

    public void Attack (GameObject obj)
    {
        currentTarget = obj;
        
    }
}
