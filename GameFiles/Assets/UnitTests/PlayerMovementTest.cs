using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

// Tests that player sprite can be controlled properly
public class PlayerMovementTest
{

    [Test]
    public void CorrectPlayerVelocity()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        PlayerMovementInput input = new PlayerMovementInput();
        movement.InitializeRigidBody();

        float inputX = 20;
        float inputY = 20;

        movement.UpdateVelocity(input.UpdateVelocity(inputX, inputY, movement.GetSpeed()));
        
        Vector2 calculatedFinal;
        calculatedFinal.x = inputX * movement.GetSpeed();
        calculatedFinal.y = inputY * movement.GetSpeed();

        Vector2 playerFinal;
        
        playerFinal = movement.GetRigidBody().velocity;

        Assert.AreEqual(playerFinal.x, calculatedFinal.x);
        Assert.AreEqual(playerFinal.y, calculatedFinal.y);

    }

}