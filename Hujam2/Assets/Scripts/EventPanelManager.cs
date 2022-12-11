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
        for (int i = 0; i < dayManager.chosenEvent.EventOptions.Count; i++)
        {
            buttons[i].SetActive(true);
            labetText.text = dayManager.chosenEvent.Label;
            descText.text = dayManager.chosenEvent.Text;
            butonDescText[i].text = dayManager.chosenEvent.EventOptions[i].OptionText;

            if (dayManager.chosenEvent.EventOptions[i].NegativeEffectCrew == null)
                crewNegText[i].gameObject.SetActive(false);
            else
            {
                crewNegText[i].gameObject.SetActive(true);
                crewNegText[i].text = dayManager.chosenEvent.EventOptions[i].NegativeEffectCrew.Name + "\n" +"-" + dayManager.chosenEvent.EventOptions[i].MoodEffect;
            }

            if (dayManager.chosenEvent.EventOptions[i].PositiveEffectCrew == null)
                crewPosText[i].gameObject.SetActive(false);
            else
            {
                crewPosText[i].gameObject.SetActive(true);
                crewPosText[i].text = dayManager.chosenEvent.EventOptions[i].PositiveEffectCrew.Name + "\n" + "-" + dayManager.chosenEvent.EventOptions[i].MoodEffect;
            }
            if (dayManager.chosenEvent.EventOptions[i].GetItem != null)
                ItemText[i].text = "(+) " + dayManager.chosenEvent.EventOptions[i].GetItem.ItemName;
            else if (dayManager.chosenEvent.EventOptions[i].UseItem != null)
                ItemText[i].text = "(-) " + dayManager.chosenEvent.EventOptions[i].UseItem.ItemName;
            else
                ItemText[i].text = "";
        }
    }

    public void ChooseOption()
    {
        dayManager.chosenOption = dayManager.chosenEvent.EventOptions[System.Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name)];
    }
    private void closeAllButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }
    
}
