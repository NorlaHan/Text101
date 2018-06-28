using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {
		cell, cell2, 
		sheets_0, mirror, lock_0, 
		sheets_1, cell_mirror, lock_1, 
		corridor_0,corridor_1 ,corridor_2 ,corridor_3, 
		stairs_0, stairs_1, stairs_2,
		closet_door, closet_door2, in_closet, 
		floor, courtyard, freedom
	};
	private States myState ;

	// Use this for initialization
	void Start () {
		//text.text = "Hello world";
		myState = States.cell;
		cell ();
	}
	
	// Update is called once per frame
	void Update () {
		if 		(myState == States.cell) {cell ();}
		else if (myState == States.sheets_0) {sheets_0 ();}
		else if (myState == States.mirror) {mirror ();}
		else if (myState == States.lock_0) {lock_0 ();}
		else if (myState == States.sheets_1) {sheets_1 ();}
		else if (myState == States.cell_mirror) {cell_mirror ();}
		else if (myState == States.lock_1) {lock_1 ();}
		else if (myState == States.freedom) {freedom ();}
		else if (myState == States.cell2) {cell2 ();}
		else if (myState == States.corridor_0) {corridor_0 ();}
		else if (myState == States.corridor_1) {corridor_1 ();}
		else if (myState == States.corridor_2) {corridor_2 ();}
		else if (myState == States.corridor_3) {corridor_3 ();}
		else if (myState == States.stairs_0) {stairs_0 ();}
		else if (myState == States.stairs_1) {stairs_1 ();}
		else if (myState == States.stairs_2) {stairs_2 ();}
		else if (myState == States.closet_door) {closet_door ();}
		else if (myState == States.closet_door2) {closet_door2 ();}
		else if (myState == States.in_closet) {in_closet ();}
		else if (myState == States.floor) {floor ();}
		else if (myState == States.courtyard) {courtyard ();}
	}

	#region state handler methods
	void cell () {
		text.text = ("You are a prisoner and you are in a cell. \n" +
					"The only notable items are sheets on a bed.\n" +
					"a mirror on the wall, \n" +
					"and a locked door.\n\n" +

					"Press [S] to view Sheet, [M] to view Mirror and [L] to view Lock");
		if 		(Input.GetKeyDown (KeyCode.S)) {myState = States.sheets_0;} 
		else if (Input.GetKeyDown (KeyCode.M)) {myState = States.mirror;} 
		else if (Input.GetKeyDown (KeyCode.L)) {myState = States.lock_0;}
	}

	void sheets_0 () {
		text.text = ("You look at the sheets, and it stinks.\n\n" +

					"Press [R] to return to cell.\n");
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}

	void mirror () {
		text.text = ("You walk toward the mirror, and it looks a little strange.\n" +
					"You hesitate wheather to take the mirror...\n\n" +

					"Press [R] to return to cell, or press [T] to tke the mirror.\n");
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
		else if (Input.GetKeyDown(KeyCode.T)) {myState = States.cell_mirror;}
	}
	void lock_0 () {
		text.text = ("You look at the cell lock.\n" +
					" without luck. It's LOCK.\n\n" +
					"Press [R] to return to cell.\n");
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}

	void cell_mirror ()
	{
		text.text = ("After a blinding light. You find yourself unconcious, \n" +
					"How long had you passed out? You can't tell either.\n" +
					"But soon you notice that something isn't right.\n" +
					"Everything are on the opposite side.\n" +
					"You wonder...may it be the mirror world?\n\n" +

					"Press [Y] to Return the mirror, [S] to view Sheets and [L] to view Lock.");	
		if 		(Input.GetKeyDown (KeyCode.S)) {myState = States.sheets_1;} 
		else if (Input.GetKeyDown (KeyCode.L)) {myState = States.lock_1;} 
		else if (Input.GetKeyDown (KeyCode.Y)) {myState = States.cell2;}
	}

	void cell2 () {
		text.text = ("You find yourself in the cell. \n" +
					"The only thing changes is taht the orientation is back again.\n" +
					"The only notable items are sheets on a bed (a red herring at this stage), \n" +
					"a mirror on the wall (used to open the lock), \n" +
					"and a locked door which can only be opened with the aid of the mirror.\n\n" +

					"Press [S] to view Sheet, [M] to view Mirror and [L] to view Lock");
		if 		(Input.GetKeyDown (KeyCode.S)) {myState = States.sheets_0;} 
		else if (Input.GetKeyDown (KeyCode.M)) {myState = States.mirror;} 
		else if (Input.GetKeyDown (KeyCode.L)) {myState = States.lock_0;}
	}

	void sheets_1 () {
		text.text = ("You look at the sheets. It looks almost identical! \n" +
					"Except the hole at the right is at the left.\n" +
					"And it still stinks...\n\n"+

					"Press [R] to Return to the cell.");
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.cell_mirror;}

	}

	void lock_1 () {
		text.text = ("You look at the lock.\n"+
					"Due to it isomatic shape. You can't tell the differences before.\n" +
					"You can't open it at the other side. should you try to open it again?\n\n" +

					"Press [R] to return to the cell, press [O] to Open the lock.");	
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.cell_mirror;}
		else if (Input.GetKeyDown(KeyCode.O)) {myState = States.corridor_0;}
	}

	void corridor_0 () {
		text.text = ("The lock just opened. You are free from the cell!\n" +
					"You feel joy for a while, but soon you realize that you are still in a prison anyway.\n" +
					"You carefully observe around. Looks like you are in a corridor.\n" +
					"It is rather empty but a closet and a stairs in the end.\n" +
					"Meanwhile you noticed that there is something on the ground.\n\n" +

					"Press [C] to search the Closet, [S] to climb the stairs and [F] to search the floor.");
		if 		(Input.GetKeyDown(KeyCode.C)) {myState = States.closet_door;}
		else if (Input.GetKeyDown(KeyCode.S)) {myState = States.stairs_0;}
		else if (Input.GetKeyDown(KeyCode.F)) {myState = States.floor;}
	}

	void corridor_1 () {
		text.text = ("The corridor is still the same, but you now have a hairclip in your hand.\n" +
					"Nothing special but a closet and a stairs in the end.\n\n" +

					"Press [C] to search to closet, [S] to climb up the Stairs and [D] to drop the hairclip.");
		if 		(Input.GetKeyDown(KeyCode.C)) {myState = States.closet_door2;}
		else if (Input.GetKeyDown(KeyCode.S)) {myState = States.stairs_1;}
		else if (Input.GetKeyDown(KeyCode.D)) {myState = States.corridor_0;}
	}

	void corridor_2 () {
		text.text = ("You Return to the corridor.\n" + 
					"The closet is opened now and the stairs is in the end.\n\n" +
					"Press [S] to climb up the stairs, [C] to go back to the Closet.");
		if 		(Input.GetKeyDown(KeyCode.S)) {myState = States.stairs_2;}
		else if (Input.GetKeyDown(KeyCode.C)) {myState = States.in_closet;}
	}

	void corridor_3 () {
		text.text = ("You are dressing like a cleaner standing in the corridor.\n" +
					"What should you do?\n\n" +

					"Press [U] to to Undress the cleaner suit, [S] to walk to the courtyard.");
		if 		(Input.GetKeyDown(KeyCode.U)) {myState = States.in_closet;}
		else if (Input.GetKeyDown(KeyCode.S)) {myState = States.courtyard;}
	}

	void stairs_0 () {
		text.text = ("You climb up the stairs and find nothing.\n"+
					"You wonder if this is a place you can hide?\n"+
					"But the blood stain on the floor stop you thinking of it.\n" +
					"For obvious reason.\n\n" + 

					"Press [R] to Return to the corridor.");
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_0;}
	}


	void stairs_1 () {
		text.text = ("You climb up to the stairs with the hairclip in your hand.\n" +
					"Nothing happened, and there is nothing you can think of what to do.\n" +
					"The blood stain on the ground gives you the creeps.\n\n" +

					"Press [R] to return the corridor.");
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_1;}
	}


	void stairs_2 () {
		text.text = ("You climb up the stairs and find nothing.\n"+
					"There is nothing you can think of what to do.\n" +
					"The blood stain on the ground gives you the creeps.\n\n" +
					"Press [R] to return the corridor.");
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_2;}
	}

	void closet_door () {
		text.text = ("You are in front of the closet.\n" +
					"You tried to open it, but it's locked.\n" + 
					"Obviously you can break the door, but that will make a lot of noise.\n" +
					"That is too risky.\n\n" +

					"Press [R] to Return to the corridor.");
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_0;}
	}

	void closet_door2 () {
		text.text = ("You are in front of the closet.\n" +
					"It is still locked, but this time you have a hair clip in your hand.\n" + 
					"Normally it's hard to imagine a closet will have any alarm system.\n" +
					"But this is no normal situation. Your life depends on it.\n\n" +

					"Press [R] to Return to the corridor, [P] to Pick the closet lock.");
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_1;}
		else if (Input.GetKeyDown(KeyCode.P)) {myState = States.in_closet;}
	}

	void in_closet () {
		text.text = ("The door is open, and nothing bad happens.\n" +
					"But the hairclip stuck in the keyhole.\n" +
					"There is only a suit of cleaner outfit in the closet.\n" +
					"Why should anyone ever want to lock this kind of stuff up?\n\n" +

					"Press [R] to Return to corridor and [D] to Dress up like a cleaner.");
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_2;}
		else if (Input.GetKeyDown(KeyCode.D)) {myState = States.corridor_3;}
	}


	void floor () {
		text.text = ("You look around the floor, and there is a hairclip.\n" +
					"You wonder why a MALE prison will have such thing.\n" +
					"Maybe you can make good use of it, or it may triggers some sort of metal detection.\n\n" +
					"Press [R] to Return to the corridor or [H] to pick up the Hairclip.");
		if 		(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_0;}
		else if (Input.GetKeyDown(KeyCode.H)) {myState = States.corridor_1;}
	}


	void courtyard () {
		text.text = ("You dress like a cleaner, thus nobody is awear of who you are.\n" +
					"You simply walk through a bunch of guards and exit the prison.\n\n" +

					"Press [F] to finish the game");
		if 		(Input.GetKeyDown(KeyCode.F)) {myState = States.freedom;}
	}


	void freedom () {
		text.text = ("You are free!\n" +
					"Time to find the next victim.\n\n" +
					"Look what have you done?\n" +
					"Set a prisoner free to the society?\n" +
					"He is there for a reason you dummy!");

	}
	#endregion
}
