namespace day09;

public class Puzzle
{
    public static long Part1(string input)
    {
        var formattedFiles = ParseInput(input);
        
        var lastNumberIndex = formattedFiles.Count - 1;
        for (var i = 0; i < formattedFiles.Count; i++)
        {
            if (formattedFiles[i] != -1) continue;
            while (lastNumberIndex > i && formattedFiles[lastNumberIndex] == -1) lastNumberIndex--;

            if (lastNumberIndex <= i) continue;
            (formattedFiles[i], formattedFiles[lastNumberIndex]) = (formattedFiles[lastNumberIndex], formattedFiles[i]);

            lastNumberIndex--;
        }
        
        return formattedFiles.Select((id, index) => (id, index)).Where(x => x.id != -1).Sum(x => x.index * x.id);
    }

    private static List<long> ParseInput(string input)
    {
        var arr = input.ToCharArray();
        List<long> formatted = [];
        for (var i = 0; i < arr.Length; i++)
        {
            for (var j = 0; j < int.Parse(arr[i].ToString()); j++)
            {
                if (i % 2 == 0)
                {
                    var id = i / 2;
                    formatted.Add(id);
                }
                else
                {
                    formatted.Add(-1);
                }
            }
        }
        return formatted;
    } 
    public static long Part2(string input)
    {
        var formatted = ParseInput(input);
        
        var files = new List<(int, long)>(); //startIndex, size
        var spaceSizes = new List<(int, long)>(); //startIndex, size
        var currentIndex = 0;
        for (var i = 0; i < input.Length; i++)
        {
            int size;
            if (i % 2 == 0) //is file
            {
                size = int.Parse(input[i].ToString());
                files.Add((currentIndex, size));
            }
            else //is space
            {
                size = int.Parse(input[i].ToString());
                spaceSizes.Add((currentIndex, size));
            }
            currentIndex += size;
        }
        
        for (var i = files.Count - 1; i > 0; i--)
        {   
            for (var j = 0; j < spaceSizes.Count; j++)
            {   
                var fileSize = files[i].Item2;
                var fileStartIndex = files[i].Item1;
                var spaceSize = spaceSizes[j].Item2;
                var spaceStartIndex = spaceSizes[j].Item1;
                
                if (fileSize > spaceSize) continue;
                if (fileStartIndex < spaceStartIndex) break;
                for (var k = 0; k < fileSize; k++)
                {
                    (formatted[spaceStartIndex + k], formatted[fileStartIndex + k]) = (formatted[fileStartIndex + k], formatted[spaceStartIndex + k]);
                }
                var newSpaceSize = spaceSize - fileSize;
                if (newSpaceSize <= 0)
                {
                    spaceSizes.RemoveAt(j);
                }
                else
                {
                    spaceSizes[j] = (spaceStartIndex + (int)fileSize, newSpaceSize);
                }
                break;
            }
        }
     
        return formatted.Select((id, index) => (id, index)).Where(x => x.id != -1).Sum(x => x.index * x.id);
        
    }
}
