using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class EventPanelManager : MonoBehaviour
{
    [SerializeField] DayManager dayManager;
    [SerializeField] TextMeshProUGUI labetText;
    [SerializeField] TextMeshProUGUI descText;
    [SerializeField] GameObject[] buttons;
    [SerializeField] TextMeshProUGUI[] butonDescText;
    [SerializeField] TextMeshProUGUI[] crewNegText;
    [SerializeField] TextMeshProUGUI[] crewPosText;
    [SerializeField] TextMeshProUGUI[] ItemText;

    private void OnEnable()
    {
        closeAllButtons();
        for (int i = 0; i < dayManager.finalEvent.EventOptions.Count; i++)
        {
            buttons[i].SetActive(true);
            labetText.text = dayManager.finalEvent.Label;
            descText.text = dayManager.finalEvent.Text;
            butonDescText[i].text = dayManager.finalEvent.EventOptions[i].OptionText;

            if (dayManager.finalEvent.EventOptions[i].NegativeEffectCrew == null)
                crewNegText[i].gameObject.SetActive(false);
            else
            {
                crewNegText[i].gameObject.SetActive(true);
                crewNegText[i].text = dayManager.finalEvent.EventOptions[i].NegativeEffectCrew.Name + "\n" +"-" + dayManager.finalEvent.EventOptions[i].MoodEffect;
            }

            if (dayManager.finalEvent.EventOptions[i].PositiveEffectCrew == null)
                crewPosText[i].gameObject.SetActive(false);
            else
            {
                crewPosText[i].gameObject.SetActive(true);
                crewPosText[i].text = dayManager.finalEvent.EventOptions[i].PositiveEffectCrew.Name + "\n" + "-" + dayManager.finalEvent.EventOptions[i].MoodEffect;
            }
            if (dayManager.finalEvent.EventOptions[i].GetItem != null)
                ItemText[i].text = "(+) " + dayManager.finalEvent.EventOptions[i].GetItem.ItemName;
            else if (dayManager.finalEvent.EventOptions[i].UseItem != null)
                ItemText[i].text = "(-) " + dayManager.finalEvent.EventOptions[i].UseItem.ItemName;
            else
                ItemText[i].text = "";

            if(dayManager.finalEvent.EventOptions[i].StatEffect != 0)
                ItemText[i].text = dayManager.finalEvent.EffectedStat.StatName +"\n" + dayManager.finalEvent.EventOptions[i].StatEffect;
        }
    }
    //todo statlarý türkçe olarak yazmak lazým

    public void ChooseOption()
    {
        dayManager.chosenOption = dayManager.finalEvent.EventOptions[System.Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name)];
    }
    private void closeAllButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }

}
