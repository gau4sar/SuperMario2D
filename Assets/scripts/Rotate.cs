using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 360 * Time.deltaTime * speed);
    }
}
