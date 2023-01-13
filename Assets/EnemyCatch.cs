using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCatch : MonoBehaviour
{
    [SerializeField] private float maxDistanceToPlayer;
    [SerializeField] private float speed;
    [SerializeField] private float angleSet;
    [SerializeField] private GameObject player;

    void Update() 
    {
        if(isVisible() && isClose()) 
        {
            Move();
        }
    }

    public bool isVisible()
    {
        var guard_pos = transform.position;
        var guard_facing = transform.forward;
        var hero_pos = player.transform.position;

        var guard_facing_n = Vector3.Normalize(guard_facing);
        var guard_to_hero = Vector3.Normalize(hero_pos - guard_pos);

        var dot = Vector3.Dot(guard_facing_n, guard_to_hero);
        double angle = Math.Acos(dot);

        return angle < 1;
    }

    public bool isClose()
    {
        float dist = (player.transform.position - transform.position).sqrMagnitude;
        if (dist <= maxDistanceToPlayer * maxDistanceToPlayer) return true;
        else return false;
    }

    public void Move() {
        var movingDirection = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(movingDirection);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);    
    }
}
