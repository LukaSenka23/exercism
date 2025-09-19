public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; set; }

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        var ordered = new SortedList<int, TreeBuildingRecord>();
        foreach (var record in records)
        {
            if (ordered.ContainsKey(record.RecordId))
                throw new ArgumentException();
            ordered.Add(record.RecordId,record);
        }

        records = ordered.Values;
        if (records.Count() == 0)
            throw new ArgumentException();
        
        var nodes = new Dictionary<int,Tree>();
        var previous = -1;
        Tree root = null;
        var expectedId = 0;
        foreach (var record in records)
        {
            if (record.RecordId != expectedId)
                throw new ArgumentException();

            if (record.RecordId == 0 && record.ParentId != 0)
                throw new ArgumentException();

            if (record.RecordId != 0 && record.ParentId >= record.RecordId)
                throw new ArgumentException();
            
            var nodeTree = new Tree{Id = record.RecordId,ParentId = record.ParentId,Children = new List<Tree>()};
            if (record.RecordId == 0)
            {
                if (root != null)
                    throw new ArgumentException();
                root = nodeTree;
            }
                
            nodes.Add(record.RecordId, nodeTree);
            expectedId++;
        }

        foreach (var node in nodes.Values)
        {
            if (node.Id != 0)
            {
                if (!nodes.ContainsKey(node.ParentId))
                    throw new ArgumentException();

                var parent = nodes[node.ParentId];// nalazenje roditelja
                parent.Children.Add(node);// spajanje deteta sa roditeljem
            }
        }

        return root;
    }
}