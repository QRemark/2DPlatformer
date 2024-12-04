using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testtrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Что-то вошло в зону видимости");

       
    }
}
