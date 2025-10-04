public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    private Direction direction;
    private int x;
    private int y;
    
    public RobotSimulator(Direction direction, int x, int y)
    {
        this.direction = direction;
        this.x = x;
        this.y = y;
    }

    public Direction Direction
    {
        get
        {
            return direction;
        }
    }

    public int X
    {
        get
        {
            return x;
        }
    }

    public int Y
    {
        get
        {
            return y;
        }
    }

    public void Move(string instructions)
    {
        foreach (var instruction in instructions)
        {
            if (instruction == 'R')
            {
                 if (direction == Direction.North) direction = Direction.East;
                 else if (direction == Direction.East) direction = Direction.South;
                else if (direction == Direction.South) direction = Direction.West;
                else if (direction == Direction.West) direction = Direction.North;
            }

            else if (instruction == 'L')
            {
                if (direction == Direction.North) direction = Direction.West;
                else if (direction == Direction.West) direction = Direction.South;
                else if (direction == Direction.South) direction = Direction.East;
                else if (direction == Direction.East) direction = Direction.North;
            }
            else if (instruction == 'A')
            {
                if (direction == Direction.North) y++;
                else if (direction == Direction.South) y--;
                else if (direction == Direction.East) x++;
                else if (direction == Direction.West) x--;
            }
        }
    }
}