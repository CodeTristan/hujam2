using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public GameObject crewManager; //Get crew scripts from the manager game object

  void Start()
  {
    IMood[] crewScripts = crewManger.getComponents<IMood>(); //Get scripts for later use
  }

  public void EventResult(string crewName, float effect) //FUNCTION MADE TO BE USED BY OTHER SCRIPTS WHEN AN EVENT HAS ENDED TO ADJUST MOOD
  {
    foreach(IMood script in crewScripts)//Get each script form the list for testing
    {
      if(script.name == crewName)//Check names to identify crewmate
        script.moodEffect(effect);//Effect crewmate mood. Change fucntion name to match interface later on.
    }
  }
}
