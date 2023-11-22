
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class NecromancerMoveState : BaseState
{
    bool finishWaiting;
    float waitCounter;
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        currentEnemy.minionStats.CurrentSpd=currentEnemy.minionStats.NormalSpd;
        finishWaiting = false;
        waitCounter = currentEnemy.minionStats.WaitDuration;
    }
    public override void LogicUpdate()
    {
        currentEnemy.anim.SetFloat("velocity", Mathf.Abs(currentEnemy.rb.velocity.x) + Mathf.Abs(currentEnemy.rb.velocity.y));
    }

    private void Move()
    {
        int faceDir = (int)currentEnemy.transform.localScale.x;
        Vector3 moveDir = currentEnemy.target.position - currentEnemy.transform.position;
        if (Vector3.Distance(currentEnemy.transform.position, currentEnemy.target.position) > currentEnemy.minionStats.WaitDistance)
        {
            currentEnemy.rb.velocity = moveDir.normalized * currentEnemy.minionStats.CurrentSpd;
        }
        else
        {
            Wait();
            currentEnemy.rb.velocity = Vector3.zero;
        }
        if (currentEnemy.target.position.x - currentEnemy.transform.position.x > 0)
        {
            faceDir = 1;
        }
        if (currentEnemy.target.position.x - currentEnemy.transform.position.x < 0)
        {
            faceDir = -1;
        }
        currentEnemy.transform.localScale = new Vector3(faceDir, 1, 1);
    }


    private EnemyState ChooseARandomState()
    {
        int ran = Random.Range(1, 4);
        switch (ran)
        {
            case 1:
                return EnemyState.Skill_1;
            case 2:
                return EnemyState.Skill_2;
            case 3:
                return EnemyState.Skill_3;
            default:
                return EnemyState.Skill_3;
        }
    }

    private void Wait()
    {
        waitCounter -= Time.deltaTime;
        if (waitCounter <= 0)
        {
            finishWaiting = true;
        }
    }

    public override void PhysicsUpdate()
    {
        if (currentEnemy.DetectTarget())
        {
            if (finishWaiting)
            {
                currentEnemy.SwitchState(ChooseARandomState());
            }
            Move();
        }
    }

    public override void OnExit()
    {

    }
}
