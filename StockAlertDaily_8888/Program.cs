using System;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;


namespace StockAlertDaily_8888
{
    class Program
    {
        static void Main(string[] args)
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
            //mail.To.Add("lamchoonho@gmail.com");
            //mail.To.Add("liau.sheauhuey@gmail.com");
            //mail.To.Add("d.dinesh0211@gmail.com");
            mail.IsBodyHtml = true;
            mail.Subject = "Stock Alert EXCLUSIVE FOR DARREN -  " + DateTime.Now.ToString("yyyy-MM-dd");
            mail.Body = "Hi members, please find the latest Stock Alert for your reference. <br /> " +
            "<br />  <h1>BUY ALERT<h1> <br /> " + textBody +
            "<br />  <h1>SELL ALERT<h1> <br /> " + textBody2;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("liausheauchang@gmail.com", "EXCUSEme123$567*90");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;


            smtp.Timeout = 30000;
            smtp.Send(mail);
        }
    }
}
