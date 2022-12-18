using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SoundList))]
public class Unit : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float HitPoints;
    [SerializeField] private AttackType Attack; // ��� ���� ������ ����������. 1) ����������� ������� ��������� ������ � ��, ��������/�������. 
    //2) ������������� �����������: ����������-��������, ����������-��������. ��� ���� �� ���� ����������� � �����, ������ �������� ���� � �� �� �����
    // ��� �� ���� �������� "����������� �����" �.�. ����-���������� ��� ��-����������
    private SoundList Audio;
    
    private void Awake()
    {
        Audio = GetComponent<SoundList>();
        gameObject.TryGetComponent<AttackType>(out Attack);
    }


    private void Death()
    {
        Audio.Death();
        Destroy(gameObject);
    }
    public void ApplyDMG(AttackType What)
    {
        HitPoints -= What.Damage;
        if (HitPoints <= 0) Death();
        else if (What.Damage > 0) Audio.TakeDamage();
    }
    private void GiveDMG(Unit Target)
    {
        if (Target == null) return;
        Target.ApplyDMG(Attack);
    }

    // �������, ��-��������, ������ ���������� ���������� ���, �� ��
    public void Command_Attack()
    {
        Audio.Attack();
        GiveDMG(Attack.ReturnTarget());
    }
}
