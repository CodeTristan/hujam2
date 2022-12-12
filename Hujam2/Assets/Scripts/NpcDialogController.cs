using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogController : MonoBehaviour
{
    [SerializeField] Crew crew;
    private DayManager dayManager;

    public int[] dialogDays;
    private int dialogAvaliableIndex = 1;
    private int dialogFinished = 1;
    private void Start()
    {
        dayManager = FindObjectOfType<DayManager>();
    }

    public void StartDialog()
    {
        if (dayManager.dayCount > crew.allCharDialogs.Length)
            crew.allCharDialogs[0].TriggerDialog();
        else
        {
            dialogAvaliableIndex = 1;
            for (int i = 0; i < dialogDays.Length; i++)
            {
                if(dayManager.dayCount >= dialogDays[i])
                {
                    dialogAvaliableIndex++;
                }
            }
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
    }
}
