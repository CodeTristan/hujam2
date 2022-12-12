using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Entity;
using UnityEngine.EventSystems;
using TMPro;

public class PlanetPanelController : MonoBehaviour
{
    [SerializeField] Scientist ScientistP;
    [SerializeField] Assets.Entity.Security SecurityP;
    [SerializeField] Medic MedicP;
    [SerializeField] TechSupport TechSupportP;
    [SerializeField] TechnicalEngineer TechnicalEngineerP;
    [SerializeField] DayManager dayManager;
    [SerializeField] GameObject PlanetPanelUI;
    [SerializeField] TextMeshProUGUI dangerText;

    private void OnEnable()
    {
        if(dayManager.aproachingPlanet.planetRiskLevel() < 0.25f)
        {
            dangerText.text = "Tehlike seviyesi: Düþük";
        }
        else if (dayManager.aproachingPlanet.planetRiskLevel() > 0.25f && dayManager.aproachingPlanet.planetRiskLevel() < 0.65f)
        {
            dangerText.text = "Tehlike seviyesi: Orta";
        }
        else if (dayManager.aproachingPlanet.planetRiskLevel() > 0.65f )
        {
            dangerText.text = "Tehlike seviyesi: Yüksek";
        }

    }
    public void ClosePanel()
    {
        PlanetPanelUI.SetActive(false);
    }
    public void ChooseCrewMember()
    {
        switch(EventSystem.current.currentSelectedGameObject.name)
        {
            case "Crewmate0": dayManager.PlanetSelectedCrew = TechnicalEngineerP; break;
            case "Crewmate1": dayManager.PlanetSelectedCrew = SecurityP; break;
            case "Crewmate2": dayManager.PlanetSelectedCrew = ScientistP; break;
            case "Crewmate3": dayManager.PlanetSelectedCrew = MedicP; break;
            case "Crewmate4": dayManager.PlanetSelectedCrew = TechSupportP; break;
        }
        ClosePanel();
    }
}
