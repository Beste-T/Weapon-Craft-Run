using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollowScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0.0f, 2.0f, -0.5f);  
    }
}
