using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UI : MonoBehaviour
{
    #region Variables to use:

    // Private non-visible variables:
    public static UI Instance;

    [Header("Panels: ")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject newTournamentPanel;
    [SerializeField] private GameObject oldTournamentsPanel;
    [SerializeField] private GameObject customizationPanel;

    #endregion

    // Awake is called before any other method and at just when scene starts
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Not used at the moment. 
    }

    // Update is called once per frame
    private void Update()
    {
        // Not used at the moment. 
    }

    #region Methods in use: 

    private IEnumerator DefaultDelay()
    {
        yield return new WaitForSeconds(2.5f);
    }

    public void NewGame()
    {
        StartCoroutine(DefaultDelay());

        SceneManager.LoadScene("BT-MainGame");
    }

    public void ActivateNewTournament()
    {
        if (mainPanel.activeInHierarchy)
        {
            newTournamentPanel.SetActive(true);
            mainPanel.SetActive(false);
            oldTournamentsPanel.SetActive(false);
            customizationPanel.SetActive(false);
        }
    }

    public void ActivateOldTournamment()
    {
        if (mainPanel.activeInHierarchy)
        {
            oldTournamentsPanel.SetActive(true);
            mainPanel.SetActive(false);
            newTournamentPanel.SetActive(false);
            customizationPanel.SetActive(false);
        }
    }

    public void ActivateCustomization()
    {
        if (mainPanel.activeInHierarchy)
        {
            customizationPanel.SetActive(true);
            mainPanel.SetActive(false);
            newTournamentPanel.SetActive(false);
            oldTournamentsPanel.SetActive(false);
        }
    }

    public void ExitApplication()
    {
        StartCoroutine(DefaultDelay());

        Application.Quit();
    }

    #endregion
}
