using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    CapsuleCollider2D swordHitBox;
    SpriteRenderer swordHitBoxRenderer;
    public float attackTime = 1f;
    public float attackCoolDown = 1f;
    private bool canAttack = true; // TODO : combo system / counter system / USE ENUM + stateMachine

    private void Awake()
    {
        swordHitBox = GetComponent<CapsuleCollider2D>();
        swordHitBoxRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        if (canAttack)
        {
            swordHitBox.enabled = true;
#if UNITY_EDITOR
            swordHitBoxRenderer.enabled = true;
#endif
            canAttack = false;
            Invoke("endAttack", attackTime);
        }
    }

    public void endAttack()
    {
        swordHitBox.enabled = false;
#if UNITY_EDITOR
        swordHitBoxRenderer.enabled = false;
#endif
        Invoke("nextAttack", attackTime);
    }

    public void nextAttack()
    {
        canAttack = true;
    }

    public void Flip()
    {
        transform.localPosition = new Vector3(-transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -transform.localEulerAngles.z);
    }

}
