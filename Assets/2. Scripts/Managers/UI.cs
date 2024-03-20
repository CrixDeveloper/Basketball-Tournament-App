using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour
{
    #region Variables to use:

    // Private non-visible variables:
    public static UI Instance;

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

    public void ExitApplication()
    {
        StartCoroutine(DefaultDelay());

        Application.Quit();
    }

    #endregion
}
