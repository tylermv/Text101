using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {cell, lock_2, mirror, sheets_0, lock_0, cell_mirror, cell_alarm, sheets_1, cell_code, bed_0, bed_1, alarm, lock_1, freedom};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.cell) 			{state_cell ();} 
		else if (myState == States.sheets_0) 	{state_sheets_0 ();} 
		else if (myState == States.mirror) 		{state_mirror ();}
		else if (myState == States.cell_mirror) {state_cell_mirror ();}
		else if (myState == States.lock_0) 		{state_lock_0 ();} 
		else if (myState == States.lock_1) 		{state_lock_1 ();} 
		else if (myState == States.lock_2) 		{state_lock_2 ();} 
		else if (myState == States.sheets_1) 	{state_sheets_1 ();} 
		else if (myState == States.bed_0) 		{state_bed_0 ();} 
		else if (myState == States.alarm) 		{state_alarm ();} 
		else if (myState == States.cell_alarm) 	{state_cell_alarm ();}
		else if (myState == States.bed_1) 		{state_bed_1 ();}
		else if (myState == States.cell_code) 	{state_cell_code ();}
		else if (myState == States.freedom) 	{state_freedom ();}
	
	}

	#region State handler methods
	void state_cell () {
		text.text = "You wake up in a prison cell, and you want to " +
					"escape. There are some dirty sheets on the bed, a " +
					"mirror on the wall, and the door " +
					"is locked from the outside.\n" +
					"Press S to view Sheets \n" +
					"Press L to view Lock \n" +
					"Press M to view Mirror";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			myState = States.mirror;
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_0;
		}
	}

	void state_sheets_0 () {
		text.text = "You rummage through the sheets. They feel damp. " +
					"You shiver as you think about sleeping in these sheets. You have to escape. You find nothing of importance.\n\n" +
					"Press R to Return to roaming your cell";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	void state_mirror () {
		text.text = "You see your reflection. There's dirt and dried blood on your face. You still don't " +
					"remember what happened. You notice the mirror is loose...\n\n" +
					"Press T to Take the Mirror.\n" +
					"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.cell_mirror;
			} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	void state_cell_mirror () {
		text.text = "With mirror in hand you take another look around your cell. " +
					"You notice the sheets look like they have strange spots on them.\n\n" +
					"Press S to take your mirror to the Sheets.\n" +
					"Press L to take your mirror to the Lock";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_1;
			} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1;
		}
	}
	void state_lock_0 () {
		text.text = "You try to inspect the lock but you can't see what kind of lock it is. If only " +
					"there was a way to see the front of the lock...\n\n" +
					"Press R to Return roaming your cell";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	void state_sheets_1 () {
		text.text = "On your way to the bed you drop the mirror. It shatters into many peices. " +
					"As you begin picking up the a glass, something catches your eye " +
					"from under the bed.\n\n" +
					"Press S to Slide under the bed\n" +
					"Press L to inspect the Lock";
		if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_1;
		} else if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.bed_0;
		}
	}
	void state_lock_1 () {
		text.text = "You take a look at the lock in the reflection of the mirror. " +
					"A notice a dirty keypad with the 4 dirtiest numbers being 3 - 4 - 7 - 8.\n" +
					"Press A to type in 3 - 4 - 7 - 8.\n" +
					"Press B to type in 7 - 4 -  3 - 8\n" +
					"Press C to type in 4 - 8 - 7 - 3\n" +
					"Press R to keep Roaming your cell";
		if (Input.GetKeyDown (KeyCode.A)) {
			myState = States.alarm;
		} else if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.alarm; 
		} else if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.freedom;
		} else if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}
	void state_freedom () {
		text.text = "You hear a click and open the door. " +
					"Congratulations, you've escaped to freedom! \n\n" +
					"Press P to Play again. ";
		if (Input.GetKeyDown (KeyCode.P)) {
			myState = States.cell;
		} 
	}
	void state_bed_0 () {
		text.text = "You slide under the bed. As you stare up at the bottom of the bed you notice someone has carved out the numbers 4 - 8 - 7 - 3.\n\n" +
					"Press L to head to the lock\n" +
					"Press R to keep roaming your cell";
		if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_2;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_code;
		}
	}
	void state_alarm () {
		text.text = "You finish typing in the code. Suddenly an alarm sounds! BEEEEP! BEEEEP! \n\n" +
					"Press S to quickly Slide under the bed\n" +
					"Press R to keep Roaming your cell";
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.bed_1;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_alarm;
		}
	}
	void state_cell_alarm () {
		text.text = "The guard has caught you trying to tamper with the lock. He decides to throw you in solitary confinement \n\n" +
					"Game Over\n\n" +
					"Press P to Play again";
		if (Input.GetKeyDown (KeyCode.P)) {
			myState = States.cell;
		}
	}
	void state_bed_1 () {
		text.text = "You quickly slide under the bed. The guard notices you cowaring there. Hey! Don't do that " +
		"again, he yells. As you stare up at the bottom of the bed you notice the numbers 4 - 8 - 7 - 3 " +
		"have been carved out by someone.\n" +
		"Press L to quietly head back to the lock\n";
		if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_2;
		}
	}
	void state_cell_code () {
		text.text = "You shiver. The cell is cold and damp. You watch as a rat scurries down the hall. " +
			"You must escape. \n\n" +
			"Press L to head to the Lock\n";
		if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_2;
		}
	}
	void state_lock_2 () {
		text.text = "You take a look at the lock in the reflection of the mirror. " +
			"A notice a dirty keypad with the 4 dirtiest numbers being 3 - 4 - 7 - 8.\n" +
			"Press A to type in 3 - 4 - 7 - 8.\n" +
			"Press B to type in 7 - 4 -  3 - 8\n" +
			"Press C to type in 4 - 8 - 7 - 3\n" +
			"Press R to keep Roaming your cell";
		if (Input.GetKeyDown (KeyCode.A)) {
			myState = States.alarm;
		} else if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.alarm; 
		} else if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.freedom;
		} else if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_code;
		}
	}
	#endregion
}