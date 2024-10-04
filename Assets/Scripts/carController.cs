using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class carController : MonoBehaviour
{
    //Value for the turning speed of the car
    public float turnSpeed;
    //Value for the launch velocity of the bullet
    public float launchVelocity = 3000f;
    //Value for the turret cooldown
    public float turretCooldown = 3f;

    //The assigned number for the missile that you need to shoot
    public int currentMissileNumber;
    //The number of collected scrap
    public int collectedScrap;
    //The number of scrap needed to fire a missile
    public int scrapsNeeded;
    //The number of armor the car has
    public int armorLevel;

    //Bools that check if the car has reached the right and left edges at the screen
    private bool atRightEdge;
    private bool atLeftEdge;
    //The bool that checks whether your cooldown is done
    public bool canFire;
    //A bool to check if the gun is jammed
    private bool jammed;
    //Bool for if the car is armored
    public bool hasArmor;

    //A gameobject for the bullet prefab
    public GameObject Bullet;
    //A game object for the barrel
    public GameObject barrel;
    //For telling what is the closest missile
    public GameObject closestMissile;
    //The mesh of the car
    public GameObject carBody;
    //A list for all the missiles
    public GameObject[] allTargetsWithTag;
    //A list for all the wheels
    public GameObject[] wheels;
    //Refrence to the rocket
    public GameObject rocket;

    //A transform for the place where the bullet is supposed to spawn
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public Transform bulletSpawn3;
    //A transform for the object the turret is supposed to follow
    public Transform objectToShoot;

    //The text that tells you wether you can shoot your turret or not
    public TMP_Text coolDownText;
    //The text that tells you which key to press in order to shoot down the missile
    public TMP_Text pressText;

    //The sound effect for the gun firing
    public AudioSource gunSound;
    //The sound effect for when the gun jamms
    public AudioSource jammingSound;

    //A refrence to the black box that displays when a missile is fired
    public GameObject blackBox;
    //Refrence to the text that displays when a missile is fired
    public GameObject pressText2;
    //Refrences to the armor gameobjects
    public GameObject armor1;
    public GameObject armor2;
    public GameObject armor3;

    public bool isNormalGun;
    public bool isMiniGun;
    public bool isRocketGun;

    public Animator animator;

    //Plays at the start
    void Start()
    {
        //Makes it so that the player can shoot 
        canFire = true;
        //Make it so that the gun is not jammed
        jammed = false;
        collectedScrap = 0;
        armorLevel = 0;
        hasArmor = false;
    }

    //When an object enters the car's trigger
    void OnTriggerEnter(Collider collision)
    {
        //If the object is the left wall
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            //Makes it so that he cannot go further left
            atLeftEdge = true;

            //Resets the car rotation
            carBody.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        }
        //If the object is the right wall
        if (collision.gameObject.CompareTag("RightWall"))
        {
            //Makes it so that the car cannot go further right
            atRightEdge = true;

            //Resets the car rotation
            carBody.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        }
        //If the object is a missile
        if (collision.gameObject.CompareTag("Missile") || collision.gameObject.CompareTag("Obstacle"))
        {
            if (hasArmor == true)
            {
                Destroy(collision.gameObject);
                armorLevel--;
                //Disables the black box
                blackBox.GetComponent<Image>().enabled = false;
                //Disables the text
                pressText2.GetComponent<TMP_Text>().enabled = false;
                CinemachineShake.Instance.ShakeCamera(10f, .4f);
            }
            else
            {
                //Loads the Game Over scene
                SceneManager.LoadScene("GameOverScene");
            }
        }
        //If the object is a sccrap
        if (collision.gameObject.CompareTag("Scrap"))
        {
            //Destroy the scrap
            Destroy(collision.gameObject);
            if(armorLevel < 3)
            {
                armorLevel++;
            }
            
        }
    }

    //The update is triggered every frame
    void Update()
    {
        if (armorLevel > 0)
        {
            hasArmor = true;
        }
        else
        {
            hasArmor = false;
        }

        if (armorLevel == 3)
        {
            armor1.SetActive(true);
            armor2.SetActive(true);
            armor3.SetActive(true);
        }
        else if (armorLevel == 2)
        {
            armor1.SetActive(true);
            armor2.SetActive(true);
            armor3.SetActive(false);
        }
        else if (armorLevel == 1)
        {
            armor1.SetActive(true);
            armor2.SetActive(false);
            armor3.SetActive(false);
        }
        else
        {
            armor1.SetActive(false);
            armor2.SetActive(false);
            armor3.SetActive(false);
        }

        //Makes the wheels spin
        wheels[0].transform.Rotate(0, 0, -700 * Time.deltaTime);
        wheels[1].transform.Rotate(0, 0, 700 * Time.deltaTime);
        wheels[2].transform.Rotate(0, 0, -700 * Time.deltaTime);
        wheels[3].transform.Rotate(0, 0, 700 * Time.deltaTime);

        //If the player lets go of the A key
        if (Input.GetKeyUp(KeyCode.A))
        {
            //Resets the car rotation
            carBody.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        }
        //If the player lets go of the D key
        if (Input.GetKeyUp(KeyCode.D))
        {
            //Resets the car rotation
            carBody.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        }

        //Code that makes the text be what it has to be
        if (canFire == true)
        {
            coolDownText.text = "Can fire: Yes";
        }
        else if (jammed == true)
        {
            coolDownText.text = "Jammed!";
        }
        else
        {
            //Help
            coolDownText.text = "Can fire: No";
        }

        //Makes the text tell you what key you need to press in order to shoot down the missile
        pressText.text = "Press " + currentMissileNumber;

        //Makes the barrel look at the object it's supposed to follow (objectToShoot)
        barrel.transform.LookAt(objectToShoot);

        //Hello TO, welcome to my beutiful and very efficient code :)

        if(isNormalGun == true)
        {
            //This is basically code that lets makes you shoot the missile if you press the right button, and miss if you don't
            if (Input.GetKeyDown(KeyCode.Alpha1) && currentMissileNumber == 1 && canFire == true)
            {
                //Starts the coroutine that shoots
                StartCoroutine(ShootTurret());
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1) && currentMissileNumber != 1 && canFire == true)
            {
                StartCoroutine(Jammed());
            }
            //If the player presses the left mouse button
            if (Input.GetKeyDown(KeyCode.Alpha2) && currentMissileNumber == 2 && canFire == true)
            {
                //Starts the coroutine that shoots
                StartCoroutine(ShootTurret());
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && currentMissileNumber != 2 && canFire == true)
            {
                StartCoroutine(Jammed());
            }
            //If the player presses the left mouse button
            if (Input.GetKeyDown(KeyCode.Alpha3) && currentMissileNumber == 3 && canFire == true)
            {
                //Starts the coroutine that shoots
                StartCoroutine(ShootTurret());
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && currentMissileNumber != 3 && canFire == true)
            {
                StartCoroutine(Jammed());
            }
            //If the player presses the left mouse button
            if (Input.GetKeyDown(KeyCode.Alpha4) && currentMissileNumber == 4 && canFire == true)
            {
                //Starts the coroutine that shoots
                StartCoroutine(ShootTurret());
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && currentMissileNumber != 4 && canFire == true)
            {
                StartCoroutine(Jammed());
            }
        }
        if(isRocketGun == true)
        {
            //This is basically code that lets makes you shoot the missile if you press the right button, and miss if you don't
            if (Input.GetKeyDown(KeyCode.Alpha1) && currentMissileNumber == 1 && canFire == true)
            {
                //Starts the coroutine that shoots
                StartCoroutine(ShootRocket());
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1) && currentMissileNumber != 1 && canFire == true)
            {
                StartCoroutine(Jammed());
            }
            //If the player presses the left mouse button
            if (Input.GetKeyDown(KeyCode.Alpha2) && currentMissileNumber == 2 && canFire == true)
            {
                //Starts the coroutine that shoots
                StartCoroutine(ShootRocket());
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && currentMissileNumber != 2 && canFire == true)
            {
                StartCoroutine(Jammed());
            }
            //If the player presses the left mouse button
            if (Input.GetKeyDown(KeyCode.Alpha3) && currentMissileNumber == 3 && canFire == true)
            {
                //Starts the coroutine that shoots
                StartCoroutine(ShootRocket());
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && currentMissileNumber != 3 && canFire == true)
            {
                StartCoroutine(Jammed());
            }
            //If the player presses the left mouse button
            if (Input.GetKeyDown(KeyCode.Alpha4) && currentMissileNumber == 4 && canFire == true)
            {
                //Starts the coroutine that shoots
                StartCoroutine(ShootRocket());
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && currentMissileNumber != 4 && canFire == true)
            {
                StartCoroutine(Jammed());
            }
        }

        
        //End of gun code

        // Fills the list with all gameobjects that have the tag "Missile"
        allTargetsWithTag = GameObject.FindGameObjectsWithTag("Missile");

        //Assigns the first missile in the list as the closest missile
        closestMissile = allTargetsWithTag[0];

        //Gets the assigned number of the current missile
        currentMissileNumber = closestMissile.GetComponent<missileScript>().assignedNumber;
    }

    //The FixedUpdate is triggered independantly of the framerate
    void FixedUpdate()
    {
        //If the player presses the A key and isn't at the left edge
        if (Input.GetKey(KeyCode.A) && atLeftEdge == false)
        {
            //Rotates the car to the left
            Quaternion leftRotation = Quaternion.Euler(-90f, -15f, 0f);
            carBody.transform.rotation = leftRotation;

            //Moves the car to the left
            transform.Translate(Vector3.left * turnSpeed * Time.deltaTime);

            //If the player has touched the right side wall
            if (atRightEdge == true)
            {
                //Turns off the right edge bool (this means the player is able to move right)
                atRightEdge = false;
            }
        }
        //If the player presses the D key and isn't at the right edge
        if (Input.GetKey(KeyCode.D) && atRightEdge == false)
        {
            //Roates the car to the right
            Quaternion rightRotation = Quaternion.Euler(-90f, 15f, 0f);
            carBody.transform.rotation = rightRotation;

            //Moves the car to the right
            transform.Translate(Vector3.right * turnSpeed * Time.deltaTime);

            //If the player has touched the left side wall
            if (atLeftEdge == true)
            {
                //Turns off the left edge bool (this means the player is able to move left)
                atLeftEdge = false;
            }
        }
    }

    

    //A coroutine for shooting the turret
    IEnumerator ShootTurret()
    {
        //Makes it so that the player can't fire
        canFire = false;

        //Spawns in a bullet at the bulletSpawn location
        GameObject ball = Instantiate(Bullet, bulletSpawn1.transform.position, bulletSpawn1.transform.rotation);

        //Plays shoot sound
        gunSound.Play(0);

        ball.GetComponent<RocketScript>().objectToFollow = objectToShoot;

        //Waits for the cooldown
        yield return new WaitForSeconds(turretCooldown);

        //Makes it so that the player can fire
        canFire = true;
    }

    IEnumerator Jammed()
    {
        //Makes it impossible to fire
        canFire = false;
        //Makes the gun jammed
        jammed = true;

        //Plays the jammed sound
        jammingSound.Play(0);

        //Waits for the cooldown
        yield return new WaitForSeconds(turretCooldown);

        //Unjamms the gun
        jammed = false;

        //Makes it so that the player can fire
        canFire = true;
    }

    IEnumerator ShootRocket()
    {
        //Makes it so that the player can't fire
        canFire = false;

        //Spawns in the rocket
        GameObject fireTube = Instantiate(rocket, bulletSpawn2.transform.position, bulletSpawn2.transform.rotation);

        //Plays shoot sound
        gunSound.Play(0);

        fireTube.GetComponent<RocketScript>().objectToFollow = objectToShoot;

        animator.Play("CarRocketFire");

        yield return new WaitForSeconds(turretCooldown);

        //Makes it so that the player can fire
        canFire = true;
    }

}
