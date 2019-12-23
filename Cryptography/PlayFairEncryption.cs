using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cryptography
{
    class PlayFairEncryption
    {


        List<string> steps = new List<string>();
       
        
        public List<string> getStep()
        {
            return steps;
        }

        public String PFEncryption(String keyword, String input)
        {

          
                string key = keyword.ToLower();
                string matrix = null;
                string alphabets = "abcdefghiklmnopqrstuvwxyz";
                string inputMsg = input.ToLower();
                string output = "";
                #region _
                Regex rgx = new Regex("[^a-z-]");
#endregion
                key = rgx.Replace(key, "");

                key = key.Replace('j', 'i');

                for (int i = 0; i < key.Length; i++)
                {
                    if ((matrix == null) || (!matrix.Contains(key[i])))
                    {
                        steps.Add("Function is making matrix of keyword and inserting  " + key[i] + "   "+"in that matrix");
                      matrix += key[i];
                      
                    }
                    
                }
                steps.Add("Complete matrix is : " + matrix +" and removing repeating alphabet");

                for (int i = 0; i < alphabets.Length; i++)
                {
                    if (!matrix.Contains(alphabets[i]))
                    {
                        steps.Add("Complete Matrix with alphabets, here is " + alphabets[i].ToString());
                        matrix += alphabets[i];
                    }
                }

                inputMsg = rgx.Replace(inputMsg, "");

                inputMsg = inputMsg.Replace('j', 'i');
                steps.Add("Removing j from alphabets because the matrix is 5    *   5");

                for (int i = 0; i < inputMsg.Length; i += 2)
                {
                    if (((i + 1) < inputMsg.Length) && (inputMsg[i] == inputMsg[i + 1]))
                    {
                        
                        inputMsg = inputMsg.Insert(i + 1, "x");
                        steps.Add("Function is replacing x on repeating alphabets");
                    }
                }

                if ((inputMsg.Length % 2) > 0)
                {
                    steps.Add("Input message is odd number then add x = " + inputMsg + "x");
                    inputMsg += "x";
                }

                int iTemp = 0;
                do
                {
                        int iPosA = matrix.IndexOf(inputMsg[iTemp]);
                   
                    int iPosB = matrix.IndexOf(inputMsg[iTemp + 1]);
                   
                    int iRowA = iPosA / 5;
                   
                    int iColA = iPosA % 5;
                   
                    int iRowB = iPosB / 5;
                   
                    int iColB = iPosB % 5;
                   

                    if (iColA == iColB)
                    {
                        iPosA += 5;
                        iPosB += 5;
                    }
                    else
                    {
                        if (iRowA == iRowB)
                        {
                            if (iColA == 4)
                            {
                                iPosA -= 4;
                            }
                            else
                            {
                                iPosA += 1;
                            }
                            if (iColB == 4)
                            {
                                iPosB -= 4;
                            }
                            else
                            {
                                iPosB += 1;
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

                    if (iPosA >= matrix.Length)
                    {
                       
                        iPosA = 0 + (iPosA - matrix.Length);
                    }

                    if (iPosB >= matrix.Length)
                    {
                      
                        iPosB = 0 + (iPosB - matrix.Length);
                    }
                    
                    output += matrix[iPosA].ToString() + matrix[iPosB].ToString();
                   

                    iTemp += 2;
                } while (iTemp < inputMsg.Length);

                steps.Add("Function is completed, encrypted message is " + output);
                return  output;
                
            }

       
    }
}
