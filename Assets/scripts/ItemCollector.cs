using UnityEngine;
using UnityEngine.UI;
using YG;

public class ItemCollector : MonoBehaviour
{
    public GameObject collectionPanel;  // ������ ��� ����������� ���������
    private int itemCount = 0; // ���������� ��������� ���������
    public Text ark;
    public AudioSource keysSound;
    
    private void OnTriggerEnter(Collider other)
    {
        // ���������, �������� �� ������ ���������
        if (other.CompareTag("Collectible"))
        {
            // ����������� ������� ��������� ���������
            itemCount++;
            keysSound.Play();
            UpdateItemCountText();

            // ������� ������� �� ����
            Destroy(other.gameObject);

            // ���� ������� 10 ���������, ���������� ������
            if (itemCount == 10)
            {
                collectionPanel.SetActive(true); // ���������� ������ �����������
                Cursor.lockState = CursorLockMode.None; // ������������ ������
                Cursor.visible = true; // ���������� ������
                Time.timeScale = 0;

            }
        }
    }

    public void FixedUpdate()
    {
        if (itemCount == 10)
        {
            collectionPanel.SetActive(true); // ���������� ������ �����������
            Cursor.lockState = CursorLockMode.None; // ������������ ������
            Cursor.visible = true; // ���������� ������
            Time.timeScale = 0;
        }
    }
    private void UpdateItemCountText()
    {
        if(YandexGame.EnvironmentData.language.Equals("ru"))
        ark.text = "������� ���������: " + itemCount +"/10" ; // ��������� ����� � ����������� ��������� ���������
        if (YandexGame.EnvironmentData.language.Equals("en"))
            ark.text = "Items collected: " + itemCount + "/10";
    }

   //private void ShowCollectionPanel()
    //{
     // collectionPanel.SetActive(true); // ���������� ������ �����������
     // Time.timeScale = 0; // ������������� ���� (�� �������)
     // Cursor.lockState = CursorLockMode.None; // ������������ ������
//Cursor.visible = true; // ���������� ������
      
    //}
}