public static class Tournament
{
    public static void Tally(Stream inStream, Stream outStream)
    {
        Dictionary<string, Team> teams = new();

        using var reader = new StreamReader(inStream);

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var split = line.Split(";");
            if (split.Length != 3)
                continue;

            var team1 = split[0];
            var team2 = split[1];
            var result = split[2];

            if (!teams.ContainsKey(team1))
                teams[team1] = new Team(team1);
            if (!teams.ContainsKey(team2))
                teams[team2] = new Team(team2);

            if (result == "win")
            {
                teams[team1].Wins++;
                teams[team2].Losses++;
            }
            else if (result == "loss")
            {
                teams[team1].Losses++;
                teams[team2].Wins++;
            }
            else if (result == "draw")
            {
                teams[team1].Draws++;
                teams[team2].Draws++;
            }
        }

        using var writer = new StreamWriter(outStream);
        string[] header = [ $"{"Team",-31}| MP |  W |  D |  L |  P"];

        var order = teams.Values.OrderByDescending(t => t.Points).ThenBy(t => t.Name);
        var lines = string.Join('\n', header.Concat(order.Select(team =>
                $"{team.Name,-31}| {team.Matches,2} | {team.Wins,2} | {team.Draws,2} | {team.Losses,2} | {team.Points,2}")
            .ToArray()));
        writer.Write(lines);
    }
}

public class Team(string name)
{
    public string Name { get; } = name;
    public int Wins { get; set; }
    public int Draws { get; set; }
    public int Losses { get; set; }

    public int Matches => Wins + Draws + Losses;
    public int Points => Wins * 3 + Draws;
}