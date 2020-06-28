using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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

    public string a1, a2;

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

        /*
        controls.Player1.Ability1.performed += ctx => UseAbility(1);
        controls.Player1.Ability2.performed += ctx => UseAbility(2);
        controls.Player1.Ability3.performed += ctx => UseAbility(3);
        controls.Player1.Ability4.performed += ctx => UseAbility(4);

        controls.Player2.Ability1.performed += ctx => UseAbility(1);
        controls.Player2.Ability2.performed += ctx => UseAbility(2);
        controls.Player2.Ability3.performed += ctx => UseAbility(3);
        controls.Player2.Ability4.performed += ctx => UseAbility(4);
        */

        if (myType == PlayerType.Player1)
        {
            MethodInfo a1Func = GetType().GetMethod(a1);
            controls.Player1.Ability1.performed += ctx => a1Func.Invoke(this, null);

            MethodInfo a2Func = GetType().GetMethod(a2);
            controls.Player1.Ability2.performed += ctx => a2Func.Invoke(this, null);
        }
        else if (myType == PlayerType.Player2)
        {
            MethodInfo a1Func = GetType().GetMethod(a1);
            controls.Player2.Ability1.performed += ctx => a1Func.Invoke(this, null);

            MethodInfo a2Func = GetType().GetMethod(a2);
            controls.Player2.Ability2.performed += ctx => a2Func.Invoke(this, null);
        }
        controls.Player1.Evolve.performed += ctx => Evolve();
    }

    #region WATER ABILITIES

    public void WaterWhip()
    {
        Debug.Log($"{myType} just used WaterWhip at level {GameManager.instance.waterLevel}");
    }

    public void WaterShield()
    {
        Debug.Log($"{myType} just used WaterShield at level {GameManager.instance.waterLevel}");
    }

    #endregion


    #region FIRE ABILITIES

    public void FireBall()
    {
        Debug.Log($"{myType} just used FireBall at level {GameManager.instance.fireLevel}");
    }

    public void FireShield()
    {
        Debug.Log($"{myType} just used FireShield at level {GameManager.instance.fireLevel}");
    }

    #endregion


    #region AIR ABILITIES

    public void AirBlade()
    {
        // spawn air blade
        // Distance it travels is equal to AirLevel
        Debug.Log($"{myType} just used AirBlade at level {GameManager.instance.airLevel}");
    }

    public void AirShield()
    {
        Debug.Log($"{myType} just used AirShield at level {GameManager.instance.airLevel}");
    }

    #endregion


    #region EARTH ABILITIES

    public void EarthShield()
    {
        Debug.Log($"{myType} just used EarthShield at level {GameManager.instance.earthLevel}");
    }

    public void RockSlide()
    {
        Debug.Log($"{myType} just used RockSlide at level {GameManager.instance.earthLevel}");
    }

    #endregion

    

    private void OnDisable()
    {
        controls.Player1.Disable();
        controls.Player2.Disable();
    }

    private void Update()
    {
        Move();        
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

    private void Evolve()
    {
        try
        {
            ElementLoadout el = GetComponent<ElementLoadout>();
        } catch (System.Exception e)
        {
            Debug.Log("Please attach ElementLoadout.cs to this player!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.instance.RetartScene();
        }
    }
}
