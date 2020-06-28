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

    public bool shielded;

    [SerializeField]
    Vector2 movementInput = new Vector2();

    Animator anim;

    private PlayerControls controls = null;

    private SpriteRenderer mySP;

    [HideInInspector]
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

    private bool waterOnCooldown;
    private float waterCooldownTime;

    [SerializeField]
    private GameObject waterShieldObj, whirpoolObj;

    public void Whirpool()
    {
        Debug.Log($"{myType} just used Whirpool at level {GameManager.instance.waterLevel}");
        if (!waterOnCooldown)
        {
            // Spawn the whirpool
            GameObject clone = Instantiate(whirpoolObj, transform.position, Quaternion.identity);
            Destroy(clone, 10 + GameManager.instance.waterLevel * 0.25f);

            // Set the cooldown
            waterOnCooldown = true;
            waterCooldownTime = Mathf.Max(0, 30 - (GameManager.instance.waterLevel * 0.25f));
        }
    }

    public void WaterShield()
    {
        Debug.Log($"{myType} just used WaterShield at level {GameManager.instance.waterLevel}");
        // Check cooldown
        if (!waterOnCooldown && !shielded)
        {
            // Instantiate the water shield
            GameObject clone = Instantiate(waterShieldObj, transform, false);

            shielded = true;

            // Set the cooldown
            waterOnCooldown = true;
            waterCooldownTime = Mathf.Max(0, 30 - (GameManager.instance.waterLevel * 0.25f));

            // Duration scales with level
            Destroy(clone, 10 + GameManager.instance.waterLevel * 0.25f);
        }
    }

    #endregion


    #region FIRE ABILITIES

    private bool fireOnCooldown;
    private float fireCooldownTime;

    [SerializeField]
    private GameObject fireShieldObj, fireBlastObj;

    public void FireBlast()
    {
        Debug.Log($"{myType} just used FireBlast at level {GameManager.instance.fireLevel}");
        if (!fireOnCooldown)
        {
            fireOnCooldown = true;
            GameObject clone = Instantiate(fireBlastObj, transform, false);
            clone.transform.localScale *= 1 + (GameManager.instance.fireLevel * 0.1f);
            fireCooldownTime = fireCooldownTime = Mathf.Max(0, 30 - (GameManager.instance.fireLevel * 0.25f));
        }
    }

    public void FireShield()
    {
        Debug.Log($"{myType} just used FireShield at level {GameManager.instance.fireLevel}");

        // Check cooldown
        if (!fireOnCooldown && !shielded)
        {
            // Instantiate the fire shield
            GameObject clone = Instantiate(fireShieldObj, transform, false);

            shielded = true;

            // Set the cooldown
            fireOnCooldown = true;
            fireCooldownTime = Mathf.Max(0, 30 - (GameManager.instance.fireLevel * 0.25f));

            // Duration scales with level
            Destroy(clone, 10 + GameManager.instance.fireLevel * 0.25f);            
        }
    }

    #endregion


    #region AIR ABILITIES

    private bool airOnCooldown;
    private float airCooldownTime;

    [SerializeField]
    private GameObject airShieldObj, airBladeObj;

    public void AirBlade()
    {
        // spawn air blade
        // Size it covers is proportionate to AirLevel
        Debug.Log($"{myType} just used AirBlade at level {GameManager.instance.airLevel}");

        // Spawn the air blade
        GameObject clone = Instantiate(airBladeObj, transform, false);

        clone.transform.localScale *= 1 + (GameManager.instance.airLevel * 0.1f);

        Destroy(clone, 10 + GameManager.instance.airLevel * 0.25f);

        // Set the cooldown
        airOnCooldown = true;
        airCooldownTime = Mathf.Max(0, 30 - (GameManager.instance.airLevel * 0.25f));
    }

    public void AirShield()
    {
        Debug.Log($"{myType} just used AirShield at level {GameManager.instance.airLevel}");

        // Check cooldown
        if (!airOnCooldown && !shielded)
        {
            // Instantiate the air shield
            GameObject clone = Instantiate(airShieldObj, transform, false);

            shielded = true;

            // Set the cooldown
            airOnCooldown = true;
            airCooldownTime = Mathf.Max(0, 30 - (GameManager.instance.airLevel * 0.25f));

            // Duration scales with level
            Destroy(clone, 10 + GameManager.instance.airLevel * 0.25f);
        }
    }

    #endregion


    #region EARTH ABILITIES

    private bool earthOnCooldown;
    private float earthCooldownTime;

    [SerializeField]
    private GameObject earthShieldObj, rockSlideObj;

    public void EarthShield()
    {
        Debug.Log($"{myType} just used EarthShield at level {GameManager.instance.earthLevel}");

        // Check cooldown
        if (!earthOnCooldown && !shielded)
        {
            // Instantiate the earth shield
            GameObject clone = Instantiate(earthShieldObj, transform, false);

            shielded = true;

            // Set the cooldown
            earthOnCooldown = true;
            earthCooldownTime = Mathf.Max(0, 30 - (GameManager.instance.earthLevel * 0.25f));

            // Duration scales with level
            Destroy(clone, 10 + GameManager.instance.earthLevel * 0.25f);
        }
    }

    public void RockSlide()
    {
        Debug.Log($"{myType} just used RockSlide at level {GameManager.instance.earthLevel}");
        if (!earthOnCooldown)
        {
            GameObject clone = Instantiate(rockSlideObj, transform.position, Quaternion.identity);

            // Set the cooldown
            earthOnCooldown = true;
            earthCooldownTime = Mathf.Max(0, 30 - (GameManager.instance.earthLevel * 0.25f));
            Destroy(clone, 15f);
        }
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
        
        if (waterCooldownTime > 0)
        {
            waterCooldownTime -= Time.deltaTime;
            if (waterCooldownTime <= 0)
            {
                waterOnCooldown = false;
            }
        }

        if (fireCooldownTime > 0)
        {
            fireCooldownTime -= Time.deltaTime;
            if (fireCooldownTime <= 0)
            {
                fireOnCooldown = false;
            }
        }

        if (airCooldownTime > 0)
        {
            airCooldownTime -= Time.deltaTime;
            if (airCooldownTime <= 0)
            {
                airOnCooldown = false;
            }
        }

        if (earthCooldownTime > 0)
        {
            earthCooldownTime -= Time.deltaTime;
            if (earthCooldownTime <= 0)
            {
                earthOnCooldown = false;
            }
        }
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
        } 
        catch (System.Exception e)
        {
            Debug.Log("Please attach ElementLoadout.cs to this player!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!shielded)
            {
                GameManager.instance.EndGame();
            }
            else
            {
                Destroy(collision.gameObject);
                GameManager.instance.enemiesKilled++;
            }
        }
    }
}
