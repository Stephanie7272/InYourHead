using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyPad: MonoBehaviour
{
    // Start is called before the first frame update
    private bool atDoor = false;
    private bool exit = false;
    private bool deadUI = false;
    private bool rightAnswer = false;
    private Animator anim;
    [SerializeField] private TextMeshProUGUI CodeText;
    string CodeTextValue = "";
    public string safeCode;
    public GameObject codePanel;
    private AudioSource audioSource;
    public GameObject PickUpText;
    public AudioClip creek;
    public AudioClip beep;
    public AudioClip wrong;
    public AudioClip right;
    public Color startColor = Color.red;

    public Color endColor = Color.black;
    public float speed = 1;

    public Image imgComp;

    void Start()
    {
        anim = GetComponent<Animator>();
        codePanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        PickUpText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        CodeText.text = CodeTextValue;

        if(CodeTextValue == safeCode)
        {
            PickUpText.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            atDoor = false;
            GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
            CodeTextValue = "";
            deadUI = true;
            imgComp.GetComponent<Image>().color = Color.green;
            rightAnswer = true;
        }

        if(Input.GetKey(KeyCode.T) && rightAnswer == true)
        {
            anim.SetTrigger("OpenDoor");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
            codePanel.SetActive(false);
            PickUpText.SetActive(false);
        }
         
        if(CodeTextValue.Length >= 4)
        {
            CodeTextValue = "";
            imgComp.GetComponent<Image>().color = Color.red;
        }

        if(Input.GetKey(KeyCode.E) && atDoor == true)
        {
            codePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            PickUpText.SetActive(false);
            GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
            exit = true;
        }

        if(Input.GetKey(KeyCode.T) && exit == true)
        {
            GameObject.FindWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
            codePanel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            //test
            CodeTextValue = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            atDoor = true;
        }
       
        PickUpText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        atDoor = false;
        codePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if(deadUI == true)
        {
            Destroy(this);
            codePanel.SetActive(false);
            PickUpText.SetActive(false);
        }
    }
    public void AddDigit(string digit)
    {
        CodeTextValue += digit;
    }

    public void PlaySoundDoor()
    {
        audioSource.PlayOneShot(creek);
    }

    public void PlaySoundButton()
    {
        if(CodeTextValue.Length <= 3)
        {
            audioSource.PlayOneShot(beep);
        }

        if(CodeTextValue.Length == 4)
        {
            if(CodeTextValue == safeCode)
            {
                audioSource.PlayOneShot(right);
            }

            else
            {
                audioSource.PlayOneShot(wrong);
            }
        }
       
    }

    public void colorChange()
    {
        imgComp.GetComponent<Image>().color = Color.black;
    }
}
