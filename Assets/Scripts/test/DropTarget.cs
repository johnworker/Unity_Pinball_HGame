using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTarget : MonoBehaviour
{
    public float dropDistance = 1.0f;
    public int bankID = 0;
    public float resetDelay = 0.5f;
    public static List<DropTarget> dropTargets = new List<DropTarget>();

    public bool isDropped = false;

    [SerializeField, Header("�U������")]
    private AudioClip soundPushDown;


    void Start()
    {
        dropTargets.Add(this);
    }

    void OnCollisionEnter()
    {
        if (!isDropped)
        {
            transform.position += Vector3.down * dropDistance;
            isDropped = true;

            SystemSound.instance.PlaySound(soundPushDown, new Vector2(1f, 1.5f));

            bool resetBank = true;
            foreach (DropTarget target in dropTargets)
            {
                if (target.bankID == bankID)
                {
                    if (!target.isDropped)
                    {
                        resetBank = false;
                    }
                }
            }
            if (resetBank)
            {
                Invoke("ResetBank", resetDelay);
            }
        }
    }

    void ResetBank()
    {
        foreach (DropTarget target in dropTargets)
        {
            if (target.bankID == bankID)
            {
                target.transform.position += Vector3.up * dropDistance;
                target.isDropped = false;
            }
        }
    }
}
