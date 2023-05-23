namespace Quine_Maccluskey_Windows_Forms.Models
{
    internal class Minterm
    {
        public string Binary { get; set; }
        public int? Decimal { get; set; }
        public List<int> CombinedTerms { get; set; }
        public bool IsCombined { get; set; }
        public double SizeOfImplicants { get; set; }
        public int GroupNumber { get; set; }
        public int Priority { get; set; }

        public Minterm()
        {

        }

        public Minterm(string binary, int decimalValue)
        {
            Binary = binary;
            Decimal = decimalValue;
            CombinedTerms = new(CalculateImplicantCombinations(binary));
            IsCombined = false;
            SizeOfImplicants = PrimeImplicantSizeCalculator(binary);
            GroupNumber = PrimeImplicatGroupNumberCalculator(binary);
            Priority = 0;
        }
        public Minterm(string binary)
        {
            Binary = binary;
            //edit this line
            Decimal = -1;
            CombinedTerms = new(CalculateImplicantCombinations(binary));
            IsCombined = false;
            SizeOfImplicants = PrimeImplicantSizeCalculator(binary);
            GroupNumber = PrimeImplicatGroupNumberCalculator(binary);
            Priority = 0;
        }


        public void SetPriority(int priority)
        {
            Priority = priority;
        }

        public void SetCombinedMinterm()
        {
            IsCombined = true;
        }

        static double PrimeImplicantSizeCalculator(string binary)
        {
            return Math.Pow(2, binary.Count(c => c == '-'));
        }

        static int PrimeImplicatGroupNumberCalculator(string binary)
        {
            return binary.Count(c => c == '1');
        }

        static List<int> CalculateImplicantCombinations(string implicant)
        {
            List<int> combinedImplicants = new();
            int countOfDashs = implicant.Count(d => d == '-');
            if (countOfDashs == 0)
            {
                combinedImplicants.Add(Convert.ToInt32(implicant, 2));
                return combinedImplicants;
            }
            else
            {
                foreach (var item in RandomBinaryCodeList(countOfDashs))
                {
                    string newImplicant = implicant;

                    for (int j = 0; j < item.Length; j++)
                    {
                        for (int k = 0; k < newImplicant.Length; k++)
                        {
                            if (newImplicant[k] == '-')
                            {
                                newImplicant = newImplicant.Remove(k, 1).Insert(k, item[j].ToString());
                                break;
                            }
                        }
                    }
                    combinedImplicants.Add(Convert.ToInt32(newImplicant, 2));
                }

                return combinedImplicants;

            }
        }

        static List<string> RandomBinaryCodeList(int countOfDash)
        {
            List<string> implicants = new List<string>();
            int i = (int)Math.Pow(2, countOfDash);

            while (implicants.Count < i)
            {
                string strDigit = RandomBinaryCodeGenerator(countOfDash);
                if (!implicants.Contains(strDigit))
                    implicants.Add(strDigit);
            }

            return implicants;
        }

        static string RandomBinaryCodeGenerator(int digitCount)
        {
            Random random = new Random();
            string binaryNumber = "";

            for (int i = 0; i < digitCount; i++)
            {
                binaryNumber += random.Next(2).ToString();
            }

            return binaryNumber;
        }

    }
}
