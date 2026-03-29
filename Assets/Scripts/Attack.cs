using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    Collider2D hitBox;
    SpriteRenderer attackRenderer;
    SpriteRenderer hitBoxRenderer;
    public float attackTime = 0.2f;
    public float attackCoolDown = 0.8f;
    public int damages = 1;
    private bool canAttack = true; // TODO : combo system / counter system / USE ENUM + stateMachine

    private void Awake()
    {
        hitBox = GetComponent<Collider2D>();
        attackRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startAttack()
    {
        if (canAttack)
        {
            hitBox.enabled = true;
#if UNITY_EDITOR
            attackRenderer.enabled = true;
#endif
            canAttack = false;
            Invoke("endAttack", attackTime);
        }
    }

    public void endAttack()
    {
        hitBox.enabled = false;
#if UNITY_EDITOR
        attackRenderer.enabled = false;
#endif
        Invoke("nextAttack", attackCoolDown);
    }

    public void nextAttack()
    {
        canAttack = true;
    }

    public void Flip()
    {
        transform.localPosition = new Vector3(-transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -transform.localEulerAngles.z);
        attackRenderer.flipX = !attackRenderer.flipX;
    }

    // Update is called once Collider2D  frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if ( (other.tag == "MOB" && tag == "Player") || (other.tag == "Player" && tag == "MOB") )
        {
            Character character = other.GetComponent<Character>();
            Debug.Log(character.name + " attacked");
            character.Hit(damages);
        }
    }

}
