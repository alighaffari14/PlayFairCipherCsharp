using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cryptography
{
    class PlayFairDecryption
    {
        List<string> steps = new List<string>();


        public List<string> getStep()
        {
            return steps;
        }
        public String PFDecryption(String keyword, String input)
        {
            string sKey = keyword.ToLower();
            string sGrid = null;
            string sAlpha = "abcdefghiklmnopqrstuvwxyz";
            string sInput = input.ToLower();
            string sOutput = "";
                        
            sKey = sKey.Replace('j', 'i');

            for (int i = 0; i < sKey.Length; i++)
            {
                if ((sGrid == null) || (!sGrid.Contains(sKey[i])))
                {
                    steps.Add("Keyword is   :  " + sKey[i] + "  in that matrix");
                    sGrid += sKey[i];
                }
            }
            steps.Add("complete matrix is : " + sGrid + "  and removing repeating alphabet");

            for (int i = 0; i < sAlpha.Length; i++)
            {
                if (!sGrid.Contains(sAlpha[i]))
                {
                    steps.Add("Complete Matrix with alphabets, here is " + sAlpha[i].ToString());
                    sGrid += sAlpha[i];
                }
            }

            int iTemp = 0;
            do
            {
                int iPosA = sGrid.IndexOf(sInput[iTemp]);
                int iPosB = sGrid.IndexOf(sInput[iTemp+1]);
                int iRowA = iPosA / 5;
                int iColA = iPosA % 5;
                int iRowB = iPosB / 5;
                int iColB = iPosB % 5;

                if (iColA == iColB)
                {
                    iPosA -= 5;
                    iPosB -= 5;
                }
                else
                {
                    if (iRowA == iRowB)
                    {
                        if (iColA == 0)
                        {
                            iPosA += 4;
                        }
                        else
                        {
                            iPosA -= 1;
                        }
                        if (iColB == 0)
                        {
                            iPosB += 4;
                        }
                        else
                        {
                            iPosB -= 1;
                        }
                    }
                    else
                    {
                        if (iRowA < iRowB)
                        {
                            iPosA -= iColA - iColB;
                            iPosB += iColA - iColB;
                        }
                        else
                        {
                            iPosA += iColB - iColA;
                            iPosB -= iColB - iColA;
                        }
                    }
                }

                if (iPosA > sGrid.Length)
                {
                    iPosA = 0 + (iPosA - sGrid.Length);
                }

                if (iPosB > sGrid.Length)
                {
                    iPosB = 0 + (iPosB - sGrid.Length);
                }

                if (iPosA < 0)
                {
                    iPosA = sGrid.Length + iPosA;
                }

                if (iPosB < 0)
                {
                    iPosB = sGrid.Length + iPosB;
                }

                sOutput += sGrid[iPosA].ToString() + sGrid[iPosB].ToString();


                iTemp += 2;
            } while (iTemp < sInput.Length-1);

            steps.Add("Function is completed, decrypted message is " + sOutput);
            return sOutput;

        }
    }
}
