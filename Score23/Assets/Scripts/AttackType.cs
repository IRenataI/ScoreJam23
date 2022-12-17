using UnityEngine;

abstract public class AttackType : MonoBehaviour
{
    [Range(0, 100)] public float Damage; // ���� ��������� ������ �������
    abstract public Unit Attack(); 
}