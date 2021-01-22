[System.Serializable]
public class Ball
{
/*  
 *  ballId determines the color of the ball. 0 = Red, 1 = Green, 2 = Blue. 
 *  In the future, if the game were to have a large number of different colors, 
 *  we can utilize an enum as a new field and json variable for the programmers to easily indicate 
 *  the color of the ball without mentall connecting an integer to a color. 
 *  
 *  name is the name of the Ball. 
 *  
 *  colorHex is the color of the ball in a hexadecimal code format.
*/
    public int ballId;
    public string name;
    public string colorHex;
}
