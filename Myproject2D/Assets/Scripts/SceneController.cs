using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void TestButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void RebackButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
    public void Shop()
    {
        SceneManager.LoadScene(2);
    }
    public void ShopToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void SettingOpen()
    {
        SceneManager.LoadScene(3);
    }
    public void SettingClose()
    {
        SceneManager.LoadScene(0);
       
    }
    }
