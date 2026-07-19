using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public static BackGroundManager instance;

    [Header("References")]
    [SerializeField] private BackGroundGetter _backgroundDay;
    [SerializeField] private BackGroundGetter _backgroundNight;

    [Header("Settings")]
    [SerializeField] private float _speed = 0.25f;
    [SerializeField] private float _backgroundWidth = 1.44f;

    private List<GameObject> _backgrounds = new List<GameObject>();
    private bool _isDay;
    private float _resetPos;
    private float _teleportDistance;

    public bool IsDay => _isDay;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        int hour = DateTime.Now.Hour;
        _isDay = (hour > 4 && hour < 22);

        _backgroundDay.gameObject.SetActive(_isDay);
        _backgroundNight.gameObject.SetActive(!_isDay);

        
    }

    private void Start()
    {
        //fill list depending on daytime
        if (_isDay)
        {
            _backgrounds.Add(_backgroundDay._backgroundA);
            _backgrounds.Add(_backgroundDay._backgroundB);
            _backgrounds.Add(_backgroundDay._backgroundC);
        }
        else
        {
            _backgrounds.Add(_backgroundNight._backgroundA);
            _backgrounds.Add(_backgroundNight._backgroundB);
            _backgrounds.Add(_backgroundNight._backgroundC);
        }

        _resetPos = -_backgroundDay._backgroundB.transform.position.x; //should be -backgroundWidth but bgs are overlapping
        _teleportDistance = _backgrounds.Count * _backgroundWidth; //teleports the left most bg past the right most bg
    }

    private void Update()
    {
        HandleBackground();
    }

    private void HandleBackground()
    {
        MoveBackground();
        TeleportBackground();

    }

    private void MoveBackground()
    {
        foreach (GameObject bg in _backgrounds)
        {
            bg.transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
        }
    }

    private void TeleportBackground()
    {
        foreach (GameObject bg in _backgrounds)
        {
            if (bg.transform.position.x <= _resetPos)
            {
                bg.transform.position += Vector3.right * _teleportDistance;
            }
        }
    }
}
