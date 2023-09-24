
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class NecromancerMoveState : BaseState
{
    bool finishWaiting;
    float waitDuration;
    float waitCounter;
    float waitDistance;
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        finishWaiting = false;
        waitDuration = 1.5f;
        waitCounter = waitDuration;
        waitDistance = 3f;
    }
    public override void LogicUpdate()
    {
        if (currentEnemy.DetectTarget())
        {
            if (finishWaiting)
            {
                Debug.Log("into next state");
                currentEnemy.SwitchState(ChooseARandomState());
            }
            Move();
        }
    }

    private void Move()
    {
        int faceDir = (int)currentEnemy.transform.localScale.x;
        if (Vector3.Distance(currentEnemy.transform.position, currentEnemy.target.position) > waitDistance)
        {
            currentEnemy.rb.velocity = (currentEnemy.target.position - currentEnemy.transform.position * currentEnemy.spd).normalized;
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
        int ran = Random.Range(1, 3);
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

    }

    public override void OnExit()
    {
        Debug.Log("exit");
    }
}
