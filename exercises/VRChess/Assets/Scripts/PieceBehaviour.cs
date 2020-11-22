using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PieceBehaviour : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public Piece enemy;

    const int MAX_HEALTH = 100;
    const float AttackRange = 2.5f;
    public int health = MAX_HEALTH;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemy && agent.velocity.magnitude > 0.1f)
        {
            //anim.SetTrigger("Attack");
            anim.SetTrigger("Walk");
        }
        if (!enemy && agent.velocity.magnitude < 0.1f)
        {
            anim.SetTrigger("Idle");
        }
        if (enemy)
        {
            //Debug.Log(Vector3.Distance(GetComponent<Piece>().transform.position, enemy.transform.position));
            if (!InAttackRange(GetComponent<Piece>(), enemy))
            {
                anim.SetTrigger("Walk");
            }
            else
            {
                anim.SetTrigger("Attack");
                enemy.GetComponent<PieceBehaviour>().UnderAttack();

                //Wrong, need fix
                if (enemy.GetComponent<PieceBehaviour>().health <= 0)
                {
                    anim.SetTrigger("Idle");
                }
            }
        }
    }

    private bool InAttackRange(Piece p1, Piece p2)
    {
        if (Vector3.Distance(p1.transform.position, p2.transform.position) < AttackRange)
        {
            return true;
        }
        return false;
    }

    public void UnderAttack()
    {
        if (health > 0)
        {
            health--;
        }
        if (health <= 0)
        {
            anim.SetTrigger("Die");
            BoardManager._instance.EliminatePiece(this.GetComponent<Piece>());
        }
    }
}
