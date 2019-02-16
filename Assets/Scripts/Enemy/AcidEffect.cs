using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    //move right at speed - should probably get direction from spider
    //detect player and deal damge via Idamageable
    //destroy after time limit
    [SerializeField] bool usePhysics = true;
    [SerializeField] Vector2 force;
    [SerializeField] float speed = 3.0f;
    [SerializeField] float lifetime = 3.0f;

    private Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        if (usePhysics)
        {
            rigidbody.AddForce(force);
        }

        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!usePhysics)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }                
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Acid Hit:" + other.name);
        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            hit.Damage();
        }
        Destroy(gameObject);
    }


}
