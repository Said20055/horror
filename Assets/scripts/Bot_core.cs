using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot_core : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;
    public GameObject panel;

    private void Awake()
    {
        // ����������� ��������� ��������� NavMeshAgent ���������� agent.
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // ���������, ��� agent �� ����� null, ������ ��� ������������ ���.
        if (agent != null)
        {
            agent.destination = player.transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None; // ������������ ������
            Cursor.visible = true; // ���������� ������
            Time.timeScale = 0; // ������������� ����
        }
    }
}