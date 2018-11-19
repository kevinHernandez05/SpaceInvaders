using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;                           //Store a reference to the Game Object PausePanel 
    public GameObject CreditsPanel;                         //Store a reference to the Game Object CreditsPanel
    public GameObject closePanel;                           //Store a reference to the Game Objet CloseConfirmationPanel

    private GameObject activePanel;                         
    private MenuObject activePanelMenuObject;
    private EventSystem eventSystem;



    private void SetSelection(GameObject panelToSetSelected)
    {

        activePanel = panelToSetSelected;
        activePanelMenuObject = activePanel.GetComponent<MenuObject>();
        if (activePanelMenuObject != null)
        {
            activePanelMenuObject.SetFirstSelected();
        }
    }

    public void Start()
    {
        SetSelection(menuPanel);
    }

    //Call this function to activate and display the Options panel during the main menu
    public void ShowOptionsPanel()
	{
		optionsPanel.SetActive(true);
		optionsTint.SetActive(true);
        menuPanel.SetActive(false);
        SetSelection(optionsPanel);

    }

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel()
	{
        menuPanel.SetActive(true);
        optionsPanel.SetActive(false);
		optionsTint.SetActive(false);
	}

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu()
	{
		menuPanel.SetActive (true);
        SetSelection(menuPanel);
    }

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
		menuPanel.SetActive (false);

	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
	{
		pausePanel.SetActive (true);
		optionsTint.SetActive(true);
        SetSelection(pausePanel);
    }

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);

	}

    //Call this funciton to activate and display the Credits Panel during Gameplay
    public void showCreditPanel(){

        optionsTint.SetActive(true);
        menuPanel.SetActive(false);
        CreditsPanel.SetActive(true);
        //SetSelection(optionsPanel);
    }


    //Call this funciton to deactivate and hide the Credits Panel during Gameplay
    public void hideCreditPanel()
    {
        optionsTint.SetActive(false);
        menuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    //Call this function to activate and display the Close Confirmation Panel
    public void showCloseConfirmationPanel(){
        optionsTint.SetActive(true);
        menuPanel.SetActive(false);
        closePanel.SetActive(true);

    }


    //Call this function to deactivate and hide the Close Confirmation Panel
    public void hideCloseConfirmationPanel()
    {
        optionsTint.SetActive(false);
        menuPanel.SetActive(true);
        closePanel.SetActive(false);
    }
}
