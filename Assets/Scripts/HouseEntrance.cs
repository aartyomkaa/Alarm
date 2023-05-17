using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseEntrance : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _alarm.StartPlay();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _alarm.StopPlay();
        }
    }
}
