using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Text healthText;                                     // Reference to UI health display

    PlayerMovement playerMovement;                              // Reference to the player's movement.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.

    GameObject sceneControlObject;
    SceneControl control;
    public bool inTest = false;                                 // Used for Unit Tests

    void Awake()
    {
        // Setting up the references.
        InitializeMovement();

        //Initialize Scene Control
        sceneControlObject = GameObject.Find("SceneControlObject");
        control = sceneControlObject.GetComponent<SceneControl>();
    }

    private void Start()
    {
        // Set the initial health of the player.
        currentHealth = startingHealth;

        healthSlider.value = currentHealth;

        updateText(currentHealth, startingHealth);
    }


    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {

        }
        else
        {

        }

        // Reset the damaged flag.
        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Add amount to total damage taken
        Variables.PlayerDamageTaken += amount;
        Debug.Log("PlayerDamageTaken: " + Variables.PlayerDamageTaken);

       

        //check overheal
        if (currentHealth >= startingHealth)
        {
            currentHealth = startingHealth;
        }

        // Update UI to the current health.
        healthSlider.value = currentHealth;
        updateText(currentHealth, startingHealth);

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }

        
    }

    public void updateText(int currentHealth, int totalHealth)
    {
        healthText.text = ("HP: " + currentHealth + " / " + totalHealth);
    }

    public bool isAlive()
    {
        return !isDead;
    }

    public void InitializeMovement()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Turn off the movement scripts.
        playerMovement.enabled = false;

        //Swap to Game Over Scene
        if(!inTest)
            control.LoadGameScene(3);

    }

    public void wakeUp()
    {
        Awake();
    }
}

