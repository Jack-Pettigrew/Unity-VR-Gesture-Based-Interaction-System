using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    // UI Variables
    private bool _nightMode = false;

    // UI Handles
    [SerializeField]
    private Text _time;
    private Animator _animator;

    // Assign handles straight away
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _time.text = System.DateTime.Now.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        
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
}
