using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Countdown : MonoBehaviour
{
    #region Variables to use: 

    // Private non-visible variables:
    public static Manager_Countdown Instance;

    [Header("Manager References: ")]
    public TMP_InputField timeSelection;
    public Text countdown;
    public float remainingTime;
    public bool canStart = false;
    public bool haveTime = false;

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
        if (canStart == true)
        {
            Manager_Game.Instance.warningPanel.SetActive(false);

            DecreaseRemainingTime();
        }
    }

    #region Methods to use:

    public void ReadInputTimeSelection()
    {
        if (float.TryParse(timeSelection.text, out remainingTime))
        {
            Debug.Log("Successfully converted: " + remainingTime);

            haveTime = true;
            remainingTime = (remainingTime * 60);
        }
        else
        {
            Debug.Log("Conversion Failed");
        }
    }

    public void DecreaseRemainingTime()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;

            canStart = false;
            haveTime = false;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        countdown.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    #endregion 
}
