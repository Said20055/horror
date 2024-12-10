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
        // Присваиваем найденный компонент NavMeshAgent переменной agent.
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Проверяем, что agent не равен null, прежде чем использовать его.
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
            Cursor.lockState = CursorLockMode.None; // Активировать курсор
            Cursor.visible = true; // Показывать курсор
            Time.timeScale = 0; // Останавливаем игру
        }
    }
}