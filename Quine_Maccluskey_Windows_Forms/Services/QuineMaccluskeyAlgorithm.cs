using Quine_Maccluskey_Windows_Forms.Models;
using System.Text;

namespace Quine_Maccluskey_Windows_Forms.Services
{
    public class QuineMaccluskeyAlgorithm 
    {
        private static int numVariables;

        public string MQCalculator(string mintermsStr, string dontCaresStr, int numeberOfVariblesInput)
        {
            //Get inputs
            numVariables = numeberOfVariblesInput;
            if(numVariables > 26 || numVariables == 0)
            {
                return "Number of varibles is out of range.\n\t 0 < numeber of varibles Input < 26";
            }

            List<int> mintermsList = new();
            try
            {
                mintermsList = mintermsStr.Split(',').Select(int.Parse).ToList();
            }catch(Exception ex)
            {
                return $"\tThe entered minterm does not have the correct format,\n\t please enter the desired value in this format: 1,2,4,9,4 \n\n ";
            }
            
            int maxMintermValue = Convert.ToInt32(Math.Pow(2, numVariables));
            foreach(int m in mintermsList)
            {
                if(m > maxMintermValue -1 || m < 0)
                    return $"Minterm Value is out of range;  0 < minterms < {maxMintermValue}";
            }

            List<int> dontCaresList = new();
            if (!String.IsNullOrWhiteSpace(dontCaresStr))
            {
                try
                {
                    dontCaresList = dontCaresStr.Split(',').Select(int.Parse).ToList();
                }
                catch (Exception ex)
                {
                    return $"\tThe entered minterm does not have the correct format,\n\t please enter the desired value in this format: 1,2,4,9,4 \n\n ";
                }
                foreach (int m in dontCaresList)
                {
                    if (m > maxMintermValue - 1 || m < 0)
                        return $"Minterm Value is out of range;  0 < don't cares < {maxMintermValue}";
                }
            }
           
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
            List<Minterm> epis = FindEssentialPrimeImplicants(minterms, pis);

            List<Minterm> simplifiedTerms = Simplify(pis, epis, minterms);


            string SimplifiedExpressionStr = GetSimplifiedExpression(simplifiedTerms);

            string result = ResultCreator(pis, epis, SimplifiedExpressionStr);


            return result;
        }

        static int CharacterCounter(char character, string baseStr)
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


        static List<Minterm> FindEssentialPrimeImplicants(List<Minterm> minterms, List<Minterm> primeImplicants)
        {
            List<Minterm> essentialPrimeImplicants = new();

            // Iterate through the minterms
            foreach (Minterm minterm in minterms)
            {
                int count = 0;
                Minterm coveredMinterm = null;

                // Check if the minterm is covered by only one prime implicant
                foreach (Minterm primeImplicant in primeImplicants)
                {
                    if (IsMintermCovered(primeImplicant, minterm))
                    {
                        count++;
                        coveredMinterm = primeImplicant;
                    }
                }

                // If the minterm is covered by only one prime implicant, add it as essential
                if (count == 1 && !essentialPrimeImplicants.Contains(coveredMinterm))
                {
                    essentialPrimeImplicants.Add(coveredMinterm);
                }
            }

            return essentialPrimeImplicants;
        }

        static bool IsMintermCovered(Minterm primeImplicant, Minterm minterm)
        {
            // Check if the prime implicant covers the minterm
            foreach (int combinedTerm in primeImplicant.CombinedTerms)
            {
                if (minterm.CombinedTerms.Contains(combinedTerm))
                {
                    return true;
                }
            }

            return false;
        }


        static List<Minterm> Simplify(List<Minterm> pis, List<Minterm> epis, List<Minterm> minterms)
        {
            List<Minterm> pimeImplicants = new(pis);
            List<Minterm> essentialIPrimemplicants = new(epis);
            List<Minterm> mintremsList = new(minterms);
            // Simplify using the essential prime implicants
            List<Minterm> simplifiedTerms = essentialIPrimemplicants.Select(epi => epi).ToList();

            // Remove minterms covered by essential prime implicants
            mintremsList.RemoveAll(m => essentialIPrimemplicants.Any(epi => epi.CombinedTerms.Any(term => term == m.Decimal)));
            pimeImplicants.RemoveAll(epi => essentialIPrimemplicants.Any(term => term.Binary == epi.Binary));

            // Iterate through the PIs and calculate the priority based on the number of combined minterms
            foreach (Minterm pi in pimeImplicants)
            {
                int priority = 0;

                // Count the number of combined minterms that have the correct value
                foreach (int combinedMinterm in pi.CombinedTerms)
                {
                    if (mintremsList.Select(x => x.Decimal).Contains(combinedMinterm))
                    {
                        priority++;
                    }
                }

                // Assign the priority to the PI
                pi.SetPriority(priority);
            }

            // Sort the PIs based on priority
            pimeImplicants = pimeImplicants.OrderByDescending(pi => pi.Priority).ToList();


            List<Minterm> coveredMinterms = new();
            // Set the remaining prime implicants
            foreach (Minterm primeImplicant in pimeImplicants)
            {
                if (mintremsList.Count == 0)
                    break;

                // Check if the prime implicant covers any remaining minterms
                coveredMinterms = mintremsList
                    .Where(m => IsMintermCovered(primeImplicant, m))
                    .ToList();

                if (coveredMinterms.Count > 0)
                {
                    simplifiedTerms.Add(primeImplicant);
                    mintremsList.RemoveAll(m => primeImplicant.CombinedTerms.Any(term => term == m.Decimal));
                }
            }

            // Sort the terms based on their binary values
            simplifiedTerms = simplifiedTerms.OrderBy(term => term.Binary).ToList();

            return simplifiedTerms;
        }

        static string GetSimplifiedExpression(List<Minterm> simplifiedTerms)
        {
            string expression = "";

            foreach (Minterm term in simplifiedTerms)
            {
                string termString = "";

                for (int i = 0; i < numVariables; i++)
                {
                    if (term.Binary[i] == '0')
                    {
                        termString += (char)('A' + i) + "'";
                    }
                    else if (term.Binary[i] == '1')
                    {
                        termString += (char)('A' + i);
                    }
                }

                expression += termString + " + ";
            }

            expression = expression.TrimEnd('+', ' ');

            return expression;
        }


        static string ResultCreator(List<Minterm> primeImplicants, List<Minterm> essentialPrimeImplicants, string simplifiedExpression)
        {
            StringBuilder expression = new StringBuilder();
            expression.Append($"\nPrime implicants ({primeImplicants.Count}) :{"\n"} {string.Join("\n ", primeImplicants.Select(pi => $"{pi.Binary} {"\t"} m({string.Join(", ", pi.CombinedTerms)})"))}");
            expression.Append($"\n\nEssential prime implicants ({essentialPrimeImplicants.Count}) :{"\n"} {string.Join("\n ", essentialPrimeImplicants.Select(epi => $"{epi.Binary} {"\t"} m({string.Join(", ", epi.CombinedTerms)})"))}");
            expression.Append($"\n\n\nResult : {simplifiedExpression}");
            return expression.ToString();
        }
    }
}
