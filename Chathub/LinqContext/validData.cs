using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chathub 
{
    public class validData
    {

        public string Reverse_ValidateData(string StrRtnVal)
        {
            if (StrRtnVal.Contains("''"))
            {
                StrRtnVal = StrRtnVal.Replace("''", "'");
            }
            return StrRtnVal;
        }

        public string ValidateData1(string StrRtnVal)
        {
            //============================VIRUS REMOVAL CODE STARTS FOR StrRtnVal==================================//

            if (StrRtnVal.Contains("--"))
            {
                StrRtnVal = StrRtnVal.Replace("--", "-");
            }
            if (StrRtnVal.Contains("'"))
            {
                StrRtnVal = StrRtnVal.Replace("'", "");
            }
            if (StrRtnVal.Contains(".exe"))
            {
                StrRtnVal = StrRtnVal.Replace(".exe", "");
            }
            if (StrRtnVal.Contains("["))
            {
                StrRtnVal = StrRtnVal.Replace("[", "[]");
            }
            if (StrRtnVal.Contains(";"))
            {
                StrRtnVal = StrRtnVal.Replace(";", "");
            }
            if (StrRtnVal.Contains("_xp"))
            {
                StrRtnVal = StrRtnVal.Replace("_xp", "");
            }
            if (StrRtnVal.Contains("_db"))
            {
                StrRtnVal = StrRtnVal.Replace("_db", "");
            }
            if (StrRtnVal.Contains("drop"))
            {
                StrRtnVal = StrRtnVal.Replace("drop", "");
            }
            if (StrRtnVal.Contains("<script>"))
            {
                StrRtnVal = StrRtnVal.Replace("<script>", "");
            }
            if (StrRtnVal.Contains("</script>"))
            {
                StrRtnVal = StrRtnVal.Replace("</script>", "");
            }
            if (StrRtnVal.Contains(".js"))
            {
                StrRtnVal = StrRtnVal.Replace(".js", "");
            }
            if (StrRtnVal.Contains("drop"))
            {
                StrRtnVal = StrRtnVal.Replace("drop", "");
            }
            if (StrRtnVal.Contains("delete"))
            {
                StrRtnVal = StrRtnVal.Replace("delete", "");
            }
            if (StrRtnVal.Contains("update"))
            {
                StrRtnVal = StrRtnVal.Replace("update", "");
            }
            if (StrRtnVal.Contains("master"))
            {
                StrRtnVal = StrRtnVal.Replace("master", "");
            }
            if (StrRtnVal.Contains("model"))
            {
                StrRtnVal = StrRtnVal.Replace("model", "");
            }
            if (StrRtnVal.Contains("msdb"))
            {
                StrRtnVal = StrRtnVal.Replace("msdb", "");
            }
            if (StrRtnVal.Contains("tempdb"))
            {
                StrRtnVal = StrRtnVal.Replace("tempdb", "");
            }
            if (StrRtnVal.Contains("`"))
            {
                StrRtnVal = StrRtnVal.Replace("`", "''");
            }

            //============================VIRUS REMOVAL CODE ENDS==================================//
            return StrRtnVal;
        }


        public string ValidateData(string StrRtnVal)
        {
            //string actual = "This is test &lt;ifraMe src=\"mmncvcnmnmn\" &gt;</script> vbvbv nbvnb this is test &lt;script mmnnmnmn ></script> vbvbv nbvnb", nonactual = "";

            string actual = StrRtnVal, nonactual = "";

            nonactual = actual;

            nonactual = nonactual.Replace("&gt;", ">").Replace("&lt;", "<");

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("<script[^>]*>");

            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex("</script[^>]*>");

            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex("<iframe[^>]*>");

            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex("</iframe[^>]*>");

            System.Text.RegularExpressions.MatchCollection mch1;

            mch1 = regex.Matches(nonactual.ToLower());

            int i; int z = 0;

            for (i = 0; i < mch1.Count; i++)
            {

                int k = 0;

                try
                {

                    if (actual.Substring(mch1[i].Index - z, 4).ToLower() == "&lt;")

                        k = k + 3;

                    if (actual.Substring((mch1[i].Index - z) + k + mch1[i].Length - 1, 4).ToLower() == "&gt;")

                        k = k + 3;

                }

                catch (Exception e1)
                {
                    throw e1;
                }

                actual = actual.Remove(mch1[i].Index - z, mch1[i].Length + k);

                z = z + mch1[0].Length;

            }

            nonactual = actual;

            nonactual = nonactual.Replace("&gt;", ">").Replace("&lt;", "<");

            z = 0;

            mch1 = regex1.Matches(nonactual.ToLower());

            for (i = 0; i < mch1.Count; i++)
            {

                int k = 0;

                try
                {

                    if (actual.Substring(mch1[i].Index - z, 4).ToLower() == "&lt;")

                        k = k + 3;

                    if (actual.Substring((mch1[i].Index - z) + k + mch1[i].Length - 1, 4).ToLower() == "&gt;")

                        k = k + 3;

                }

                catch (Exception e1)
                {
                    throw e1;
                }

                actual = actual.Remove(mch1[i].Index - z, mch1[i].Length + k);

                z = z + mch1[0].Length;

            }

            nonactual = actual;

            nonactual = nonactual.Replace("&gt;", ">").Replace("&lt;", "<");

            z = 0;

            mch1 = regex2.Matches(nonactual.ToLower());

            for (i = 0; i < mch1.Count; i++)
            {

                int k = 0;

                try
                {

                    if (actual.Substring(mch1[i].Index - z, 4).ToLower() == "&lt;")

                        k = k + 3;

                    if (actual.Substring((mch1[i].Index - z) + k + mch1[i].Length - 1, 4).ToLower() == "&gt;")

                        k = k + 3;

                }

                catch (Exception e1)
                {
                    throw e1;
                }

                actual = actual.Remove(mch1[i].Index - z, mch1[i].Length + k);

                z = z + mch1[0].Length;

            }

            nonactual = actual;

            nonactual = nonactual.Replace("&gt;", ">").Replace("&lt;", "<");

            z = 0;

            mch1 = regex3.Matches(nonactual.ToLower());

            for (i = 0; i < mch1.Count; i++)
            {

                int k = 0;

                try
                {

                    if (actual.Substring(mch1[i].Index - z, 4).ToLower() == "&lt;")

                        k = k + 3;

                    if (actual.Substring((mch1[i].Index - z) + k + mch1[i].Length - 1, 4).ToLower() == "&gt;")

                        k = k + 3;

                }

                catch (Exception e1)
                {
                    throw e1;
                }

                actual = actual.Remove(mch1[i].Index - z, mch1[i].Length + k);

                z = z + mch1[0].Length;

            }

            actual = actual.Replace("--", "-").Replace(".exe", "").Replace("_db", "").Replace("'", "''").Replace("master ", "");

            actual = actual.Replace("[", "[]").Replace("_xp", "").Replace(".js", "").Replace("drop ", "").Replace("model", "").Replace("tempdb", "");

            actual = actual.Replace("&gt;", ">").Replace("&lt;", "<").Replace("delete ", "").Replace("update ", "").Replace("msdb", "").Replace("`", "''");

            //-----------Replace "'" --------------------
            //actual = actual.Replace("'","''");

            //-----------End Replace "''----------------


            return actual;
        }

    }
}