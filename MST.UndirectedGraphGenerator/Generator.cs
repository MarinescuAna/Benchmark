namespace MST.UndirectedGraphGenerator
{
    internal sealed class Generator : IDisposable
    {
        private int _noVertices;
        private int _maxRangeWeight;
        private StreamWriter? _streamWriter;

        internal Generator(string[] args)
        {
            if (args.Length != 3)
            {
                throw new ArgumentException("Arguments are missing: (outputPath noVertices maxWeightValue)!!");
            }

            try
            {
                _streamWriter = new StreamWriter(args[0]);
            }
            catch
            {
                throw new Exception("Invalid file path!");
            }


            if (!int.TryParse(args[1], out _noVertices) || !int.TryParse(args[2], out _maxRangeWeight))
            {
                throw new ArgumentException("Invalid arguments!!");
            }
        }

        internal void GenerateAdjacencyMatrix()
        {
            // Initialize the result matrix
            var matrixResult = new int[_noVertices][];
            InitResultMatrix(matrixResult);

            // Generate the matrix
            for (var line = 1; line < _noVertices; line++)
            {
                for (var col = 0; col < line; col++)
                {
                    // Main diagonal have all the values equals with zero
                    // Generate other values
                    matrixResult[line][col] = matrixResult[col][line] = GenerateValue();
                }
            }

            // Print the results into the output file
            PrintResult(matrixResult);
        }
        private void PrintResult(int[][] matrix)
        {
            for (var line = 0; line < _noVertices; line++)
            {
                for (var col = 0; col < _noVertices; col++)
                {
                    _streamWriter!.Write($"{matrix[line][col]} ");
                }
                _streamWriter!.WriteLine();
            }

            _streamWriter!.Close();
        }
        private void InitResultMatrix(int[][] matrix)
        {
            for (var line = 0; line < _noVertices; line++)
            {
                matrix[line] = new int[_noVertices];
            }
        }
        private int GenerateValue() =>
            new Random().Next() % 2 == 0 ? 0 : new Random().Next(_maxRangeWeight);

        public void Dispose()
        {
            _streamWriter!.Dispose();
        }
    }
}
