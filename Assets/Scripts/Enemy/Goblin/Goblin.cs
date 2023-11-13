public class Goblin : Enemy
{
    protected override void Awake()
    {
        base.Awake();
        moveState = new GoblinMoveState();
        skill_1State = new GoblinAttackState();
    }
    public override void OnDie()
    {
        base.OnDie();
        anim.SetBool("dead", true);
    }
    public void VanishToDie()
    {
        gameObject.SetActive(false);
    }
    public void FinishAttack(){
        SwitchState(EnemyState.Move);
    }
}
