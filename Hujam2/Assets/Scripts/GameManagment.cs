using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public GameObject crewManager;
  public GameObject[] crewMembers;

  public void EventResult(string roleName, float effect) //FUNCTION MADE TO BE USED BY OTHER SCRIPTS WHEN AN EVENT HAS ENDED TO ADJUST MOOD
  {
    foreach(GameObject crewChild in crewManager.transform)
    {
      if(crewChild.GetComponent<Crew>().RoleName == roleName)
        crewChild.GetComponent<IMood>().moodEffect(effect);
    }
  }
}
