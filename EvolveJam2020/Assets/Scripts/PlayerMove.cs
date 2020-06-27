using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private enum PlayerType
    {
        Player1 = 0, 
        Player2 = 1
    };

    [SerializeField]
    private PlayerType myType;

    [SerializeField]
    private float speed = 3;

    [SerializeField]
    Vector2 movementInput = new Vector2();

    Animator anim;

    private PlayerControls controls = null;

    private SpriteRenderer mySP;

    private void Awake()
    {
        controls = new PlayerControls();
        mySP = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        controls.Player1.Enable();
        controls.Player2.Enable();

        controls.Player1.Ability1.performed += ctx => UseAbility(1);
        controls.Player1.Ability2.performed += ctx => UseAbility(2);
        controls.Player1.Ability3.performed += ctx => UseAbility(3);
        controls.Player1.Ability4.performed += ctx => UseAbility(4);

        controls.Player2.Ability1.performed += ctx => UseAbility(1);
        controls.Player2.Ability2.performed += ctx => UseAbility(2);
        controls.Player2.Ability3.performed += ctx => UseAbility(3);
        controls.Player2.Ability4.performed += ctx => UseAbility(4);

        controls.Player1.Evolve.performed += ctx => Evolve();
    }

    private void OnDisable()
    {
        controls.Player1.Disable();
        controls.Player2.Disable();
    }

    private void Update()
    {
        Move();
        //Ability();
    }

    private void Move()
    {        
        if (myType == PlayerType.Player1)
        {
            movementInput = controls.Player1.Move.ReadValue<Vector2>();
        }
        else if (myType == PlayerType.Player2)
        {
            movementInput = controls.Player2.Move.ReadValue<Vector2>();
        }

        transform.Translate(movementInput * speed * Time.deltaTime);
        anim.SetFloat("MoveSide", Mathf.Abs(movementInput.x));
        anim.SetFloat("MoveUp", Mathf.Abs(movementInput.y));

        mySP.flipX = (movementInput.x < 0);
    }

    private void UseAbility(int abilityType)
    {
        Debug.Log($"You used ability number {abilityType}");
    }

    private void Evolve()
    {
        Debug.Log("You evolved!");
    }
    
}
