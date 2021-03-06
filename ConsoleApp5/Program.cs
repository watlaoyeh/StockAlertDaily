﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.IO;
using OpenQA.Selenium.Interactions;
using System.Xml;
using System.Collections.Generic;
using System.Net.Mail;

namespace ConsoleApp5
{
    
    public class DailyStockPick
    {
     
        public string stockCounter { get; set; }
        public decimal currentPrice { get; set; }

        public decimal targetPrice { get; set; }

        public decimal stopLossPrice { get; set; }
    }
    class Program
    {
        static int dayCount = 0;
        static List<DailyStockPick> stockPickListUSA = new List<DailyStockPick>();
        static List<DailyStockPick> stockPickListMY = new List<DailyStockPick>();
        static List<DailyStockPick> stockPickListSG = new List<DailyStockPick>();
        static List<DailyStockPick> stockPickListHK = new List<DailyStockPick>();
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            //options.AddExtension(@"C:\Users\user\Downloads\chromedriver_win32 (2)\chromedriver.exe");


            //ChromeOptions options = new ChromeOptions();
            ////options.AddArguments("--no-sandbox");            
            options.AddArguments("user-data-dir=C:/Users/user/AppData/Local/Google/Chrome/User Data/Default");
            //options.BinaryLocation = @"C:\Users\user\Downloads\ChromeNewDriver";
            IWebDriver driver = new ChromeDriver(@"C:\Users\user\Downloads\ChromeNewDriver", options);
            //
            //IWebDriver driver = new ChromeDriver();
            DirectoryInfo di;

            //ChromeOptions options = new ChromeOptions();
            ////options.AddExtension(@"C:\Users\LiauS\source\repos\StockAlertDaily\ConsoleApp5\bin\Debug\chromedriver.exe");


            ////ChromeOptions options = new ChromeOptions();
            //////options.AddArguments("--no-sandbox");            
            //options.AddArguments("user-data-dir=C:/Users/LiauS/AppData/Local/Google/Chrome/User Data/Default");

            //IWebDriver driver = new ChromeDriver(options);
            ////IWebDriver driver = new ChromeDriver();
            //DirectoryInfo di;

            #region screeningStock
            string newDirectory = @"C:\_Tasks\zzzzz\_z_stock_screening\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
            if (!Directory.Exists(newDirectory))
                di = Directory.CreateDirectory(newDirectory);

            string existingFileFolder = @"C:\_Tasks\zzzzz\_z_stock_screening\";
            string[] previousFiles = Directory.GetFiles(existingFileFolder, "*.csv");
            foreach (string file in previousFiles)
            {
                string name = Path.GetFileName(file);

                // ADD Unique File Name Check to Below!!!!
                string dest = Path.Combine(newDirectory, name);
                if (File.Exists(dest))
                {
                    File.Move(file, dest + DateTime.Now.ToString("yyyymmdd hhmmss"));
                }
                else
                {
                    File.Move(file, dest);
                }

            }
            #endregion


            #region remove original file
            //string[] ResidueFiles = Directory.GetFiles(@"C:\Users\user\Downloads", "* Historical Data.csv");
            //foreach (string file in ResidueFiles)
            //{
            //    File.Delete(file);

            //}
            #endregion

            #region Historical Data 
            newDirectory = @"C:\_Tasks\zzzzz\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
            if (!Directory.Exists(newDirectory))
                di = Directory.CreateDirectory(newDirectory);

            existingFileFolder = @"C:\_Tasks\zzzzz";
            previousFiles = Directory.GetFiles(existingFileFolder, "* Historical Data.csv");
            foreach (string file in previousFiles)
            {
                string name = Path.GetFileName(file);

                // ADD Unique File Name Check to Below!!!!
                string dest = Path.Combine(newDirectory, name);
                if (File.Exists(dest))
                {
                    File.Move(file, dest + DateTime.Now.ToString("yyyymmdd hhmmss"));
                }
                else
                {
                    File.Move(file, dest);
                }

            }

            #endregion

            #region login
            //driver.Url = ("http://investing.com");
            //driver.FindElement(By.XPath("//a[@class='login bold']")).Click();
            //driver.FindElement(By.Id("customBtn1")).Click();

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
            ////String parentWindowHandler = driver.CurrentWindowHandle(); // Store your parent window
            ////String subWindowHandler = null;

            ////Set<String> handles = driver.SwitchTo(); (); // get all window handles
            ////Iterator<String> iterator = handles.iterator();
            ////while (iterator.hasNext())
            ////{
            ////    subWindowHandler = iterator.next();
            ////}
            ////driver.switchTo().window(subWindowHandler); // switch to popup window
            ////                                            // perform operations on popup

            ////driver.switchTo().window(parentWindowHandler);
            ////            driver.SwitchTo().Window()
            ////driver.SwitchTo().DefaultContent();

            ////String parentWindow = driver.CurrentWindowHandle();
            ////System.out.println("Parent Window ID is : " + parentWindow);
            ////for (String winHandle : driver.WindowHandles.GetEnumerator())
            ////{
            ////    driver.SwitchTo().Window(winHandle);

            ////    //driver.manage().window().maximize();
            ////}
            ////wait.Until(Expect)
            ////WAIT.until(ExpectedConditions.visibilityOfElementLocated(By.xpath("//input[@id='identifierId']")));
            ////driver.findElement(By.xpath("//input[@id='identifierId']")).sendKeys(emailid);
            //string parentWindow = driver.CurrentWindowHandle;

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ////string[] winHandle = driver.WindowHandles.GetEnumerator();
            ////Thread.Sleep(2000);
            ////driver.SwitchTo().Window(driver.WindowHandles.GetEnumerator());
            ////ArrayList<String> tabs = new ArrayList<String>(driver.WindowHandles.GetEnumerator());
            ////driver.switchTo().window(tabs.get(0));
            ////driver.SwitchTo().Window((((System.Collections.Generic.List<string>.Enumerator)driver.WindowHandles.GetEnumerator()).list)[1].ToString());
            //string popupHandle = string.Empty;
            //ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            //foreach (string handle in windowHandles)
            //{
            //    if (handle != driver.CurrentWindowHandle)
            //    {
            //        popupHandle = handle; break;
            //    }
            //}

            ////switch to new window 
            //driver.SwitchTo().Window(popupHandle);

            //driver.FindElement(By.Id("identifierId")).SendKeys("liausheauchang@gmail.com");
            //driver.FindElement(By.CssSelector(".RveJvd.snByac")).Click();
            ////driver.FindElement(By.XPath("//input[@type='password']")).SendKeys("abracadabra");

            //driver.FindElement(By.XPath("//*[@id=\"password\"]/div[1]/div/div[1]/input")).SendKeys("abracadabra");

            //driver.FindElement(By.CssSelector(".RveJvd.snByac")).Click();
            ////driver.FindElement(By.XPath("//*[@id=\"passwordNext\"]/span/span")).Click();

            ////driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);

            ////driver.close();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //#endregion

            //#region obsolete
            ////#region INARI
            ////driver.FindElement(By.CssSelector(".searchText.arial_12.lightgrayFont.js-main-search-bar")).SendKeys("INARI");@22222
            ////// driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            ////driver.FindElement(By.XPath("//span[@title='Inari Amertron Bhd']")).Click();
            //////driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ////driver.FindElement(By.XPath("//a[@href='/equities/inari-amertron-bhd-historical-data']")).Click();



            ////IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            ////js.ExecuteScript("document.getElementById('picker').setAttribute('value', '" + getDateRange() + "')");


            ////driver.FindElement(By.XPath("//div[@id='widgetFieldDateRange']")).Click();

            //////IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            //////js.ExecuteScript("document.getElementById('widgetFieldDateRange').innerHTML = '01/01/2017 - 12/30/2019';");

            ////driver.FindElement(By.Id("applyBtn")).Click();
            ////driver.FindElement(By.XPath("//a[@title='Download Data']")).Click();
            ////#endregion
            #endregion

            #region version 1

            //searchAndDownload(driver,"INARI", "Inari Amertron Bhd", "inari-amertron-bhd");
            //searchAndDownload(driver, "HTHB", "Hartalega Holdings Bhd", "hartalega-holdings-bhd");

            #endregion

            #region shareSelection
            //Login(@"https://secure8.itradecimb.com.my/gcCIMBNEW/web/html/cliLogin.html", driver);
            //Thread.Sleep(10000);
            ///SharesSelection("http://www2.trkd-hs.com/cimb/ui/home?lang=en", driver);
            #endregion
            //            moveFilesFromDownload();
            #region version 2
           
            //driver.Url = ("http://investing.com");
            //SearchAndDownloadV2(@"https://www.investing.com/equities/aeon-credit-service-(m)-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/airasia-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/malaysia-airport-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/denko-industrial-corporation-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/berjaya-auto-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/bimb-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/cck-consolidated-holdings-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/dayang-enterprise-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/frontken-corporation-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/greatech-technology-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/jaycorp-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/johore-tin-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/klcc-prop-reits---stapled-sec-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/lee-swee-kiat-group-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/magni-tech-industries-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/matrix-concepts-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/malayan-banking-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/pantech-group-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/pentamaster-corporation-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/pie-industrial-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/pavilion-real-estate-inv-trust-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/pintaras-jaya-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/sapurakencana-petroleum-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/scientex-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/serba-dinamik-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/sunway-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/taliworks-corporation-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/umw-oil-and-gas-corporation-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/khee-san-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/inari-amertron-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/elsoft-research-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/naim-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/hock-seng-lee-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/ibraco-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/emas-kiara-industries-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/syarikat-takaful-malaysia-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/genting-malaysia-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/yinson-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/malakoff-corporation-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/integrated-rubber-corporation-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/eco-world-develop-group-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/dialog-group-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/sarawak-plantation-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/gamuda-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/vs-industry-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/rhb-capital-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/pecca-group-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/dufu-tech-corp-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/bumi-armada-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/time-dotcom-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/eco-world-international-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/guan-chong-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/hartalega-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/ccm-duopharma-biotech-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/ysp-southeast-asia-holding-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/supermax-corporation-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/malaysian-plantations-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/aeon-co-(m)-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/ammb-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/carlsberg-brewery-malaysia-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/faber-group-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/eita-resources-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/elk-desa-resources-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/gas-malaysia-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/guinness-anchor-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/lpi-capital-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/mbm-resources-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/sime-darby-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/slp-resources-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/cypark-resources-berhad-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/kpj-healthcare-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/sunway-construction-group-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/sunway-real-estate-invest-trust-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/gabungan-aqrs-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/uoa-development-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/carimin-petroleum-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/datasonic-group-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/jhm-consolidation-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/mmc-corporation-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/ntpm-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/ock-group-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/oka-corporation-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/perdana-petroleum-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/pls-plantations-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/rce-capital-berhad-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/supercomnet-technologies-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/voir-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/astral-supreme-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/public-bank-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/muhibbah-engineering-m-bhd-historical-data", driver);

            //SearchAndDownloadV2(@"https://www.investing.com/equities/sam-engineering-equipment-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/willowglen-msc-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/westports-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/bumiputra---commerce-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/ihh-healthcare-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/bison-consolidated-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/petronas-chemicals-group-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/symphony-house-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/sime-darby-plantation-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/tenaga-nasional-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/telekom-malaysia-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/top-glove-corporation-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/dksh-holdings-malaysia-berhad-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/genting-plantations-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/igb-real-estate-investment-trust-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/kuala-lumpur-kepong-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/kossan-rubber-industries-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/lbs-bina-group-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/mah-sing-group-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/power-root-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/skp-resources-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/success-transformer-corp-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/uchi-technologies-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/ioi-corporation-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/misc-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/malaysian-resources-corporation-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/my-eg-services-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/drb---hicom-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/lii-hen-industries-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/ea-technique-m-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/ijm-corporation-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/mega-first-corporation-bhd-historical-data", driver);


            //SearchAndDownloadV2(@"https://www.investing.com/equities/ta-ann-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/ql-resources-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/chin-well-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/padini-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/pesona-metro-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/poh-huat-resources-holdings-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/perak-transit-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/favelle-favco-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/lotte-chemical-titan-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/mrcb-quill-unit-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/sp-setia-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/umw-holdings-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/wah-seong-corporation-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/ytl-hospitality-reit-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/malaysian-pacific-industries-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/pestech-international-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/petra-energy-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/hibiscus-petroleum-bhd-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/sime-darby-property-historical-data", driver);
            //SearchAndDownloadV2(@"https://www.investing.com/equities/green-packet-bhd-historical-data", driver);

            //Added because Public Bank file always left out
            Thread.Sleep(5000);

            //moveFilesFromDownload();
            #endregion

            //driver.Url = ("http://investing.com");
            SearchAndDownloadUSA(@"https://www.tradingview.com/screener/", driver);
            SearchAndDownloadMY(@"https://www.tradingview.com/screener/", driver);
            SearchAndDownloadSG(@"https://www.tradingview.com/screener/", driver);
            SearchAndDownloadHK(@"https://www.tradingview.com/screener/", driver);

            genericSendMail(); 
            //driver.Close();
            System.Environment.Exit(0);
        }

        private static void SearchAndDownloadUSA(string url, IWebDriver driver)
        {
            Thread.Sleep(5000);
            //driver.Navigate(url);
            driver.Url = url;

            Thread.Sleep(5000);
            // driver.FindElement(By.XPath("//div[@data-market='denmark"')).Click();
             driver.FindElement(By.XPath("//div[@title='Markets']")).Click();

            Thread.Sleep(5000);
             driver.FindElement(By.XPath("//div[@data-market='america']")).Click();


            Thread.Sleep(15000);
            string line;
            string abc = driver.PageSource;
            int positionContent = abc.IndexOf(@"class=""tv-screener-table__symbol-container")-300;
            var sr = new StringReader(abc.Substring(positionContent));

            int count = 0;

            Tuple<string, decimal?, decimal?> counterList = null;
            
            string varCounter = "";
            decimal varCurrentPrice = 0;
            decimal varTargetPrice = 0;

            int checkSequence = 1;
            while ((line = sr.ReadLine()) != null)
            {
                count++;

                bool isClosingCheckNeeded = false;
                string counter = String.Empty;
                decimal varClose;

                int startPos;
                int endPos;



                if (checkSequence == 1)
                {

                    if (line.Contains(@"data-symbol=""NYSE:") || line.Contains(@"data-symbol=""NASDAQ:"))
                    {

                        if (line.Contains(@"data-symbol=""NYSE:"))
                        {
                            startPos = line.IndexOf(@"data-symbol=""NYSE:") + 18;
                            endPos = line.IndexOf(@"""", startPos - 3);
                            varCounter = line.Substring(startPos, endPos - startPos) + "(NYSE)";
                            Console.WriteLine(counter);
                            //checkSequence = 2;

                            checkSequence++;
                        }
                        else
                        {
                            startPos = line.IndexOf(@"data-symbol=""NASDAQ:") + 20;
                            endPos = line.IndexOf(@"""", startPos - 3);
                            varCounter = line.Substring(startPos, endPos - startPos) + "(NASDAQ)";
                            Console.WriteLine(counter);
                            //checkSequence = 2;

                            checkSequence++;
                        }
                    }
                }

                //if (line.Contains(@"data-field-key=""close"""))
                if (checkSequence > 1 && line.Contains(@"data-field-key=""close"""))
                {
                    int startPos2 = line.IndexOf(@"<span>") + 6;
                    int endPos2 = line.IndexOf(@"</span>", startPos2 - 3);
                    string price = line.Substring(startPos2, endPos2 - startPos2);


                    varCurrentPrice = Decimal.Parse(price);

                    if (!String.IsNullOrEmpty(varCounter))
                    {
                        //counterList = new Tuple<string, decimal?, decimal?>(counter, varCurrentPrice, varCurrentPrice);
                        stockPickListUSA.Add(new DailyStockPick
                        {
                            stockCounter = varCounter,
                            currentPrice = Math.Round(varCurrentPrice, 2),
                            targetPrice = Math.Round(varCurrentPrice * Decimal.Parse("1.16"), 2),
                            stopLossPrice = Math.Round(varCurrentPrice * Decimal.Parse("0.92"), 2)
                        });
                    }

                    if (line.Contains(@"data-symbol=""NYSE:") || line.Contains(@"data-symbol=""NASDAQ:"))
                    {

                        if (line.Contains(@"data-symbol=""NYSE:"))
                        {
                            startPos = line.IndexOf(@"data-symbol=""NYSE:") + 18;
                            endPos = line.IndexOf(@"""", startPos - 3);
                            varCounter = line.Substring(startPos, endPos - startPos) + "(NYSE)";
                            Console.WriteLine(counter);
                            //checkSequence = 2;

                            checkSequence++;
                        }
                        else
                        {
                            startPos = line.IndexOf(@"data-symbol=""NASDAQ:") + 20;
                            endPos = line.IndexOf(@"""", startPos - 3);
                            varCounter = line.Substring(startPos, endPos - startPos) + "(NASDAQ)";
                            Console.WriteLine(counter);
                            //checkSequence = 2;

                            checkSequence++;
                        }
                    }


                }


            }

           // genericSendMail(stockPickListUSA, "Daily Stock Pick - USA ");
        }


        private static void genericSendMail()
        {
            string textBody = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + ">";

            textBody = textBody + "<tr bgcolor='#4da6ff'><td>Daily USA Stock Pick</td></tr><tr><td>";

            foreach (DailyStockPick item in stockPickListUSA)
            {
                textBody = textBody + "Buy " + item.stockCounter + " At " + item.currentPrice + " TP " + item.targetPrice + " SL " + item.stopLossPrice
                    + " CP " + item.currentPrice + "<br>";
            }
            textBody = textBody + "</td></tr>";


            textBody = textBody + "<tr bgcolor='#4da6ff'><td>Daily Malaysia Stock Pick</td></tr><tr><td>";

            foreach (DailyStockPick item in stockPickListMY)
            {
                textBody = textBody + "Buy " + item.stockCounter + " At " + item.currentPrice + " TP " + item.targetPrice + " SL " + item.stopLossPrice
                    + " CP " + item.currentPrice + "<br>";
            }
            textBody = textBody + "</td></tr>";

            textBody = textBody + "<tr bgcolor='#4da6ff'><td>Daily Singapore Stock Pick</td></tr><tr><td>";

            foreach (DailyStockPick item in stockPickListSG)
            {
                textBody = textBody + "Buy " + item.stockCounter + " At " + item.currentPrice + " TP " + item.targetPrice + " SL " + item.stopLossPrice
                    + " CP " + item.currentPrice + "<br>";
            }
            textBody = textBody + "</td></tr>";

            textBody = textBody + "<tr bgcolor='#4da6ff'><td>Daily Hong Kong Stock Pick</td></tr><tr><td>";

            foreach (DailyStockPick item in stockPickListHK)
            {
                textBody = textBody + "Buy " + item.stockCounter + " At " + item.currentPrice + " TP " + item.targetPrice + " SL " + item.stopLossPrice
                    + " CP " + item.currentPrice + "<br>";
            }
            textBody = textBody + "</td></tr>";

            textBody = textBody + "</td></tr></table>";
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("liausheauchang@gmail.com", "Darren Liau");

            mail.To.Add("liausheauchang@hotmail.com");
            mail.To.Add("liausheauchang@gmail.com");
            mail.To.Add("lamchoonho@gmail.com");
            //mail.To.Add("liau.sheauhuey@gmail.com");
            //mail.To.Add("d.dinesh0211@gmail.com");
            mail.IsBodyHtml = true;

            mail.Subject = "Daily Stock Pick  - " + DateTime.Now.AddDays(dayCount).ToString("yyyy-MM-dd");
            mail.Body = "Hi members, please find the latest Stock Alert for your reference. <br /> " +
            "<br />  " + textBody;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("liausheauchang@gmail.com", "abracadabra");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;


            smtp.Timeout = 30000;
            smtp.Send(mail);
        }
        private static void SearchAndDownloadMY(string url, IWebDriver driver)
        {
            Thread.Sleep(5000);
            //driver.Navigate(url);
            driver.Url = url;
            
            Thread.Sleep(5000);
           // driver.FindElement(By.XPath("//div[@data-market='denmark"')).Click();
                   driver.FindElement(By.XPath("//div[@title='Markets']")).Click();

            Thread.Sleep(5000);
             driver.FindElement(By.XPath("//div[@data-market='malaysia']")).Click();

            Thread.Sleep(15000);
            string line;
            string abc =driver.PageSource;

            var sr = new StringReader(abc);

            int count = 0;

         
           
            string varCounter = "";
            decimal varCurrentPrice = 0;
            decimal varTargetPrice = 0;

            int checkSequence = 1;
            while ((line = sr.ReadLine()) != null)
            {
                count++;

                bool isClosingCheckNeeded = false;
                string counter=String.Empty;
                decimal varClose;

                int startPos;
                int endPos;

             

                if (checkSequence == 1)
                {

                    if (line.Contains(@"data-symbol=""MYX:"))
                    {
                        startPos = line.IndexOf(@"data-symbol=""MYX:") + 17;
                        endPos = line.IndexOf(@"""", startPos - 3);
                        varCounter = line.Substring(startPos, endPos - startPos);
                        Console.WriteLine(counter);
                        //checkSequence = 2;

                        checkSequence++;
                    }
                   
                }


                if (checkSequence > 1 && line.Contains(@"data-field-key=""close"""))
                {
                    int startPos2 = line.IndexOf(@"<span>") + 6;
                    int endPos2 = line.IndexOf(@"</span>", startPos2 - 3);
                    string price = line.Substring(startPos2, endPos2 - startPos2);


                    varCurrentPrice = Decimal.Parse(price);

                    if (!String.IsNullOrEmpty(varCounter))
                    {
                        //counterList = new Tuple<string, decimal?, decimal?>(counter, varCurrentPrice, varCurrentPrice);
                        stockPickListMY.Add(new DailyStockPick
                        {
                            stockCounter = varCounter,
                            currentPrice = Math.Round(varCurrentPrice,2),
                            targetPrice = Math.Round(varCurrentPrice * Decimal.Parse("1.16"),2),
                            stopLossPrice =Math.Round( varCurrentPrice * Decimal.Parse("0.92"),2)
                        });
                    }

                    if (line.Contains(@"data-symbol=""MYX:"))
                    {
                        startPos = line.IndexOf(@"data-symbol=""MYX:") + 17;
                        endPos = line.IndexOf(@"""", startPos - 3);
                        varCounter = line.Substring(startPos, endPos - startPos);
                        Console.WriteLine(counter);
                        //checkSequence = 2;


                    }
                }
            }


           // genericSendMail(stockPickListMY, "Daily Stock Pick - Malaysia ");

        }

        private static void SearchAndDownloadSG(string url, IWebDriver driver)
        {
            Thread.Sleep(5000);
            //driver.Navigate(url);
            driver.Url = url;

            Thread.Sleep(5000);
            // driver.FindElement(By.XPath("//div[@data-market='denmark"')).Click();
            driver.FindElement(By.XPath("//div[@title='Markets']")).Click();

            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[@data-market='singapore']")).Click();
            Thread.Sleep(15000);
            string line;
            string abc = driver.PageSource;

            var sr = new StringReader(abc);

            int count = 0;



            string varCounter = "";
            decimal varCurrentPrice = 0;
            decimal varTargetPrice = 0;
            string varCounterName = "";
            int checkSequence = 1;
            while ((line = sr.ReadLine()) != null)
            {
                count++;

                bool isClosingCheckNeeded = false;
                string counter = String.Empty;
                decimal varClose;
                
                int startPos;
                int endPos;
                if (line.Contains(@"class=""tv-screener__symbol apply-common-tooltip"" title="""))
                {
                    startPos = line.IndexOf(@"class=""tv-screener__symbol apply-common-tooltip"" title=""") + 56;
                    endPos = line.IndexOf(@""" href", startPos);
                    varCounter = line.Substring(startPos, endPos - startPos);
                    Console.WriteLine(counter);
                    //checkSequence = 2;


                }


                if (checkSequence == 1)
                {

                    if (line.Contains(@"data-symbol=""SGX:"))
                    {
                        startPos = line.IndexOf(@"data-symbol=""SGX:") + 17;
                        endPos = line.IndexOf(@"""", startPos - 3);
                        //varCounter = line.Substring(startPos, endPos - startPos);
                        Console.WriteLine(counter);
                        //checkSequence = 2;

                        checkSequence++;
                    }

                  
                }


                if (checkSequence > 1 && line.Contains(@"data-field-key=""close"""))
                {
                   


                    int startPos2 = line.IndexOf(@"<span>") + 6;
                    int endPos2 = line.IndexOf(@"</span>", startPos2 - 3);
                    string price = line.Substring(startPos2, endPos2 - startPos2);


                    varCurrentPrice = Decimal.Parse(price);

                    if (!String.IsNullOrEmpty(varCounter))
                    {
                        //counterList = new Tuple<string, decimal?, decimal?>(counter, varCurrentPrice, varCurrentPrice);
                        stockPickListSG.Add(new DailyStockPick
                        {
                            stockCounter = varCounter,
                            currentPrice = Math.Round(varCurrentPrice, 2),
                            targetPrice = Math.Round(varCurrentPrice * Decimal.Parse("1.16"), 2),
                            stopLossPrice = Math.Round(varCurrentPrice * Decimal.Parse("0.92"), 2)
                        });
                    }

              

                    if (line.Contains(@"data-symbol=""SGX:"))
                    {
                        startPos = line.IndexOf(@"data-symbol=""SGX:") + 17;
                        endPos = line.IndexOf(@"""", startPos - 3);
                        //varCounter = line.Substring(startPos, endPos - startPos);
                        Console.WriteLine(counter);
                        //checkSequence = 2;


                    }


                }
            }


           // genericSendMail(stockPickListMY, "Daily Stock Pick - Singapore ");

        }

        private static void SearchAndDownloadHK(string url, IWebDriver driver)
        {
            Thread.Sleep(5000);
            //driver.Navigate(url);
            driver.Url = url;

            Thread.Sleep(5000);
            // driver.FindElement(By.XPath("//div[@data-market='denmark"')).Click();
            driver.FindElement(By.XPath("//div[@title='Markets']")).Click();

            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[@data-market='hongkong']")).Click();
            Thread.Sleep(15000);
            string line;
            string abc = driver.PageSource;

            var sr = new StringReader(abc);

            int count = 0;



            string varCounter = "";
            decimal varCurrentPrice = 0;
            decimal varTargetPrice = 0;

            int checkSequence = 1;
            while ((line = sr.ReadLine()) != null)
            {
                count++;

                bool isClosingCheckNeeded = false;
                string counter = String.Empty;
                decimal varClose;

                int startPos;
                int endPos;

                if (line.Contains(@"class=""tv-screener__symbol apply-common-tooltip"" title="""))
                {
                    startPos = line.IndexOf(@"class=""tv-screener__symbol apply-common-tooltip"" title=""") + 56;
                    endPos = line.IndexOf(@""" href", startPos);
                    varCounter = line.Substring(startPos, endPos - startPos);
                    Console.WriteLine(counter);
                    //checkSequence = 2;


                }

                if (checkSequence == 1)
                {

                    if (line.Contains(@"data-symbol=""HKEX:"))
                    {
                        startPos = line.IndexOf(@"data-symbol=""HKEX:") + 18;
                        endPos = line.IndexOf(@"""", startPos - 3);
                        //varCounter = line.Substring(startPos, endPos - startPos);
                        Console.WriteLine(counter);
                        //checkSequence = 2;

                        checkSequence++;
                    }

                }


                if (checkSequence > 1 && line.Contains(@"data-field-key=""close"""))
                {
                    int startPos2 = line.IndexOf(@"<span>") + 6;
                    int endPos2 = line.IndexOf(@"</span>", startPos2 - 3);
                    string price = line.Substring(startPos2, endPos2 - startPos2);


                    varCurrentPrice = Decimal.Parse(price);

                    if (!String.IsNullOrEmpty(varCounter))
                    {
                        //counterList = new Tuple<string, decimal?, decimal?>(counter, varCurrentPrice, varCurrentPrice);
                        stockPickListHK.Add(new DailyStockPick
                        {
                            stockCounter = varCounter,
                            currentPrice = Math.Round(varCurrentPrice, 2),
                            targetPrice = Math.Round(varCurrentPrice * Decimal.Parse("1.16"), 2),
                            stopLossPrice = Math.Round(varCurrentPrice * Decimal.Parse("0.92"), 2)
                        });
                    }

                    if (line.Contains(@"data-symbol=""HKEX:"))
                    {
                        startPos = line.IndexOf(@"data-symbol=""HKEX:") + 18;
                        endPos = line.IndexOf(@"""", startPos - 3);
                        //varCounter = line.Substring(startPos, endPos - startPos);
                        Console.WriteLine(counter);
                        //checkSequence = 2;


                    }
                }
            }


            // genericSendMail(stockPickListMY, "Daily Stock Pick - Singapore ");

        }
        //move files to zzzzz folder from donwload folder
        public static void moveFilesFromDownload()
        {
            string destFolder = @"C:\_Tasks\zzzzz";
            string sourceFolder = @"C:\Users\LiauS\Downloads";
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            // Get Files & Copy
            string[] files = Directory.GetFiles(sourceFolder, "* Historical Data*.csv");
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);

                // ADD Unique File Name Check to Below!!!!
                string dest = Path.Combine(destFolder, name);
                File.Move(file, dest);
            }


        }
        public static string getDateRange()
        {
            string month = DateTime.Now.Month.ToString().PadLeft(2, '0');
            string day = DateTime.Now.Day.ToString().PadLeft(2, '0');
            string year = DateTime.Now.Year.ToString();

            string date = "01/01/2017 - " + month + "/" + day + "/" + year;

            return date;
        }


        public static void searchAndDownload(IWebDriver driver, string searchShortCode, string title, string detailLinkURL)
        {

            driver.FindElement(By.CssSelector(".searchText.arial_12.lightgrayFont.js-main-search-bar")).SendKeys(searchShortCode);
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);


            driver.FindElement(By.XPath("//span[@title='" + title + "']")).Click();
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.FindElement(By.XPath("//a[@href='/equities/" + detailLinkURL + "-historical-data']")).Click();



            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("document.getElementById('picker').setAttribute('value', '" + getDateRange() + "')");


            driver.FindElement(By.XPath("//div[@id='widgetFieldDateRange']")).Click();

            IJavaScriptExecutor js2 = driver as IJavaScriptExecutor;
            //js.ExecuteScript("document.getElementById('widgetFieldDateRange').innerHTML = '01/01/2017 - 12/30/2019';");
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            IWebElement element = driver.FindElement(By.Id("applyBtn"));


            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Perform();
            //driver.FindElement(By.Id("applyBtn")).Click();
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//a[@title='Download Data']")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);


        }

        public static void SearchAndDownloadV2(string url, IWebDriver driver)
        {
            Thread.Sleep(5000);
            //driver.Navigate(url);
            driver.Url = url;
            #region change date range
            /*
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement elementDatePicker = driver.FindElement(By.Id("picker"));
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            js.ExecuteScript("arguments[0].setAttribute(arguments[1],arguments[2]);",elementDatePicker,"value",getDateRange());

            
            
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[@id='widgetField']")).Click();
            Thread.Sleep(15000);
            IWebElement element = driver.FindElement(By.Id("applyBtn"));
            

            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Perform();
            //driver.FindElement(By.Id("applyBtn")).Click();
            */
            #endregion

            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//a[@title='Download Data']")).Click();
        }

        public static void Login(string url, IWebDriver driver)
        {
            driver.Url = url;
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            driver.FindElement(By.Id("frmLogin_userID")).SendKeys("watlaoyeh80");
            driver.FindElement(By.Id("frmLogin_password")).SendKeys("abracadabra");

            SelectElement tradingSystem = new SelectElement(driver.FindElement(By.Name("selTradingHall")));
            tradingSystem.SelectByValue("tcplus_old");


            //driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            //Actions action = new Actions(driver);
            //IWebElement link = driver.FindElement(By.XPath("//input[@type='submit']"));
            //action.Click(link).DoubleClick();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));


            Thread.Sleep(20000);
            driver.FindElement(By.Id("button-1046")).Click();

        }
        public static void SharesSelection(string url, IWebDriver driver)
        {

            driver.Url = url;
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            driver.FindElement(By.Id("screenercustomstrategyname")).Click();
            driver.FindElement(By.XPath("//div[@title='New Strategy 10']")).Click();

            driver.FindElement(By.Id("globalstockscreener_result_export")).Click();
        }

    }
}
