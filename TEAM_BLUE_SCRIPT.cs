using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------- CHANGE THIS NAME HERE -------
public class TEAM_BLUE_SCRIPT : MonoBehaviour
{
    //---------- CHANGE THIS NAME HERE -------
    public static TEAM_BLUE_SCRIPT AddYourselfTo(GameObject host) {
        //---------- CHANGE THIS NAME HERE -------
        return host.AddComponent<TEAM_BLUE_SCRIPT>();
    }

    /*vvvv DO NOT MODIFY vvvvv*/
    [SerializeField]
    public CharacterScript character1;
    [SerializeField]
    public CharacterScript character2;
    [SerializeField]
    public CharacterScript character3; 

  
        int deathCount1 = 0;
        int deathCount2 = 0;
        int deathCount3 = 0;
        bool deathFlag = false;

    void Start()
    {
        character1 = transform.Find("Character1").gameObject.GetComponent<CharacterScript>();
        character2 = transform.Find("Character2").gameObject.GetComponent<CharacterScript>();
        character3 = transform.Find("Character3").gameObject.GetComponent<CharacterScript>();
    }
    /*^^^^ DO NOT MODIFY ^^^^*/


    /* Your code below this line */
    // Update() is called every frame

    public static Character characterInfo1 = new Character();
    public static Character characterInfo2 = new Character();
    public static Character characterInfo3 = new Character();
    Character[] characterArray = { characterInfo1, characterInfo2, characterInfo3 };
    void Update()
	{
        characterInfo1.setMovementFlag(true);
        characterInfo2.setMovementFlag(true);
        characterInfo3.setMovementFlag(true);
        characterInfo1.health = character1.getHP();
        characterInfo2.health = character2.getHP();
        characterInfo3.health = character3.getHP();
        // Debug.Log(character1.name + " " + characte);
        character1.FaceClosestWaypoint();
        character1.SetFacing(new Vector3(-8f, 0, 8f));
        character2.FaceClosestWaypoint();
        character3.FaceClosestWaypoint();
        characterInfo1.setCharacterMovement(character1);
        characterInfo2.setCharacterMovement(character2);
        characterInfo3.setCharacterMovement(character3);

       for (int i = 0; i < 3; i++)
        {
            if(characterArray[i].health <= 0 && !characterArray[i].deathFlag)
            {
                characterArray[i].updateDeathFlag(true);
                characterArray[i].setDeathCount();
            }
            if (characterArray[i].health >= 100 && characterArray[i].deathFlag)
            {
                characterArray[i].updateDeathFlag(false);                
            }
            if(characterArray[i].getDeathCount() > 1 && characterArray[i].movementFlag)
            {
                characterArray[i].changeMovement((i+1)%3);
                characterArray[i].movementFlag = false;
            }
            if (characterArray[i].getDeathCount() <= 1 && characterArray[i].movementFlag)
            {
                characterArray[i].changeMovement(i);
                characterArray[i].movementFlag = false;
            }
        } 

   

         
        if (character1.getZone() == zone.BlueBase || character1.getZone() == zone.RedBase)
            character1.setLoadout(loadout.MEDIUM);
        if (character2.getZone() == zone.BlueBase || character2.getZone() == zone.RedBase)
            character2.setLoadout(loadout.MEDIUM);
        if (character2.getZone() == zone.BlueBase || character2.getZone() == zone.RedBase)
            character3.setLoadout(loadout.MEDIUM);

           /*
            character1.MoveChar(new Vector3());
            character2.MoveChar(new Vector3(40.0f, 1.5f, 24.0f));
            character3.MoveChar(new Vector3(-40.0f, 1.5f, -24.0f));*/
      



    } 
}

public class Character
{
    public int deathCount;
    public bool deathFlag;
    public int health = 0;
    public CharacterScript characterMovement;
    public bool movementFlag;
    float x = -40.0f, y = 1.5f,z = -24.0f;
    
        public void setDeathCount()
    {
        deathCount++;
    }
    public void setMovementFlag(bool newMovementFlag)
    {
        movementFlag = newMovementFlag;
    }
    public bool getMovementFlag()
    {
        return movementFlag;
    }

    public void setCharacterMovement(CharacterScript movement)
    {
        characterMovement = movement;
    }
    public void changeMovement(int counter)
    {        
        if(counter == 0)
        characterMovement.MoveChar(new Vector3(x, y ,z ));

        if(counter == 1)
        characterMovement.MoveChar(new Vector3(-x, y, -z));

        if (counter == 2)
        characterMovement.MoveChar(new Vector3());
    }
     public int getDeathCount()
    {
        return deathCount;
    }
    public void updateDeathFlag(bool deathFlagValue)
    {
        deathFlag = deathFlagValue;
    }
} 
