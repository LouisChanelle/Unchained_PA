using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        objectPooling.SharedInstance.amountToPool = objectPooling.SharedInstance.amountToPool + 10;
        GameObject.FindGameObjectWithTag("Player").GetComponent<damage>().hp = 100;
    }
}
