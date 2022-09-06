using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLayerController : MonoBehaviour
{
    public GameObject cloudContainer;
    public Camera camara;
    public Slider gas;
    public Slider nitro;
    public AudioSource idle;
    public AudioMananger listAudio;
    public ScreenDead dead;
    public sheck coli;
    public MenuPause pause;
    public listSprite sprite;
    public float speed;
    public float plusGas;
    public float plusBateri;
    public float speedNegative;
    private float cost;
    private float costBatery;
    public bool left;
    public bool Right;
    public bool turbo;
    public bool turbo2;
    public bool check;
    public bool meta;
    private bool isGround;
    private bool leftTurn;
    private bool RightTurn; 
    float timer;
    float lastMotorSound;
    public float minPitch = 0.8f;
    public float maxPitch = 2.5f;
    public float frequency = 0.5f;
    public  int countCoint;
    public float gravity;
    public float airGravity;
    bool over;
    private float speedReal;
    float zpodition ;
    float currentSpeed;



    void Start()
    {
        zpodition = camara.orthographicSize;
        if (PlayerPrefs.GetInt("fictionUpgrade", 0) != 0)
        {
            GetComponent<Rigidbody2D>().sharedMaterial = sprite.listMaterial[(PlayerPrefs.GetInt("fictionUpgrade",0)-1)];
        }
        speedReal = speed + (10+ PlayerPrefs.GetInt("speedUpgrade",0));
        costBatery = 0.09f - (0.02f * PlayerPrefs.GetInt("bateryUpgrade", 0));
        cost = 0.09f - (0.02f * PlayerPrefs.GetInt("fuelUpgrade",0));
        listAudio = FindObjectOfType<AudioMananger>();
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite.listSpritePlayer[PlayerPrefs.GetInt("indexValueCharacter", 0)];
        gameObject.GetComponent<Animator>().runtimeAnimatorController = sprite.listAnimation[PlayerPrefs.GetInt("indexValueCharacter", 0)];
    }
    private void FixedUpdate()
    {
        camara.orthographicSize = zpodition + camara.transform.position.y * 5 * Time.deltaTime;
    }

    void Update()
    {       
        currentSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;
        currentSpeed = Mathf.Clamp(currentSpeed, Random.Range(1.3f,2.5f), 35);
        if(Time.time - lastMotorSound > frequency / currentSpeed)
        {
            float value = currentSpeed / 35;
            idle.pitch = (value * (maxPitch-minPitch)) + minPitch;
            idle.Stop();
            idle.Play();
            lastMotorSound = Time.time;
        }
        if (over == true || meta == true)
        {          
                return;                    
        }
       
        camara.transform.position = new Vector3(transform.position.x, transform.position.y, camara.transform.position.z);
        cloudContainer.transform.position = new Vector2(transform.position.x, cloudContainer.transform.position.y); 
        moving();
        turboActivate();
        if (gas.value == 0)
        {
            check = true;
            dead.Check(check,meta);
        }
        if (Right == false && left == false)
        {
            gameObject.GetComponent<Animator>().SetBool("idle", false);
        }
    }
    private void moving()
    {
        
        if (Right)
        {            
            if (isGround)
            {           
                GetComponent<Rigidbody2D>().AddForce(transform.right * speedReal * Time.deltaTime, ForceMode2D.Impulse);
                GetComponent<Rigidbody2D>().AddTorque(0.3f, ForceMode2D.Force);
            }
            if(coli.fly)
            {
                GetComponent<Rigidbody2D>().AddTorque(1f, ForceMode2D.Impulse);
            }

            
            if (RightTurn)
            {
                GetComponent<Rigidbody2D>().AddTorque(7f, ForceMode2D.Impulse);
                RightTurn = false;
            }
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                fuelCost(1);
                timer = 0;
            }
        }

        if (left)
        {
            if (isGround)
            {
                GetComponent<Rigidbody2D>().AddForce(-transform.right * speedReal * Time.deltaTime, ForceMode2D.Impulse);
                GetComponent<Rigidbody2D>().AddTorque(-0.3f, ForceMode2D.Force);

            }
            if (coli.fly)
            {
                GetComponent<Rigidbody2D>().AddTorque(-1f, ForceMode2D.Impulse);
            }

            if (leftTurn)
            {
                GetComponent<Rigidbody2D>().AddTorque(-7f, ForceMode2D.Impulse);
                leftTurn = false;
            }
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                fuelCost(2);
                timer = 0;
            }          
        }
    }
    public void turboActivate()
    {
        if (turbo == true)
        {           
            if (isGround)
            {
                if (nitro.value != 0)
                {
                    GetComponent<Rigidbody2D>().AddForce(transform.right * (speedReal * 0.6f), ForceMode2D.Impulse);
                    turbo = false;
                    turbo2 = true;
                    nitroCost();
                }
            }         
        }
    }
    private void turboActivateSpace()
    {
        if (transform.position.y < 25)
        {
            if (nitro.value != 0)
            {
                GetComponent<Rigidbody2D>().AddForce(transform.right * (speedReal * 0.8f), ForceMode2D.Impulse);
                turbo2 = true;
                nitroCost();
            }
        }
        else
        {
            return;
        }               
    }
    public void turboSpace()
    {
        if (Input.GetMouseButton(0) && pause.pause == false)
        {
            turboActivateSpace();
        }
    }
    public void TrueMovingRight()
    {
        if (Input.GetMouseButton(0) && pause.pause == false)
        {
            Right = true;
            RightTurn = true;
            gameObject.GetComponent<Animator>().SetBool("idle", true);
        }
    }
    public void FalseMovingRight()
    {
            Right = false;
    }
    public void TrueMovingLeft()
    {
        if (Input.GetMouseButton(0) && pause.pause == false)
        {
            left = true;
            leftTurn = true;
            gameObject.GetComponent<Animator>().SetBool("idle", true);
        }
    }
    public void FalseMovingLeft()
    {
            left = false;       
    }
    public void TrueTurbo()
    {
        if (Input.GetMouseButtonDown(0) && pause.pause == false)
        {
            turbo = true;
        }      
    }    
    public void FalseTurno()
    {
        turbo = false;
        turbo2 = false;
    }
    public void fuelCost(int divi)
    {
        if (isGround)
        {
            gas.value -= (cost / divi);
        }
        
    }
    public void nitroCost()
    {
        nitro.value -= (costBatery * 3f);
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "mapping")
        {
            isGround = true;

            if (Vector2.Dot(transform.up, Vector3.down) > 0.6f)
            {
                over = true;
                dead.Check(over, meta);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "mapping")
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = airGravity;
            isGround = false;
          
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ItemGas")
        {
            if (listAudio != null)
            {
                listAudio.SelectorAudio(0, 0.5f);
            }
            gas.value += plusGas;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Item")
        {
            if (listAudio != null)
            {
                listAudio.SelectorAudio(0, 0.5f);
            }
            nitro.value += plusBateri;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "gool")
        {
            meta = true;
            dead.Check(over, meta);
        }
    }
    public void pickCoin()
    {
        if(listAudio != null)
        {
            listAudio.SelectorAudio(1, 1);
        }
        countCoint++;
        dead.textCoin();
    }
}
