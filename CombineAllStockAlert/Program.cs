using System;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

namespace CombineAllStockAlert
{
    class Program
    {
        public static int NoOfDays = 1;
        static void Main(string[] args)
        {
            //Step1();
            //Step2();
            //Step3();
            //Step4();
            //Step5();
            //ride with bull
            Step6();

            //Step7_Afternoon();
            Step9_BuyOnDip_public();


            Step8_BuyOnDip();
           
        }

      
        private static void Step1()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=localhost;Initial Catalog=StockMarket;Integrated Security=True"; //Connection 

            SqlCommand cmd = new SqlCommand("BUY_ALERT_MACD", sqlConnection);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            using (var da = new SqlDataAdapter(cmd))
            {
                da.SelectCommand.CommandTimeout = 300;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }



            string textBody = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
                "<td><b>StockName</b></td> " +
                "<td> <b>ReferenceBuyDate</b> </td>" +
                  "<td><b>ReferenceBuyPrice</b></td> " +
                  "<td><b>Action</b></td> " +
                              "</tr>";

            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                textBody += "<tr>" +
                    "<td>" + dt.Rows[loopCount]["StockName"] + "</td>" +
                    "<td> " + dt.Rows[loopCount]["Date"] + "</td> " +
                    "<td> " + dt.Rows[loopCount]["Price"] + "</td> " +
                    "<td>" + dt.Rows[loopCount]["REAL_ACTION"] + "</td>" +
                    "</tr>";
            }
            textBody += "</table>";


            SqlCommand cmd2 = new SqlCommand("SELL_ALERT_MACD", sqlConnection);
            DataTable dt2 = new DataTable();
            cmd2.CommandType = CommandType.StoredProcedure;

            using (var da = new SqlDataAdapter(cmd2))
            {
                da.SelectCommand.CommandTimeout = 300;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt2);
            }

            string textBody2 = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
                "<td><b>StockName</b></td> " +
                "<td><b>LatestDate</b></td> " +
                "<td><b>LatestPrice</b></td> " +
                "<td><b>Action</b></td> " +
               "</tr>";

            for (int loopCount = 0; loopCount < dt2.Rows.Count; loopCount++)
            {
                textBody2 += "<tr>" +
                    "<td>" + dt2.Rows[loopCount]["StockName"] + "</td>" +
                    "<td> " + dt2.Rows[loopCount]["Date"] + "</td> " +
                    "<td>" + dt2.Rows[loopCount]["Price"] + "</td>" +
                                      "<td> " + dt2.Rows[loopCount]["Action"] + "</td> " +

                    "</tr>";
            }
            textBody2 += "</table>";


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("liausheauchang@gmail.com", "Darren Liau");

            mail.To.Add("liausheauchang@hotmail.com");
            mail.To.Add("liausheauchang@gmail.com");
            mail.To.Add("lamchoonho@gmail.com");
            // mail.To.Add("liau.sheauhuey@gmail.com");

            mail.IsBodyHtml = true;
            mail.Subject = "Stock Alert (MACD Signal) -  " + DateTime.Now.AddDays(NoOfDays).ToString("yyyy-MM-dd");
            mail.Body = "Hi members, please find the latest Stock Alert for your reference. <br /> " +
            "<br />  <h1>BUY ALERT<h1> <br /> " + textBody +
            "<br />  <h1>SELL ALERT<h1> <br /> " + textBody2;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("liausheauchang@gmail.com", "abracadabra");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;


            smtp.Timeout = 30000;
            smtp.Send(mail);
        }

        private static void Step2()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=localhost;Initial Catalog=StockMarket;Integrated Security=True"; //Connection 

            SqlCommand cmd = new SqlCommand("Superb_Query_Buy_EMA_BY_TRIGGERDATE_FOR_CHOONHO", sqlConnection);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            using (var da = new SqlDataAdapter(cmd))
            {
                da.SelectCommand.CommandTimeout = 300;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }



            string textBody = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
                "<td><b>StockName</b></td> " +
                "<td> <b>LatestDate</b> </td>" +
                  "<td><b>LatestPrice</b></td> " +
                "<td> <b>TriggerBuyDate<b> </td>" +
                 "<td> <b>TriggerBuyPrice</b> </td>" +
                   "<td><b>ACTION</b></td> " +
                 "<td> <b>TargetPrice</b> </td>" +
                 "<td> <b>Status</b> </td>" +
                 "<td><b>PercentageChange</b></td> " +
                "</tr>";

            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                textBody += "<tr>" +
                    "<td>" + dt.Rows[loopCount]["StockName"] + "</td>" +
                    "<td> " + dt.Rows[loopCount]["LatestDate"] + "</td> " +
                    "<td>" + dt.Rows[loopCount]["LatestPrice"] + "</td>" +
                    "<td> " + dt.Rows[loopCount]["TriggerBuyDate"] + "</td> " +
                    "<td>" + dt.Rows[loopCount]["TriggerBuyPrice"] + "</td>" +
                    "<td>" + dt.Rows[loopCount]["ACTION"] + "</td>" +
                    "<td> " + dt.Rows[loopCount]["TargetPrice1"] + "</td> " +
                    "<td> " + dt.Rows[loopCount]["Status1"] + "</td> " +
                    "<td> " + dt.Rows[loopCount]["PercentageChange"] + "</td> " +
                    "</tr>";
            }
            textBody += "</table>";


            SqlCommand cmd2 = new SqlCommand("Superb_Query_Sell_EMA_BY_TRIGGERDATE_FOR_CHOONHO", sqlConnection);
            DataTable dt2 = new DataTable();
            cmd2.CommandType = CommandType.StoredProcedure;

            using (var da = new SqlDataAdapter(cmd2))
            {
                da.SelectCommand.CommandTimeout = 300;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt2);
            }

            string textBody2 = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
               "<td><b>StockName</b></td> " +
                "<td> <b>LatestDate</b> </td>" +
                  "<td><b>LatestPrice</b></td> " +
                "<td> <b>TriggerSellDate<b> </td>" +
                 "<td> <b>TriggerSellPrice</b> </td>" +
                   "<td><b>ACTION</b></td> " +
                 "<td> <b>StopLossPrice</b> </td>" +
                 "<td> <b>Status</b> </td>" +
                 "<td><b>PercentageChange</b></td> " +
               "</tr>";

            for (int loopCount = 0; loopCount < dt2.Rows.Count; loopCount++)
            {
                textBody2 += "<tr>" +
                      "<td>" + dt2.Rows[loopCount]["StockName"] + "</td>" +
                    "<td> " + dt2.Rows[loopCount]["LatestDate"] + "</td> " +
                    "<td>" + dt2.Rows[loopCount]["LatestPrice"] + "</td>" +
                    "<td> " + dt2.Rows[loopCount]["TriggerSellDate"] + "</td> " +
                    "<td>" + dt2.Rows[loopCount]["TriggerSellPrice"] + "</td>" +
                    "<td>" + dt2.Rows[loopCount]["ACTION"] + "</td>" +
                    "<td> " + dt2.Rows[loopCount]["StopLossPrice"] + "</td> " +
                    "<td> " + dt2.Rows[loopCount]["Status"] + "</td> " +
                    "<td> " + dt2.Rows[loopCount]["PercentageChange"] + "</td> " +
                    "</tr>";
            }
            textBody2 += "</table>";


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("liausheauchang@gmail.com", "Darren Liau");

            mail.To.Add("liausheauchang@hotmail.com");
            mail.To.Add("liausheauchang@gmail.com");
            mail.To.Add("lamchoonho@gmail.com");
            mail.To.Add("liau.sheauhuey@gmail.com");
            //mail.To.Add("d.dinesh0211@gmail.com");
            mail.IsBodyHtml = true;
            mail.Subject = "Stock Alert New Algorithm (Sort By TriggerDate) -  " + DateTime.Now.AddDays(NoOfDays).ToString("yyyy-MM-dd");
            mail.Body = "Hi members, please find the latest Stock Alert for your reference. <br /> " +
            "<br />  <h1>BUY ALERT<h1> <br /> " + textBody +
            "<br />  <h1>SELL ALERT<h1> <br /> " + textBody2;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("liausheauchang@gmail.com", "abracadabra");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;


            smtp.Timeout = 30000;
            smtp.Send(mail);
        }

        private static void Step3()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=localhost;Initial Catalog=StockMarket;Integrated Security=True"; //Connection 

            SqlCommand cmd = new SqlCommand("Superb_Query_Buy_EMA_BY_AGGR_DECLINE_FOR_DARREN", sqlConnection);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            using (var da = new SqlDataAdapter(cmd))
            {
                da.SelectCommand.CommandTimeout = 300;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }



            string textBody = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
                "<td><b>StockName</b></td> " +
                "<td> <b>LatestDate</b> </td>" +
                  "<td><b>LatestPrice</b></td> " +
                "<td> <b>TriggerBuyDate<b> </td>" +
                 "<td> <b>TriggerBuyPrice</b> </td>" +
                   "<td><b>ACTION</b></td> " +
                 "<td> <b>TargetPrice</b> </td>" +
                 "<td> <b>Status</b> </td>" +
                 "<td><b>PercentageChange</b></td> " +
                 "<td><b>AggregatePercentChange</b></td> " +
                 "<td><b>VolumePercentChange</b></td> " +
                "</tr>";

            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                textBody += "<tr>" +
                    "<td>" + dt.Rows[loopCount]["StockName"] + "</td>" +
                    "<td> " + dt.Rows[loopCount]["LatestDate"] + "</td> " +
                    "<td>" + dt.Rows[loopCount]["LatestPrice"] + "</td>" +
                    "<td> " + dt.Rows[loopCount]["TriggerBuyDate"] + "</td> " +
                    "<td>" + dt.Rows[loopCount]["TriggerBuyPrice"] + "</td>" +
                    "<td>" + dt.Rows[loopCount]["ACTION"] + "</td>" +
                    "<td> " + dt.Rows[loopCount]["TargetPrice"] + "</td> " +
                    "<td> " + dt.Rows[loopCount]["Status"] + "</td> " +
                    "<td> " + dt.Rows[loopCount]["PercentageChange"] + "</td> " +
                    "<td> " + dt.Rows[loopCount]["AggregatePercentChange"] + "</td> " +
                    "<td> " + dt.Rows[loopCount]["VolumePercentChange"] + "</td> " +
                    "</tr>";
            }
            textBody += "</table>";


            SqlCommand cmd2 = new SqlCommand("Superb_Query_Sell_EMA_BY_AGGR_DECLINE_FOR_DARREN", sqlConnection);
            DataTable dt2 = new DataTable();
            cmd2.CommandType = CommandType.StoredProcedure;

            using (var da = new SqlDataAdapter(cmd2))
            {
                da.SelectCommand.CommandTimeout = 300;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt2);
            }

            string textBody2 = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
               "<td><b>StockName</b></td> " +
                "<td> <b>LatestDate</b> </td>" +
                  "<td><b>LatestPrice</b></td> " +
                "<td> <b>TriggerSellDate<b> </td>" +
                 "<td> <b>TriggerSellPrice</b> </td>" +
                   "<td><b>ACTION</b></td> " +
                 "<td> <b>StopLossPrice</b> </td>" +
                 "<td> <b>Status</b> </td>" +
                 "<td><b>PercentageChange</b></td> " +
                  "<td><b>AggregatePercentChange</b></td> " +
                 "<td><b>VolumePercentChange</b></td> " +
               "</tr>";

            for (int loopCount = 0; loopCount < dt2.Rows.Count; loopCount++)
            {
                textBody2 += "<tr>" +
                      "<td>" + dt2.Rows[loopCount]["StockName"] + "</td>" +
                    "<td> " + dt2.Rows[loopCount]["LatestDate"] + "</td> " +
                    "<td>" + dt2.Rows[loopCount]["LatestPrice"] + "</td>" +
                    "<td> " + dt2.Rows[loopCount]["TriggerSellDate"] + "</td> " +
                    "<td>" + dt2.Rows[loopCount]["TriggerSellPrice"] + "</td>" +
                    "<td>" + dt2.Rows[loopCount]["ACTION"] + "</td>" +
                    "<td> " + dt2.Rows[loopCount]["StopLossPrice"] + "</td> " +
                    "<td> " + dt2.Rows[loopCount]["Status"] + "</td> " +
                    "<td> " + dt2.Rows[loopCount]["PercentageChange"] + "</td> " +
                     "<td> " + dt2.Rows[loopCount]["AggregatePercentChange"] + "</td> " +
                    "<td> " + dt2.Rows[loopCount]["VolumePercentChange"] + "</td> " +
                    "</tr>";
            }
            textBody2 += "</table>";


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("liausheauchang@gmail.com", "Darren Liau");

            mail.To.Add("liausheauchang@hotmail.com");
            mail.To.Add("liausheauchang@gmail.com");
            mail.To.Add("lamchoonho@gmail.com");
            mail.To.Add("liau.sheauhuey@gmail.com");
            //mail.To.Add("d.dinesh0211@gmail.com");
            mail.IsBodyHtml = true;
            mail.Subject = "Stock Alert New Algorithm (Sort By RecentPricePercentageChange) -  " + DateTime.Now.AddDays(NoOfDays).ToString("yyyy-MM-dd");
            mail.Body = "Hi members, please find the latest Stock Alert for your reference. <br /> " +
            "<br />  <h1>BUY ALERT<h1> <br /> " + textBody +
            "<br />  <h1>SELL ALERT<h1> <br /> " + textBody2;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("liausheauchang@gmail.com", "abracadabra");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;


            smtp.Timeout = 30000;
            smtp.Send(mail);
        }

        private static void Step4()
        {

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=localhost;Initial Catalog=StockMarket;Integrated Security=True"; //Connection 

            SqlCommand cmd = new SqlCommand("Superb_Query_Buy_EMA_BY_AGGR_DECLINE_FOR_DARREN_FOR_LONGTERM", sqlConnection);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            using (var da = new SqlDataAdapter(cmd))
            {
                da.SelectCommand.CommandTimeout = 300;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }



            string textBody = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
                "<td><b>StockName</b></td> " +
                "<td> <b>LatestDate</b> </td>" +
                  "<td><b>LatestPrice</b></td> " +
                "<td> <b>TriggerBuyDate<b> </td>" +
                 "<td> <b>TriggerBuyPrice</b> </td>" +
                   "<td><b>ACTION</b></td> " +
                 "<td> <b>TargetPrice</b> </td>" +
                 "<td> <b>Status</b> </td>" +
                 "<td><b>PercentageChange</b></td> " +
                 "<td><b>AggregatePercentChange</b></td> " +
                 "<td><b>VolumePercentChange</b></td> " +
                "</tr>";

            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                textBody += "<tr>" +
                    "<td>" + dt.Rows[loopCount]["StockName"] + "</td>" +
                    "<td> " + dt.Rows[loopCount]["LatestDate"] + "</td> " +
                    "<td>" + dt.Rows[loopCount]["LatestPrice"] + "</td>" +
                    "<td> " + dt.Rows[loopCount]["TriggerBuyDate"] + "</td> " +
                    "<td>" + dt.Rows[loopCount]["TriggerBuyPrice"] + "</td>" +
                    "<td>" + dt.Rows[loopCount]["ACTION"] + "</td>" +
                    "<td> " + dt.Rows[loopCount]["TargetPrice"] + "</td> " +
                    "<td> " + dt.Rows[loopCount]["Status"] + "</td> " +
                    "<td> " + dt.Rows[loopCount]["PercentageChange"] + "</td> " +
                    "<td> " + dt.Rows[loopCount]["AggregatePercentChange"] + "</td> " +
                    "<td> " + dt.Rows[loopCount]["VolumePercentChange"] + "</td> " +
                    "</tr>";
            }
            textBody += "</table>";


            SqlCommand cmd2 = new SqlCommand("Superb_Query_Sell_EMA_BY_AGGR_DECLINE_FOR_DARREN_FOR_LONGTERM", sqlConnection);
            DataTable dt2 = new DataTable();
            cmd2.CommandType = CommandType.StoredProcedure;

            using (var da = new SqlDataAdapter(cmd2))
            {
                da.SelectCommand.CommandTimeout = 300;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt2);
            }

            string textBody2 = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
               "<td><b>StockName</b></td> " +
                "<td> <b>LatestDate</b> </td>" +
                  "<td><b>LatestPrice</b></td> " +
                "<td> <b>TriggerSellDate<b> </td>" +
                 "<td> <b>TriggerSellPrice</b> </td>" +
                   "<td><b>ACTION</b></td> " +
                 "<td> <b>StopLossPrice</b> </td>" +
                 "<td> <b>Status</b> </td>" +
                 "<td><b>PercentageChange</b></td> " +
                  "<td><b>AggregatePercentChange</b></td> " +
                 "<td><b>VolumePercentChange</b></td> " +
               "</tr>";

            for (int loopCount = 0; loopCount < dt2.Rows.Count; loopCount++)
            {
                textBody2 += "<tr>" +
                      "<td>" + dt2.Rows[loopCount]["StockName"] + "</td>" +
                    "<td> " + dt2.Rows[loopCount]["LatestDate"] + "</td> " +
                    "<td>" + dt2.Rows[loopCount]["LatestPrice"] + "</td>" +
                    "<td> " + dt2.Rows[loopCount]["TriggerSellDate"] + "</td> " +
                    "<td>" + dt2.Rows[loopCount]["TriggerSellPrice"] + "</td>" +
                    "<td>" + dt2.Rows[loopCount]["ACTION"] + "</td>" +
                    "<td> " + dt2.Rows[loopCount]["StopLossPrice"] + "</td> " +
                    "<td> " + dt2.Rows[loopCount]["Status"] + "</td> " +
                    "<td> " + dt2.Rows[loopCount]["PercentageChange"] + "</td> " +
                     "<td> " + dt2.Rows[loopCount]["AggregatePercentChange"] + "</td> " +
                    "<td> " + dt2.Rows[loopCount]["VolumePercentChange"] + "</td> " +
                    "</tr>";
            }
            textBody2 += "</table>";


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("liausheauchang@gmail.com", "Darren Liau");

            mail.To.Add("liausheauchang@hotmail.com");
            mail.To.Add("liausheauchang@gmail.com");
            mail.To.Add("lamchoonho@gmail.com");
            mail.To.Add("liau.sheauhuey@gmail.com");
            //mail.To.Add("d.dinesh0211@gmail.com");
            mail.IsBodyHtml = true;
            mail.Subject = "Stock Alert New Algorithm (Sort By TriggerPricePercentageChange) -  " + DateTime.Now.AddDays(NoOfDays).ToString("yyyy-MM-dd");
            mail.Body = "Hi members, please find the latest Stock Alert for your reference. <br /> " +
            "<br />  <h1>BUY ALERT<h1> <br /> " + textBody +
            "<br />  <h1>SELL ALERT<h1> <br /> " + textBody2;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("liausheauchang@gmail.com", "abracadabra");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;


            smtp.Timeout = 30000;
            smtp.Send(mail);
        }
        private static void Step5()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=localhost;Initial Catalog=StockMarket;Integrated Security=True"; //Connection 

            SqlCommand cmd = new SqlCommand("Superb_Query_Buy_EMA_BY_TRIGGERDATE_FOR_CHOONHO", sqlConnection);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            using (var da = new SqlDataAdapter(cmd))
            {
                da.SelectCommand.CommandTimeout = 300;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }



            string textBody = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
                 "<td> <b>LatestDate</b> </td>" +
                "<td><b>StockName</b></td> " +
                "<td> <b>EntryPrice</b> </td>" +
                       "<td> <b>EntryDate<b> </td>" +
                       "<td><b>Highest</b></td> " +
                  "<td><b>At</b></td> " +
                  "<td><b>Highest %</b></td> " +

                  "<td><b>Now</b></td> " +
                  "<td><b>Now %</b></td> " +

                 //"<td><b>ACTION</b></td> " +
                 "<td> <b>TP1</b> </td>" +
          "<td> <b>TP2</b> </td>" +
            "<td> <b>TP3</b> </td>" +
              "<td> <b>TP4</b> </td>" +
                "</tr>";

            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                textBody += "<tr>" +
                      //"<td> " + DateTime.ParseExact(dt.Rows[loopCount]["LatestDate"].ToString(),"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + "</td> " +
                        "<td> " + DateTime.Parse(dt.Rows[loopCount]["LatestDate"].ToString()).ToString("yyyy-MM-dd") + "</td> " +
                    "<td>" + dt.Rows[loopCount]["StockName"] + "</td>" +
                   "<td>" + dt.Rows[loopCount]["TriggerBuyPrice"] + "</td>" +
                     //"<td> " + DateTime.ParseExact(dt.Rows[loopCount]["TriggerBuyDate"].ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + "</td> " +
                 "<td> " + DateTime.Parse(dt.Rows[loopCount]["TriggerBuyDate"].ToString()).ToString("yyyy-MM-dd") + "</td> " +

                    
                       "<td>" + dt.Rows[loopCount]["High"] + "</td>" +
                       //"<td> " + DateTime.ParseExact(dt.Rows[loopCount]["HighDate"].ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + "</td> " +
                        "<td> " + DateTime.Parse(dt.Rows[loopCount]["HighDate"].ToString()).ToString("yyyy-MM-dd") + "</td> " +
                       ((dt.Rows[loopCount]["PercentHigh"].ToString() == "HIT") ? "<td style='background-color: #66ff99'> " : "<td style='background-color: #ff6699'> ") + dt.Rows[loopCount]["DiffPerFromEntryToHighest"] + "</td> " +

                    "<td>" + dt.Rows[loopCount]["LatestPrice"] + "</td>" +
                            ((dt.Rows[loopCount]["PercentNow"].ToString() == "HIT") ? "<td style='background-color: #66ff99'> " : "<td style='background-color: #ff6699'> ") + dt.Rows[loopCount]["PercentageChange"] + "</td> " +

                    //"<td>" + dt.Rows[loopCount]["ACTION"] + "</td>" +

                    ((dt.Rows[loopCount]["Status1"].ToString() == "HIT") ? "<td style='background-color: yellow'> " : "<td> ") + dt.Rows[loopCount]["TargetPrice1"] + "</td> " +
                    ((dt.Rows[loopCount]["Status2"].ToString() == "HIT") ? "<td style='background-color: yellow'> " : "<td> ") + dt.Rows[loopCount]["TargetPrice2"] + "</td> " +
                    ((dt.Rows[loopCount]["Status3"].ToString() == "HIT") ? "<td style='background-color: yellow'> " : "<td> ") + dt.Rows[loopCount]["TargetPrice3"] + "</td> " +
                    ((dt.Rows[loopCount]["Status4"].ToString() == "HIT") ? "<td style='background-color: yellow'> " : "<td> ") + dt.Rows[loopCount]["TargetPrice4"] + "</td> " +


                    "</tr>";
            }
            textBody += "</table>";


            //SqlCommand cmd2 = new SqlCommand("Superb_Query_Sell_EMA_BY_TRIGGERDATE_FOR_CHOONHO", sqlConnection);
            //DataTable dt2 = new DataTable();
            //cmd2.CommandType = CommandType.StoredProcedure;

            //using (var da = new SqlDataAdapter(cmd2))
            //{
            //    da.SelectCommand.CommandTimeout = 300;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    da.Fill(dt2);
            //}

            //string textBody2 = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
            //   "<td><b>StockName</b></td> " +
            //    "<td> <b>LatestDate</b> </td>" +
            //      "<td><b>LatestPrice</b></td> " +
            //    "<td> <b>TriggerSellDate<b> </td>" +
            //     "<td> <b>TriggerSellPrice</b> </td>" +
            //       "<td><b>ACTION</b></td> " +
            //     "<td> <b>StopLossPrice</b> </td>" +
            //     "<td> <b>Status</b> </td>" +
            //     "<td><b>PercentageChange</b></td> " +
            //   "</tr>";

            //for (int loopCount = 0; loopCount < dt2.Rows.Count; loopCount++)
            //{
            //    textBody2 += "<tr>" +
            //          "<td>" + dt2.Rows[loopCount]["StockName"] + "</td>" +
            //        "<td> " + dt2.Rows[loopCount]["LatestDate"] + "</td> " +
            //        "<td>" + dt2.Rows[loopCount]["LatestPrice"] + "</td>" +
            //        "<td> " + dt2.Rows[loopCount]["TriggerSellDate"] + "</td> " +
            //        "<td>" + dt2.Rows[loopCount]["TriggerSellPrice"] + "</td>" +
            //        "<td>" + dt2.Rows[loopCount]["ACTION"] + "</td>" +
            //        "<td> " + dt2.Rows[loopCount]["StopLossPrice"] + "</td> " +
            //        "<td> " + dt2.Rows[loopCount]["Status"] + "</td> " +
            //        "<td> " + dt2.Rows[loopCount]["PercentageChange"] + "</td> " +
            //        "</tr>";
            //}
            //textBody2 += "</table>";


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("liausheauchang@gmail.com", "Darren Liau");

            mail.To.Add("liausheauchang@hotmail.com");
            mail.To.Add("liausheauchang@gmail.com");
            mail.To.Add("lamchoonho@gmail.com");
            //mail.To.Add("liau.sheauhuey@gmail.com");
            //mail.To.Add("d.dinesh0211@gmail.com");
            mail.IsBodyHtml = true;
            mail.Subject = "####New Updates####Stock Alert New Algorithm (Sort By TriggerDate) -  " + DateTime.Now.AddDays(NoOfDays).ToString("yyyy-MM-dd");
            mail.Body = "Hi members, please find the latest Stock Alert for your reference. <br /> " +
            "<br />  <h1>BUY ALERT<h1> <br /> " + textBody;
            //+
            //"<br />  <h1>SELL ALERT<h1> <br /> " + textBody2;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("liausheauchang@gmail.com", "abracadabra");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;


            smtp.Timeout = 30000;
            smtp.Send(mail);
        }

        private static void Step6()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=localhost;Initial Catalog=StockMarket;Integrated Security=True"; //Connection 

            SqlCommand cmd = new SqlCommand("DailyStockAlert2020", sqlConnection);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            using (var da = new SqlDataAdapter(cmd))
            {
                da.SelectCommand.CommandTimeout = 300;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }



            string textBody = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
                 "<td> <b>LatestDate</b> </td>" +
                "<td><b>StockName</b></td> " +
                "<td> <b>EntryPrice</b> </td>" +
                    
                       "<td><b>Target Price</b></td> " +
                  "<td><b>Stop Loss</b></td> " +
                  "<td><b>Bull Day</b></td> " +
                "</tr>";

            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                textBody += "<tr>" +
                        //"<td> " + DateTime.ParseExact(dt.Rows[loopCount]["LatestDate"].ToString(),"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + "</td> " +
                        "<td> " + DateTime.Parse(dt.Rows[loopCount]["Date"].ToString()).ToString("yyyy-MM-dd") + "</td> " +
                    "<td>" + dt.Rows[loopCount]["StockName"] + "</td>" +
                   "<td>" + Convert.ToDouble(dt.Rows[loopCount]["Price"]).ToString("N2") + "</td>" +
                    "<td>" + (Convert.ToDouble(dt.Rows[loopCount]["Price"])*1.12).ToString("N2") + "</td>" +
                     "<td>" + (Convert.ToDouble(dt.Rows[loopCount]["Price"])*0.94).ToString("N2") + "</td>" +
                       "<td>" + dt.Rows[loopCount]["TrendDirection"] + "</td>" +
                    "</tr>";
            }
            textBody += "</table>";


            //SqlCommand cmd2 = new SqlCommand("Superb_Query_Sell_EMA_BY_TRIGGERDATE_FOR_CHOONHO", sqlConnection);
            //DataTable dt2 = new DataTable();
            //cmd2.CommandType = CommandType.StoredProcedure;

            //using (var da = new SqlDataAdapter(cmd2))
            //{
            //    da.SelectCommand.CommandTimeout = 300;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    da.Fill(dt2);
            //}

            //string textBody2 = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
            //   "<td><b>StockName</b></td> " +
            //    "<td> <b>LatestDate</b> </td>" +
            //      "<td><b>LatestPrice</b></td> " +
            //    "<td> <b>TriggerSellDate<b> </td>" +
            //     "<td> <b>TriggerSellPrice</b> </td>" +
            //       "<td><b>ACTION</b></td> " +
            //     "<td> <b>StopLossPrice</b> </td>" +
            //     "<td> <b>Status</b> </td>" +
            //     "<td><b>PercentageChange</b></td> " +
            //   "</tr>";

            //for (int loopCount = 0; loopCount < dt2.Rows.Count; loopCount++)
            //{
            //    textBody2 += "<tr>" +
            //          "<td>" + dt2.Rows[loopCount]["StockName"] + "</td>" +
            //        "<td> " + dt2.Rows[loopCount]["LatestDate"] + "</td> " +
            //        "<td>" + dt2.Rows[loopCount]["LatestPrice"] + "</td>" +
            //        "<td> " + dt2.Rows[loopCount]["TriggerSellDate"] + "</td> " +
            //        "<td>" + dt2.Rows[loopCount]["TriggerSellPrice"] + "</td>" +
            //        "<td>" + dt2.Rows[loopCount]["ACTION"] + "</td>" +
            //        "<td> " + dt2.Rows[loopCount]["StopLossPrice"] + "</td> " +
            //        "<td> " + dt2.Rows[loopCount]["Status"] + "</td> " +
            //        "<td> " + dt2.Rows[loopCount]["PercentageChange"] + "</td> " +
            //        "</tr>";
            //}
            //textBody2 += "</table>";


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("liausheauchang@gmail.com", "Darren Liau");

            mail.To.Add("liausheauchang@hotmail.com");
            mail.To.Add("liausheauchang@gmail.com");
            mail.To.Add("lamchoonho@gmail.com");
            //mail.To.Add("liau.sheauhuey@gmail.com");
            //mail.To.Add("d.dinesh0211@gmail.com");
            mail.IsBodyHtml = true;
            mail.Subject = "*********New Features******Bull Ride with the Shark - Short Term Trading " + DateTime.Now.AddDays(NoOfDays).ToString("yyyy-MM-dd");
            mail.Body = "Hi members, please find the latest Stock Alert features for your reference. <br /> " +
            "<br />  <h1>BUY ALERT<h1> <br /> " + textBody;
            //+
            //"<br />  <h1>SELL ALERT<h1> <br /> " + textBody2;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("liausheauchang@gmail.com", "abracadabra");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;


            smtp.Timeout = 30000;
            smtp.Send(mail);
        }
        private static void Step7_Afternoon()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=localhost;Initial Catalog=StockMarket;Integrated Security=True"; //Connection 

            SqlCommand cmd = new SqlCommand("DailyStockAlert2020", sqlConnection);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            using (var da = new SqlDataAdapter(cmd))
            {
                da.SelectCommand.CommandTimeout = 300;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }



            string textBody = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
                 "<td> <b>LatestDate</b> </td>" +
                "<td><b>StockName</b></td> " +
                "<td> <b>EntryPrice</b> </td>" +

                       "<td><b>Target Price</b></td> " +
                  "<td><b>Stop Loss</b></td> " +
                  "<td><b>Bull Day</b></td> " +
                "</tr>";

            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                textBody += "<tr>" +
                        //"<td> " + DateTime.ParseExact(dt.Rows[loopCount]["LatestDate"].ToString(),"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + "</td> " +
                        "<td> " + DateTime.Parse(dt.Rows[loopCount]["Date"].ToString()).ToString("yyyy-MM-dd") + "</td> " +
                    "<td>" + dt.Rows[loopCount]["StockName"] + "</td>" +
                   "<td>" + Convert.ToDouble(dt.Rows[loopCount]["Price"]).ToString("N2") + "</td>" +
                    "<td>" + (Convert.ToDouble(dt.Rows[loopCount]["Price"]) * 1.12).ToString("N2") + "</td>" +
                     "<td>" + (Convert.ToDouble(dt.Rows[loopCount]["Price"]) * 0.94).ToString("N2") + "</td>" +
                       "<td>" + dt.Rows[loopCount]["TrendDirection"] + "</td>" +
                    "</tr>";
            }
            textBody += "</table>";


            //SqlCommand cmd2 = new SqlCommand("Superb_Query_Sell_EMA_BY_TRIGGERDATE_FOR_CHOONHO", sqlConnection);
            //DataTable dt2 = new DataTable();
            //cmd2.CommandType = CommandType.StoredProcedure;

            //using (var da = new SqlDataAdapter(cmd2))
            //{
            //    da.SelectCommand.CommandTimeout = 300;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    da.Fill(dt2);
            //}

            //string textBody2 = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
            //   "<td><b>StockName</b></td> " +
            //    "<td> <b>LatestDate</b> </td>" +
            //      "<td><b>LatestPrice</b></td> " +
            //    "<td> <b>TriggerSellDate<b> </td>" +
            //     "<td> <b>TriggerSellPrice</b> </td>" +
            //       "<td><b>ACTION</b></td> " +
            //     "<td> <b>StopLossPrice</b> </td>" +
            //     "<td> <b>Status</b> </td>" +
            //     "<td><b>PercentageChange</b></td> " +
            //   "</tr>";

            //for (int loopCount = 0; loopCount < dt2.Rows.Count; loopCount++)
            //{
            //    textBody2 += "<tr>" +
            //          "<td>" + dt2.Rows[loopCount]["StockName"] + "</td>" +
            //        "<td> " + dt2.Rows[loopCount]["LatestDate"] + "</td> " +
            //        "<td>" + dt2.Rows[loopCount]["LatestPrice"] + "</td>" +
            //        "<td> " + dt2.Rows[loopCount]["TriggerSellDate"] + "</td> " +
            //        "<td>" + dt2.Rows[loopCount]["TriggerSellPrice"] + "</td>" +
            //        "<td>" + dt2.Rows[loopCount]["ACTION"] + "</td>" +
            //        "<td> " + dt2.Rows[loopCount]["StopLossPrice"] + "</td> " +
            //        "<td> " + dt2.Rows[loopCount]["Status"] + "</td> " +
            //        "<td> " + dt2.Rows[loopCount]["PercentageChange"] + "</td> " +
            //        "</tr>";
            //}
            //textBody2 += "</table>";


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("liausheauchang@gmail.com", "Darren Liau");

            mail.To.Add("liausheauchang@hotmail.com");
            mail.To.Add("liausheauchang@gmail.com");
            mail.To.Add("lamchoonho@gmail.com");
            //mail.To.Add("liau.sheauhuey@gmail.com");
            //mail.To.Add("d.dinesh0211@gmail.com");
            mail.IsBodyHtml = true;
            mail.Subject = "*********New Features******Bull Ride with the Shark - Short Term Trading (2nd session) " + DateTime.Now.AddDays(NoOfDays).ToString("yyyy-MM-dd");
            mail.Body = "Hi members, please find the latest Stock Alert features for your reference. <br /> " +
            "<br />  <h1>BUY ALERT<h1> <br /> " + textBody;
            //+
            //"<br />  <h1>SELL ALERT<h1> <br /> " + textBody2;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("liausheauchang@gmail.com", "abracadabra");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;


            smtp.Timeout = 30000;
            smtp.Send(mail);
        }

        private static void Step8_BuyOnDip()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=localhost;Initial Catalog=StockMarket;Integrated Security=True"; //Connection 

            SqlCommand cmd = new SqlCommand("DailyStockAlert2020_LongTermOnDips_Uptrend", sqlConnection);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            using (var da = new SqlDataAdapter(cmd))
            {
                da.SelectCommand.CommandTimeout = 300;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }



            string textBody = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
                 "<td> <b>LatestDate</b> </td>" +
                "<td><b>StockName</b></td> " +
                "<td> <b>EntryPrice</b> </td>" +

                       "<td><b>Target Price</b></td> " +
                  "<td><b>Stop Loss</b></td> " +
                  "<td><b>**Bear Day***</b></td> " +
                        "<td><b>DayPrice%</b></td> " +
                   "<td><b>AggPrice%</b></td> " +
                   "<td><b>DayVolume%</b></td> " +
                "</tr>";

            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                textBody += "<tr>" +
                        //"<td> " + DateTime.ParseExact(dt.Rows[loopCount]["LatestDate"].ToString(),"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + "</td> " +
                        "<td> " + DateTime.Parse(dt.Rows[loopCount]["Date"].ToString()).ToString("yyyy-MM-dd") + "</td> " +
                    "<td>" + dt.Rows[loopCount]["StockName"] + "</td>" +
                   "<td>" + Convert.ToDouble(dt.Rows[loopCount]["Price"]).ToString("N2") + "</td>" +
                    "<td>" + (Convert.ToDouble(dt.Rows[loopCount]["Price"]) * 1.12).ToString("N2") + "</td>" +
                     "<td>" + (Convert.ToDouble(dt.Rows[loopCount]["Price"]) * 0.94).ToString("N2") + "</td>" +
                       "<td>" + dt.Rows[loopCount]["TrendDirection"] + "</td>" +
                         "<td>" + Convert.ToDouble(dt.Rows[loopCount]["Change"]).ToString("N2") + "</td>" +
                         "<td>" + Convert.ToDouble(dt.Rows[loopCount]["AggregatePercentChange"]).ToString("N2") + "</td>" +
                         "<td>" + Convert.ToDouble(dt.Rows[loopCount]["PercentInVolume"]).ToString("N2") + "</td>" +
                    "</tr>";
            }
            textBody += "</table>";


            //SqlCommand cmd2 = new SqlCommand("Superb_Query_Sell_EMA_BY_TRIGGERDATE_FOR_CHOONHO", sqlConnection);
            //DataTable dt2 = new DataTable();
            //cmd2.CommandType = CommandType.StoredProcedure;

            //using (var da = new SqlDataAdapter(cmd2))
            //{
            //    da.SelectCommand.CommandTimeout = 300;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    da.Fill(dt2);
            //}

            //string textBody2 = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
            //   "<td><b>StockName</b></td> " +
            //    "<td> <b>LatestDate</b> </td>" +
            //      "<td><b>LatestPrice</b></td> " +
            //    "<td> <b>TriggerSellDate<b> </td>" +
            //     "<td> <b>TriggerSellPrice</b> </td>" +
            //       "<td><b>ACTION</b></td> " +
            //     "<td> <b>StopLossPrice</b> </td>" +
            //     "<td> <b>Status</b> </td>" +
            //     "<td><b>PercentageChange</b></td> " +
            //   "</tr>";

            //for (int loopCount = 0; loopCount < dt2.Rows.Count; loopCount++)
            //{
            //    textBody2 += "<tr>" +
            //          "<td>" + dt2.Rows[loopCount]["StockName"] + "</td>" +
            //        "<td> " + dt2.Rows[loopCount]["LatestDate"] + "</td> " +
            //        "<td>" + dt2.Rows[loopCount]["LatestPrice"] + "</td>" +
            //        "<td> " + dt2.Rows[loopCount]["TriggerSellDate"] + "</td> " +
            //        "<td>" + dt2.Rows[loopCount]["TriggerSellPrice"] + "</td>" +
            //        "<td>" + dt2.Rows[loopCount]["ACTION"] + "</td>" +
            //        "<td> " + dt2.Rows[loopCount]["StopLossPrice"] + "</td> " +
            //        "<td> " + dt2.Rows[loopCount]["Status"] + "</td> " +
            //        "<td> " + dt2.Rows[loopCount]["PercentageChange"] + "</td> " +
            //        "</tr>";
            //}
            //textBody2 += "</table>";


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("liausheauchang@gmail.com", "Darren Liau");

            mail.To.Add("liausheauchang@hotmail.com");
            mail.To.Add("liausheauchang@gmail.com");
            //mail.To.Add("lamchoonho@gmail.com");
            //mail.To.Add("liau.sheauhuey@gmail.com");
            //mail.To.Add("d.dinesh0211@gmail.com");
            mail.IsBodyHtml = true;
            mail.Subject = "*********New Features******BuyOnDips Buy on Business " + DateTime.Now.AddDays(NoOfDays).ToString("yyyy-MM-dd");
            mail.Body = "Hi members, please find the latest Stock Alert features for your reference. <br /> " +
            "<br />  <h1>BUY ALERT<h1> <br /> " + textBody;
            //+
            //"<br />  <h1>SELL ALERT<h1> <br /> " + textBody2;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("liausheauchang@gmail.com", "abracadabra");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;


            smtp.Timeout = 30000;
            smtp.Send(mail);
        }

        private static void Step9_BuyOnDip_public()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=localhost;Initial Catalog=StockMarket;Integrated Security=True"; //Connection 

            SqlCommand cmd = new SqlCommand("[DailyStockAlert2020_LongTermOnDips_Uptrend_SharePublic_Above10percent]", sqlConnection);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            using (var da = new SqlDataAdapter(cmd))
            {
                da.SelectCommand.CommandTimeout = 300;
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }



            string textBody = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
                 "<td> <b>LatestDate</b> </td>" +
                "<td><b>StockName</b></td> " +
                "<td> <b>EntryPrice</b> </td>" +

                       "<td><b>Target Price</b></td> " +
                  "<td><b>Stop Loss</b></td> " +
                  "<td><b>**Bear Day***</b></td> " +
                        "<td><b>DayPrice%</b></td> " +
                   "<td><b>AggPrice%</b></td> " +
                   //"<td><b>DayVolume%</b></td> " +
                "</tr>";

            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                textBody += "<tr>" +
                        //"<td> " + DateTime.ParseExact(dt.Rows[loopCount]["LatestDate"].ToString(),"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + "</td> " +
                        "<td> " + DateTime.Parse(dt.Rows[loopCount]["Date"].ToString()).ToString("yyyy-MM-dd") + "</td> " +
                    "<td>" + dt.Rows[loopCount]["StockName"] + "</td>" +
                   "<td>" + Convert.ToDouble(dt.Rows[loopCount]["Price"]).ToString("N2") + "</td>" +
                    "<td>" + (Convert.ToDouble(dt.Rows[loopCount]["Price"]) * 1.12).ToString("N2") + "</td>" +
                     "<td>" + (Convert.ToDouble(dt.Rows[loopCount]["Price"]) * 0.94).ToString("N2") + "</td>" +
                       "<td>" + dt.Rows[loopCount]["TrendDirection"] + "</td>" +
                         "<td>" + Convert.ToDouble(dt.Rows[loopCount]["Change"]).ToString("N2") + "</td>" +
                         "<td>" + Convert.ToDouble(dt.Rows[loopCount]["AggregatePercentChange"]).ToString("N2") + "</td>" +
                         //"<td>" + Convert.ToDouble(dt.Rows[loopCount]["PercentInVolume"]).ToString("N2") + "</td>" +
                    "</tr>";
            }
            textBody += "</table>";


            //SqlCommand cmd2 = new SqlCommand("Superb_Query_Sell_EMA_BY_TRIGGERDATE_FOR_CHOONHO", sqlConnection);
            //DataTable dt2 = new DataTable();
            //cmd2.CommandType = CommandType.StoredProcedure;

            //using (var da = new SqlDataAdapter(cmd2))
            //{
            //    da.SelectCommand.CommandTimeout = 300;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    da.Fill(dt2);
            //}

            //string textBody2 = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'>" +
            //   "<td><b>StockName</b></td> " +
            //    "<td> <b>LatestDate</b> </td>" +
            //      "<td><b>LatestPrice</b></td> " +
            //    "<td> <b>TriggerSellDate<b> </td>" +
            //     "<td> <b>TriggerSellPrice</b> </td>" +
            //       "<td><b>ACTION</b></td> " +
            //     "<td> <b>StopLossPrice</b> </td>" +
            //     "<td> <b>Status</b> </td>" +
            //     "<td><b>PercentageChange</b></td> " +
            //   "</tr>";

            //for (int loopCount = 0; loopCount < dt2.Rows.Count; loopCount++)
            //{
            //    textBody2 += "<tr>" +
            //          "<td>" + dt2.Rows[loopCount]["StockName"] + "</td>" +
            //        "<td> " + dt2.Rows[loopCount]["LatestDate"] + "</td> " +
            //        "<td>" + dt2.Rows[loopCount]["LatestPrice"] + "</td>" +
            //        "<td> " + dt2.Rows[loopCount]["TriggerSellDate"] + "</td> " +
            //        "<td>" + dt2.Rows[loopCount]["TriggerSellPrice"] + "</td>" +
            //        "<td>" + dt2.Rows[loopCount]["ACTION"] + "</td>" +
            //        "<td> " + dt2.Rows[loopCount]["StopLossPrice"] + "</td> " +
            //        "<td> " + dt2.Rows[loopCount]["Status"] + "</td> " +
            //        "<td> " + dt2.Rows[loopCount]["PercentageChange"] + "</td> " +
            //        "</tr>";
            //}
            //textBody2 += "</table>";


            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("liausheauchang@gmail.com", "Darren Liau");

            mail.To.Add("liausheauchang@hotmail.com");
            mail.To.Add("liausheauchang@gmail.com");
            mail.To.Add("lamchoonho@gmail.com");
            //mail.To.Add("liau.sheauhuey@gmail.com");
            //mail.To.Add("d.dinesh0211@gmail.com");
            mail.IsBodyHtml = true;
            mail.Subject = "*********New Features******Buy On Dips(Good Bargain) Buy on Business " + DateTime.Now.AddDays(NoOfDays).ToString("yyyy-MM-dd");
            mail.Body = "Hi members, please find the latest Stock Alert features for your reference. <br /> " +
            "<br />  <h1>BUY ALERT<h1> <br /> " + textBody;
            //+
            //"<br />  <h1>SELL ALERT<h1> <br /> " + textBody2;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("liausheauchang@gmail.com", "abracadabra");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;


            smtp.Timeout = 30000;
            smtp.Send(mail);
        }
    }
}

   

