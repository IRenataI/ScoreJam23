using UnityEngine;
[RequireComponent(typeof(SoundList))]
public class Unit : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float HitPoints;
    [SerializeField] private AttackType Attack; // ��� ���� ������ ����������. 1) ����������� ������� ��������� ������ � ��, ��������/�������. 
    //2) ������������� �����������: ����������-��������, ����������-��������. ��� ���� �� ���� ����������� � �����, ������ �������� ���� � �� �� �����
    // ��� �� ���� �������� "����������� �����" �.�. ����-���������� ��� ��-����������
    private SoundList Audio;

    private bool _isPlayer;
    private Animator _animator;

    private bool _isDead;
    
    private void Awake()
    {
        Audio = GetComponent<SoundList>();
        gameObject.TryGetComponent<AttackType>(out Attack);
        if (CompareTag("Player"))
        {
            _isPlayer = CompareTag("Player");
            return;
        }
        _animator = GetComponent<Animator>();
    }


    private void Death()
    {
        Audio.Death();
        if(!_isPlayer) _animator.Play("Death");
        _isDead = true;
        if (!_isPlayer)
        {
            Destroy(gameObject, _animator.GetCurrentAnimatorClipInfo(0).Length-0.33f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ApplyDMG(AttackType What)
    {
        if(!_isPlayer) _animator.Play("TakeDamage");
        HitPoints -= What.Damage;
        if (HitPoints <= 0) Death();
        else if (What.Damage > 0) Audio.TakeDamage();
    }
    private void GiveDMG(Unit Target)
    {
        if(_isDead) return;
        if (Target == null) return;
        if(!_isPlayer) _animator.Play("Attack");
        Target.ApplyDMG(Attack);
    }

    public float ReturnHP()
    {
        return HitPoints;
    }

    // �������, ��-��������, ������ ���������� ���������� ���, �� ��
    public void Command_Attack()
    {
        Audio.Attack();
        Unit target = Attack.ReturnTarget();
        if (target == null) return;
        GiveDMG(target);
    }
}
