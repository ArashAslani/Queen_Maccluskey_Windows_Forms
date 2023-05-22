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

            List<Minterm> pis = FindPrimeIplicants(allMinterms, numVariables);



        }

        public static int CharacterCounter(char character, string baseStr)
        {
            return baseStr.Count(c => c == character);
        }

        static List<Minterm> FindPrimeIplicants(List<Minterm> allMinterms, int numberOfVaribles)
        {
            List<List<Minterm>> groups = new();

            int maxOnesCount = allMinterms.Max(m => m.Binary.Count(c => c == '1'));

            for (int i = 0; i <= maxOnesCount; i++)
            {
                groups.Add(new List<Minterm>());
            }

            foreach (var term in allMinterms)
            {
                int onesCount = term.GroupNumber;
                groups[onesCount].Add(term);
            }

            List<Minterm> allPis = new();
            List<Minterm> pis = allMinterms;
            int newMintermsCount;
            int loopBreaker = 1;

            do
            {
                newMintermsCount = 0;
                loopBreaker--;

                for (int i = 0; i < groups.Count - 1; i++)
                {
                    List<string> currentGroup = groups[i].Select(b => b.Binary).ToList();
                    List<string> nextGroup = groups[i + 1].Select(b => b.Binary).ToList();

                    //Move on current group mintemrs
                    for (int j = 0; j < currentGroup.Count; j++)
                    {
                        //Move on next group mintemrs
                        for (int k = 0; k < nextGroup.Count; k++)
                        {
                            int differingIndex = -1;
                            //Move on binaryCode
                            for (int l = 0; l < numberOfVaribles; l++)
                            {
                                if (currentGroup[j][l] != nextGroup[k][l])
                                {
                                    if (differingIndex == -1)
                                        differingIndex = l;
                                    else
                                    {
                                        differingIndex = -1;
                                        break;
                                    }
                                }
                            }

                            if (differingIndex != -1)
                            {
                                //Genarate new minterm
                                string newMintermBinary = currentGroup[j].Remove(differingIndex, 1).Insert(differingIndex, "-");
                                Minterm newMinterm = new(newMintermBinary);

                                //Set combined minterm
                                int onesCountMinterm1 = CharacterCounter('1', currentGroup[j]);
                                int onesCountMinterm2 = CharacterCounter('1', nextGroup[k]);

                                Minterm? mintem1 = groups[onesCountMinterm1].FirstOrDefault(m => m.Binary == currentGroup[j]);
                                Minterm? mintem2 = groups[onesCountMinterm2].FirstOrDefault(m => m.Binary == nextGroup[k]);

                                int dashCountMinterm1 = CharacterCounter('-', currentGroup[j]);
                                int dashCountMinterm2 = CharacterCounter('-', nextGroup[k]);

                                if ((mintem1 != null) && (mintem2 != null) && dashCountMinterm1 == dashCountMinterm2)
                                {
                                    mintem1.SetCombinedMinterm();
                                    mintem2.SetCombinedMinterm();
                                }

                                //Add new member
                                allPis.Add(newMinterm);

                                if (!pis.Select(b => b.Binary).Contains(newMinterm.Binary))
                                {
                                    pis.Add(newMinterm);
                                    //Set numbers to break
                                    newMintermsCount++;
                                    loopBreaker = newMintermsCount;
                                }
                            }
                        }
                    }

                    if (allPis.Count > 0)
                    {
                        foreach (var term in allPis)
                        {
                            int onesCount = term.GroupNumber;
                            if (!groups[onesCount].Select(b => b.Binary).Contains(term.Binary))
                                groups[onesCount].Add(term);
                        }
                    }
                }

            } while (newMintermsCount == loopBreaker);

            List<Minterm> pimeImplicants = pis.Where(m => m.IsCombined == false).ToList();

            return pimeImplicants;
        }
    }
}
