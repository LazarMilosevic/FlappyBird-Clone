using UnityEngine;

public class BirdManager : MonoBehaviour
{
    [SerializeField] private GameObject _dayBird;
    [SerializeField] private GameObject _nightBird;

    void Start()
    {
        _dayBird.SetActive(BackGroundManager.instance.isDay);
        _nightBird.SetActive(!BackGroundManager.instance.isDay);
    }
}
