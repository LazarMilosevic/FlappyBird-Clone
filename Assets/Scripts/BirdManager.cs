using UnityEngine;

public class BirdManager : MonoBehaviour
{
    [SerializeField] private GameObject _dayBird;
    [SerializeField] private GameObject _nightBird;

    void Start()
    {
        _dayBird.SetActive(BackGroundManager.instance.IsDay);
        _nightBird.SetActive(!BackGroundManager.instance.IsDay);
    }
}
