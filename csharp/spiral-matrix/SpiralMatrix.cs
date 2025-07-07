public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        if (size < 0)
            return new int[0,0];
        
        int x = 0,y = 0;
        int[,] matrix = new int[size, size];
        int directionIndex = 0;
            
        var direction = new List<(int dx, int dy)>
        {
            (0,1),
            (1,0),
            (0,-1),
            (-1,0)
        };

        for (int count = 1;count <= size*size;count++)
        { 
            matrix[x, y] = count;
            
            var nextX = x + direction[directionIndex].dx;
            var nextY = y + direction[directionIndex].dy;
            if (nextX < 0 || nextX >= size || nextY < 0 || nextY >= size || matrix[nextX,nextY] != 0)
            {
                directionIndex = (directionIndex + 1) % direction.Count;
                nextX = x + direction[directionIndex].dx;
                nextY = y + direction[directionIndex].dy;
            }

            x = nextX;
            y = nextY;
        }

        return matrix;
    }
}
