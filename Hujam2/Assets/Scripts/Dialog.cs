using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI nameText;
    public GameObject continueButton;
    public GameObject dialogUI;
    public Image characterImage;

    [TextArea(3,10)]
    public string[] sentences;
    public string Name;
    public Sprite sprite;

    public float typeSpeed;
    private int index;

    private void Start()
    {
        TriggerDialog();
    }
    public void TriggerDialog()
    {
        characterImage.sprite = sprite;
        nameText.text = Name;
        text.text = "";
        dialogUI.SetActive(true);
        continueButton.SetActive(false);
        StartCoroutine(Type());
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
        continueButton.SetActive(true);
    }

    public void DisplayNewSentence()
    {
        if(index < sentences.Length -1)
        {
            index++;
            text.text = "";
            continueButton.SetActive(false);
            StartCoroutine(Type());
        }
        else
        {
            text.text = "";
            dialogUI.SetActive(false);
        }
    }
}
