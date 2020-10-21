using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace DividendCrawler_I3Investor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();

            //options.AddArguments("user-data-dir=C:/Users/LiauS/AppData/Local/Google/Chrome/User Data/Default");

            IWebDriver driver = new ChromeDriver(options);

            driver.Url = "https://klse.i3investor.com/entitlement/dividend/latestEx.jsp";
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//option[@value='100']")).Click();


            string pageSourceString = driver.PageSource;
            string line;
            var sr = new StringReader(pageSourceString);
            int controlValue = 0;

            List<MYRDividendInformation> MYRDividendInformationList = new List<MYRDividendInformation>();
            string varExerciseDate = String.Empty;
            string varCounterName = String.Empty;
            string varAnnouncementDate = String.Empty;
            string varDividend = String.Empty;
            string varCreatedDate = String.Empty;
            string varCurrentPrice = String.Empty;
            string varOpeningPrice = String.Empty;

            while ((line = sr.ReadLine()) != null)
            {
                if (controlValue == 0 && line.IndexOf(@"a href=""/servlets/stk/annent/") > -1)
                {
                    int startPos0 = line.IndexOf(@"td class=""center sorting_1"" nowrap=""nowrap""") + 46;
                    int endPos0 = line.IndexOf(@"</td>", startPos0 + 1);
                    varExerciseDate = line.Substring(startPos0, endPos0 - startPos0 - 2);

                    int startPos1 = line.IndexOf(@"a href=""/servlets/stk/annent/") + 40;
                    int endPos1 = line.IndexOf(@"</a>", startPos1);
                    varCounterName = line.Substring(startPos1, endPos1 - startPos1 - 1);

                  
                }

                if(controlValue >0 && line.IndexOf(@"td class=""right""") > -1)
                {
                    int startPos2 = line.IndexOf(@"td class=""right""") + 18;
                    int endPos2 = line.IndexOf(@"</td>", startPos2);
                    varOpeningPrice = line.Substring(startPos2, endPos2 - startPos2 - 1);
                    
                    int startPos3 = line.IndexOf(@"td class=""right""", endPos2 + 1) + 18;
                    int endPos3 = line.IndexOf(@"</td>", startPos3) ;
                    varCurrentPrice = line.Substring(startPos3, endPos3 - startPos3 - 1);

                    int startPos4 = line.IndexOf(@"td class=""right"" nowrap=""nowrap""", endPos3 + 1) + 36;
                    int endPos4 = line.IndexOf(@"</td>", startPos4);
                    varDividend = line.Substring(startPos4, endPos4 - startPos4 - 1);

                    int startPos5 = line.IndexOf(@"td class=""center sorting_2"" nowrap=""nowrap""", endPos4 + 1) + 46;
                    int endPos5 = line.IndexOf(@"</td>", startPos5);
                    varAnnouncementDate = line.Substring(startPos5, endPos5 - startPos5 - 2);

                    MYRDividendInformationList.Add(new MYRDividendInformation
                    {
                        AnnouncementDate = varAnnouncementDate,
                        CounterName = varCounterName,
                        CreatedDate = DateTime.Now.ToShortDateString(),
                        CurrentPrice = varCurrentPrice,
                        Dividend = varDividend,
                        ExerciseDate = varExerciseDate,
                        OpeningPrice = varOpeningPrice

                    });

                    int startPos6 = line.IndexOf(@"td class=""center sorting_1"" nowrap=""nowrap""", endPos5 + 1) + 46;
                    int endPos6 = line.IndexOf(@"</td>", startPos6);
                    varExerciseDate = line.Substring(startPos6, endPos6 - startPos6 - 2);

                    int startPos7 = line.IndexOf(@"a href=""/servlets/stk/annent/") + 40;
                    int endPos7 = line.IndexOf(@"</a>", startPos7);
                    varCounterName = line.Substring(startPos7, endPos7 - startPos7 - 1);

                }
                if (varCounterName != "")
                {
                    controlValue++;
                }


            }

       

            XmlSerializer xs = new XmlSerializer(typeof(List<MYRDividendInformation>));

            TextWriter txtWriter = new StreamWriter(@"C:\_Tasks\Serialization.xml");

            xs.Serialize(txtWriter, MYRDividendInformationList);

            txtWriter.Close();
        }

        public class MYRDividendInformation
        {
            public string ExerciseDate { get; set; }
            public string CounterName { get; set; }
            public string AnnouncementDate { get; set; }
            public string Dividend { get; set; }
            public string CreatedDate { get; set; }
            public string CurrentPrice { get; set; }
            public string OpeningPrice { get; set; }
        }
    }
}
