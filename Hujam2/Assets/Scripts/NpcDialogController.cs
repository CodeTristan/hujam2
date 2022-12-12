using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogController : MonoBehaviour
{
    public GameObject Exc;
    [SerializeField] Crew crew;
    private DayManager dayManager;

    public int[] dialogDays;

    private int dialogAvaliableIndex = 1;
    private int dialogFinished = 1;
    private void Start()
    {
        dayManager = FindObjectOfType<DayManager>();
    }

    private void Update()
    {
        if(!Exc.activeSelf && dialogFinished < dialogAvaliableIndex)
        {
            Exc.SetActive(true);
        }
    }
    public void checkAvailableDialogs()
    {
        dialogAvaliableIndex = 1;
        for (int i = 0; i < dialogDays.Length; i++)
        {
            if (dayManager.dayCount >= dialogDays[i])
            {
                dialogAvaliableIndex++;
            }
        }
    }
    public void StartDialog()
    {
        if (dayManager.dayCount > crew.allCharDialogs.Length)
            crew.allCharDialogs[0].TriggerDialog();
        else
        {
            checkAvailableDialogs();
            if (dialogFinished < dialogAvaliableIndex)
            {
                crew.allCharDialogs[dialogFinished].TriggerDialog();
                dialogFinished++;
            }
            else //I guess s/he is busy dialog.
            {
                crew.allCharDialogs[0].TriggerDialog();
            }
            
        }
        Exc.SetActive(false);
    }
}
