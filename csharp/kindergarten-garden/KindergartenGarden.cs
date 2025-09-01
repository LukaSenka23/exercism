public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    private string diagram;
    public KindergartenGarden(string diagram)
    {
        this.diagram = diagram;
    }

    public IEnumerable<Plant> Plants(string student)
    {
        string[] students = { "Alice", "Bob","Charlie", "David","Eve","Fred","Ginny","Harriet", "Ileana","Joseph","Kincaid","Larry" };
        var index = Array.IndexOf(students, student);
        int startpos = index * 2;// staratna poazicija mnozimo sa dva jer svaki studnet dobija po dve biljke u prvom redu po 2 i drugom = 4
        
        char[] row1 = diagram.Split('\n')[0].ToCharArray();
        char[] row2 = diagram.Split('\n')[1].ToCharArray();
        
        char[] plants = { 
            row1[startpos],    //prva biljka iz prvog reda
            row1[startpos + 1],//druga biljka iz prvog reda
            row2[startpos],   //prva biljka iz drugog reda
            row2[startpos + 1]// druga biljka iz drugog reda
        };
            
        foreach (var ch in plants)
        {
            diagram.Split('\n');
            
            if (ch == 'V') yield return Plant.Violets;
            if (ch == 'R') yield return Plant.Radishes;
            if (ch == 'C') yield return Plant.Clover;
            if (ch == 'G') yield return Plant.Grass;
        }
        
        
    }
}