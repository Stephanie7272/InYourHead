using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }

        public void Upstairs()
    {
        SceneManager.LoadScene("CreditScreen");
    }

    public void Basement()
    {
        SceneManager.LoadScene("CreditScreen");
    }

      public void StartOver()
    {
        SceneManager.LoadScene("OutdoorsScene");
    }

}
