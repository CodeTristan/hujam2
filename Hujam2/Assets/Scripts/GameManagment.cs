using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public GameObject crewManager; //Get crew scripts from the manager game object
  public Component[] crewScripts;
  public IMood[] crewInterface;
  public int day;

  void Start()
  {
    crewScripts = crewManager.GetComponents(typeof(IMood));
    crewInterface = crewManager.GetComponents<IMood>();
  }

  public void EventResult(string crewName, float effect) //FUNCTION MADE TO BE USED BY OTHER SCRIPTS WHEN AN EVENT HAS ENDED TO ADJUST MOOD
  {
    for(int i = 0; i < crewScripts.Length; i++)
    {
      if(crewScripts[i].name == crewName)
        crewInterface[i].moodEffect(effect);
    }
  }


}
