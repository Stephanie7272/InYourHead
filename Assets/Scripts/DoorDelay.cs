using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorDelay : MonoBehaviour
{
    [SerializeField] private Animator doorV3 = null;

    [SerializeField] private bool openTrigger = false;

    public AudioSource creak;
    public AudioSource rattle;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                StartCoroutine(Example());
            }
        }
    }

    IEnumerator Example()
    {
        while (true)
        {
            rattle.Play();
            yield return new WaitForSeconds(3);
            rattle.Stop();
            creak.Play();
            doorV3.Play("DoorOpenV3", 0, 0.0f);
            yield return new WaitForSeconds(1);
            gameObject.SetActive(false);
            SceneManager.LoadScene("WinScreen");
        }
    }
}
