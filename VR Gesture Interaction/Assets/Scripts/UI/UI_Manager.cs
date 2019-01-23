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

    // UI Handles
    [SerializeField]
    private Text _timeText;
    [SerializeField]
    private Text _performedGestureText;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    // Triggers UI Night Mode animation
    void FadeNightMode()
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

    // Sets gesture name to identified gesture name
    public void SetPerformedGestureName(ref string gestureName)
    {
        _performedGestureText.text = gestureName;
    }

}
