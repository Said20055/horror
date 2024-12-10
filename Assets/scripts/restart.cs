using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class restart : MonoBehaviour
{
    public int scenenum;
    // Start is called before the first frame update
    public void Restart()
    {
        YandexGame.FullscreenShow();
        SceneManager.LoadScene(scenenum);
        Time.timeScale = 1;
    }
   
}
