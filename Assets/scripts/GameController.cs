using UnityEngine;
using YG;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public bool isDesktop;

    [SerializeField] private GameObject mobileController;
    public static GameController instance;

    void Awake()
    {
        instance = this;
        isDesktop = YandexGame.EnvironmentData.isDesktop;
        if (!isDesktop) mobileController.SetActive(true);
        else mobileController.SetActive(false);
        
            
        
    }


}
