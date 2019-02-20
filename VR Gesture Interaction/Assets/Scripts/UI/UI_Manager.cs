using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    // Singleton UI_Manager
    public static UI_Manager instance = null;

    // UI Variables
    private bool _nightMode = false;
    private bool _mainMenuActive = true;

    [Header("Text Variables")]
    // Text Handles
    [SerializeField]
    private Text _timeText;
    [SerializeField]
    private Text _performedGestureText;
    [SerializeField]
    private Text _pleasureText, _arousalText, _dominanceText;

    private Animator _animator;

    // Assign handles straight away
    void Awake()
    {
        // Check for manager instance
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        // Get Handles
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _timeText.text = System.DateTime.Now.ToString();
 
        _performedGestureText.text = "Perform a Gesture!";
    }

    // Triggers UI Night Mode animation
    public void FadeNightMode()
    {
        if (!_nightMode)
        {
            _nightMode = !_nightMode;
            _animator.SetTrigger("NightModeFadeIn");
        }
        else
        {
            _nightMode = !_nightMode;
            _animator.SetTrigger("DayModeFadeIn");
        }
    }

    // Triggers Menu Swap animation
    public void MenuSwap()
    {
        if(_mainMenuActive)
        {
            _mainMenuActive = !_mainMenuActive;
            _animator.SetTrigger("SwapToGestureList");
        }
        else
        {
            _mainMenuActive = !_mainMenuActive;
            _animator.SetTrigger("SwapToMainMenu");
        }
    }

    // Sets gesture name to identified gesture name
    public void SetPerformedGestureName(ref string gestureName)
    {
        _performedGestureText.text = gestureName;
    }

    // Updates the displayed PAD values in the UI
    public void UpdatePADText(string p, string a, string d)
    {
        _pleasureText.text = "Pleasure: " + p + "f";
        _arousalText.text = "Pleasure: " + a + "f";
        _dominanceText.text = "Pleasure: " + d + "f";
    }

}
