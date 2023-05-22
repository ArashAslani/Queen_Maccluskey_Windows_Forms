using Queen_Maccluskey_Windows_Forms.Models;

namespace Queen_Maccluskey_Windows_Forms.Services
{
    public class QuinMaccluskeyAlgorithm
    {
        private static int numVariables;

        public string MQCalculator(string mintermsStr, string dontCaresStr, int numeOfVariblesInput)
        {
            //Get inputs
            numVariables = numeOfVariblesInput;

            List<int> mintermsList = mintermsStr.Split(',').Select(int.Parse).ToList();

            List<int> dontCaresList = new();
            if (String.IsNullOrWhiteSpace(dontCaresStr))
                dontCaresList = dontCaresStr.Split(',').Select(int.Parse).ToList();

            List<int> allMintermsInt = new();

            // Compare all Minterms
            if (dontCaresList.Count > 0)
                allMintermsInt.AddRange(dontCaresList);
            if (mintermsList.Count > 0)
                allMintermsInt.AddRange(mintermsList);

            //Declare minterms to Minterm class
            List<Minterm> allMinterms = new();

            foreach (var term in allMintermsInt)
            {
                var binary = Convert.ToString(term, 2).PadLeft(numVariables, '0');
                Minterm minterm = new(binary, term);
                allMinterms.Add(minterm);
            }

            List<Minterm> minterms = new();
            foreach (var term in mintermsList)
            {
                var binary = Convert.ToString(term, 2).PadLeft(numVariables, '0');
                Minterm minterm = new(binary, term);
                minterms.Add(minterm);
            }
        }
    }
}
