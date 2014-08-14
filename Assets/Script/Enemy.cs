using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    float AddTimeAttack;
    float AddTimeCoolDown;
    int counter = 0;
    bool Follow = false;
	void Start ()
    {
        
	}
	

	void Update () 
    {
        
	    if(Follow)
        {
            if (Mathf.Abs(Player.position.x - transform.position.x) >= 1.5 || Mathf.Abs(Player.position.z - transform.position.z) >= 1.5)
            {
            transform.position = Vector3.MoveTowards(transform.position , Player.position , 0.1f);
            }

            if (Mathf.Abs(Player.position.x - transform.position.x) <= 1.5f && Mathf.Abs(Player.position.z - transform.position.z) <= 1.5f)
            {
                if (Time.time > AddTimeAttack && Time.time > AddTimeCoolDown)
                {
                    ++counter;
                    AddTimeAttack = Time.time + 0.3f;
                    print("Attack");
                    if (counter >= 3)
                    {
                        
                        counter = 0;
                        AddTimeCoolDown = Time.time + Random.Range(2, 5);
                        print("Cool Down = " + (AddTimeCoolDown - Time.time));
                    }
                }
            }
        }
        if (Mathf.Abs(Player.position.x - transform.position.x) <= 2f && Mathf.Abs(Player.position.z - transform.position.z) <= 2f)
        {
            Follow = true;
        }
        
	}
   
	void OnTriggerEnter(Collider col)
    {
		print("adfadsfafafasfUYTYTTYOJHKBVJHGJKH");

        if (col.gameObject.tag == "flashLight")
        {
			//print("adfadsfafafasfUYTYTTYOJHKBVJHGJKH");
            Follow = true;
        }
    }
}
