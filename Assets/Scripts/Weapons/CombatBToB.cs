using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBToB : MonoBehaviour
{

    [SerializeField] private Transform hitController;
    [SerializeField] private float hitRadio;
    [SerializeField] private float hitDamage;
    [SerializeField] private float attackBetweenTime;
    [SerializeField] private float nextTimeAttack;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (nextTimeAttack > 0)
        {
            nextTimeAttack -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Hit();
            nextTimeAttack = attackBetweenTime;
        }
    }
    private void Hit()
    {
        animator.SetTrigger("Attack");

        Collider2D[] objects = Physics2D.OverlapCircleAll(hitController.position, hitRadio);

        foreach (Collider2D collider in objects)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.transform.GetComponent<EnemyMovement>().TakeDamage(hitDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(hitController.position, hitRadio);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals ("Enemy"))
        {
            SoundManager.PlaySound("playerHit");
            SoundManager.PlaySound("enemyDeath");
        }
    }
}
