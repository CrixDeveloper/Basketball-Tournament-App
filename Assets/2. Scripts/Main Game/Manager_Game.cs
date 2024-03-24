using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager_Game : MonoBehaviour
{
    #region Variables to use:

    // Private non-visible variables: 
    public static Manager_Game Instance;
    private int teamOneScore;
    private int teamTwoScore;

    [Header("Panels References: ")]
    public GameObject scoreBoardPanel;
    public GameObject warningPanel;

    [Header("Texts References: ")]
    [SerializeField] private Text teamOneScoreText;
    [SerializeField] private Text teamTwoScoreText;
    public Text warningText;

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
        teamOneScoreText.text = "" + teamOneScore.ToString();
        teamTwoScoreText.text = "" + teamTwoScore.ToString();
    }

    #region Methods to use: 

    public void PlayButton()
    {
        if (Manager_Countdown.Instance.haveTime == true)
        {
            warningPanel.SetActive(false);
            warningText.text = "";

            Manager_Countdown.Instance.canStart = true;
        }
        else
        {
            warningPanel.SetActive(true);
            warningText.text = "Game can't start since initial time has not been set...";

            StartCoroutine(HideWarningPanel());
        }
    }

    private IEnumerator HideWarningPanel()
    {
        yield return new WaitForSeconds(3f);

        warningPanel.SetActive(false);
        warningText.text = "";
    }

    public void ResetButton()
    {
        Manager_Countdown.Instance.canStart = false;
        Manager_Countdown.Instance.haveTime = false;
        Manager_Countdown.Instance.remainingTime = 0;

        Manager_Countdown.Instance.countdown.text = "" + Manager_Countdown.Instance.remainingTime.ToString();

        teamOneScore = 0;
        teamTwoScore = 0;
    }

    #region SubRegion: Team One
    public void Add3Points()
    {
        // Add sound for the buttons...
        teamOneScore += 3;
    }

    public void Add2Points()
    {
        teamOneScore += 2;
    }

    public void Add1Point()
    {
        teamOneScore += 1;
    }

    public void Subtract1Point()
    {
        teamOneScore -= 1;
    }
    #endregion

    #region SubRegion: Team Two
    public void Add3points()
    {
        teamTwoScore += 3;
    }

    public void Add2points()
    {
        teamTwoScore += 2;
    }

    public void Add1point()
    {
        teamTwoScore += 1;  
    }

    public void Subtract1point()
    {
        teamTwoScore -= 1;
    }
    #endregion

    #endregion
}
