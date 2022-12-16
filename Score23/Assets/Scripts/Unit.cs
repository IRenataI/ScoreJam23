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
    [SerializeField] private SoundList Audio;
    
    private void Awake()
    {
        Audio = GetComponent<SoundList>();
    }


    private void Death()
    {
        Audio.Death();
    }
    public void ApplyDMG(AttackType What)
    {
        HitPoints -= What.Damage;
        if (HitPoints <= 0) Death();
        else Audio.TakeDamage();
    }
    private void GiveDMG(Unit Target)
    {
        Target.ApplyDMG(Attack);
    }

    // �������, ��-��������, ������ ���������� ���������� ���, �� ��
    public void Command_Attack()
    {
        Audio.Attack();
        GiveDMG(Attack.Attack());
    }
}
