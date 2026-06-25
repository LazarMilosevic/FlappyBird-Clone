using System;
using System.Linq.Expressions;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] private BackGroundGetter _backgroundDay;
    [SerializeField] private BackGroundGetter _backgroundNight;

    private bool isDay;
    private float _speed = 0.25f;
    private float _resetPos = -1.44f;

    void Start()
    {
        int hour = DateTime.Now.Hour;
        isDay = (hour > 4 && hour < 22);
        _backgroundDay.gameObject.SetActive(isDay);
        _backgroundNight.gameObject.SetActive(!isDay);

    }

    private void Update()
    {
        HandleBackground();
    }

    private void HandleBackground()
    {
        switch (isDay) 
        {
            case true:
                MoveBackground(_backgroundDay);
                TeleportBackground(_backgroundDay);
                break;
            case false:
                MoveBackground(_backgroundNight);
                TeleportBackground(_backgroundNight);
                break;
        }
        
        /*if (isDay)
        {
            MoveBackground(_backgroundDay);
            TeleportBackground(_backgroundDay);

        }
        else
        {

            MoveBackground(_backgroundNight);
            TeleportBackground(_backgroundNight);

        }*/
    }

    private void MoveBackground(BackGroundGetter obj)
    {
        obj._backgroundA.transform.position += Vector3.left * _speed * Time.deltaTime;
        obj._backgroundB.transform.position += Vector3.left * _speed * Time.deltaTime;
        obj._backgroundC.transform.position += Vector3.left * _speed * Time.deltaTime;
    }

    private void TeleportBackground(BackGroundGetter obj)
    {
        if (obj._backgroundA.transform.position.x <= _resetPos)
        {
            obj._backgroundA.transform.position = obj._backgroundB.transform.position + Vector3.right * 2 * (-_resetPos);
        }
        if (obj._backgroundB.transform.position.x <= _resetPos)
        {
            obj._backgroundB.transform.position = obj._backgroundC.transform.position + Vector3.right * 2 * (-_resetPos);
        }
        if (obj._backgroundC.transform.position.x <= _resetPos)
        {
            obj._backgroundC.transform.position = obj._backgroundA.transform.position + Vector3.right * 2 * (-_resetPos);
        }
    }
}
