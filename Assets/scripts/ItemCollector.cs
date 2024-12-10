using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public GameObject collectionPanel;  // Панель для отображения сообщения
    private int itemCount = 0; // Количество собранных предметов
    public Text ark;
    public AudioSource keysSound;
    
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, является ли объект предметом
        if (other.CompareTag("Collectible"))
        {
            // Увеличиваем счетчик собранных предметов
            itemCount++;
            keysSound.Play();
            UpdateItemCountText();

            // Удаляем предмет из игры
            Destroy(other.gameObject);

            // Если собрали 10 предметов, показываем панель
            if (itemCount == 10)
            {
                collectionPanel.SetActive(true); // Показываем панель уведомления
                Cursor.lockState = CursorLockMode.None; // Активировать курсор
                Cursor.visible = true; // Показывать курсор
                Time.timeScale = 0;

            }
        }
    }

    public void FixedUpdate()
    {
        if (itemCount == 10)
        {
            collectionPanel.SetActive(true); // Показываем панель уведомления
            Cursor.lockState = CursorLockMode.None; // Активировать курсор
            Cursor.visible = true; // Показывать курсор
            Time.timeScale = 0;
        }
    }
    private void UpdateItemCountText()
    {
        ark.text = "Собрано предметов: " + itemCount +"/10" ; // Обновляем текст с количеством собранных предметов
    }

   //private void ShowCollectionPanel()
    //{
     // collectionPanel.SetActive(true); // Показываем панель уведомления
     // Time.timeScale = 0; // Останавливаем игру (по желанию)
     // Cursor.lockState = CursorLockMode.None; // Активировать курсор
//Cursor.visible = true; // Показывать курсор
      
    //}
}