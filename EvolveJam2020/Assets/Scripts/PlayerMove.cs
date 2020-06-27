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
    private float speed;

    private PlayerControls controls = null;

    private void Awake()
    {
        controls = new PlayerControls();
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
        Vector2 movementInput = new Vector2();

        if (myType == PlayerType.Player1)
        {
            movementInput = controls.Player1.Move.ReadValue<Vector2>();            
        }
        else if (myType == PlayerType.Player2)
        {
            movementInput = controls.Player2.Move.ReadValue<Vector2>();
        }

        transform.Translate(movementInput * speed * Time.deltaTime);
        if (movementInput.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void UseAbility(int abilityType)
    {
        Debug.Log($"You used ability number {abilityType}");
    }

#if false
        if (myType == PlayerType.Player1)
        {
            for (int i = 0; i < p1Abilities.Length; i++)
            {
                if (Input.GetKeyDown(p1Abilities[i]))
                {
                    UseAbility(i);
                }
            }
        }
        else if (myType == PlayerType.Player2)
        {
            for (int i = 0; i < p2Abilities.Length; i++)
            {
                if (Input.GetKeyDown(p2Abilities[i]))
                {
                    UseAbility(i);
                }
            }
        }
#endif
}
