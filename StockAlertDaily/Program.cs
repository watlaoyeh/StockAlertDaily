using System;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;


namespace StockAlertDaily
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=localhost;Initial Catalog=StockMarket;Integrated Security=True"; //Connection 

            SqlCommand cmd = new SqlCommand("BUY_ALERT", sqlConnection);
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
                "<td> <b>LatestDate<b> </td>" +
                 "<td><b>LatestPrice</b></td> " +
                //"<td> <b>Change</b> </td>" +
                //  "<td><b>ChangePercent</b></td> " +
                //"<td> <b>PercentageBetterEntry</b> </td>" +
                 "<td><b>Action</b></td> " +
                //"<td> <b>LotNoFinal</b> </td>" +
                  //"<td><b>AccumulatedProfitAndLoss</b></td> " +
                "<td> <b>Recommendation</b> </td>" +
                "</tr>";
     
            for (int loopCount = 0; loopCount < dt.Rows.Count; loopCount++)
            {
                textBody += "<tr>" +
                    "<td>" + dt.Rows[loopCount]["StockName"] + "</td>" +
                    "<td> " + dt.Rows[loopCount]["ReferenceBuyDate"] + "</td> " +
                    "<td>" + dt.Rows[loopCount]["ReferenceBuyPrice"] + "</td>" +
                    "<td> " + dt.Rows[loopCount]["LatestDate"] + "</td> " +
                    "<td>" + dt.Rows[loopCount]["LatestPrice"] + "</td>" +
                    //"<td> " + dt.Rows[loopCount]["Change"] + "</td> " +
                    //"<td>" + dt.Rows[loopCount]["ChangePercent"] + "</td>" +
                    //"<td> " + dt.Rows[loopCount]["PercentageBetterEntry"] + "</td> " +
                    "<td>" + dt.Rows[loopCount]["ACTION"] + "</td>" +
                    //"<td> " + dt.Rows[loopCount]["LotNoFinal"] + "</td> " +
                    //"<td>" + dt.Rows[loopCount]["AccumulatedProfitAndLoss"] + "</td>" +
                    "<td> " + dt.Rows[loopCount]["Recommend"] + "</td> " +
                    "</tr>";
            }
            textBody += "</table>";


            SqlCommand cmd2 = new SqlCommand("SELL_ALERT", sqlConnection);
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
                //"<td><b>ReferenceBuyDate</b></td> " +
                //"<td><b>ReferenceBuyPrice</b></td> " +
                //"<td><b>ReferenceSellDate</b></td> " +
                //"<td><b>ReferenceSellPrice</b></td> " +
                "<td><b>LatestDate</b></td> " +
                "<td><b>LatestPrice</b></td> " +
                //"<td><b>PriceDiff</b></td> " +
                //"<td><b>ChangePercent</b></td> " +
                //"<td><b>PercentageSellingEntry</b></td> " +
                //"<td><b>DiffWithBuyRefPrice</b></td> " +
                "<td><b>Action</b></td> " +
                "<td><b>LotNoFinal</b></td> " +
                //"<td><b>TransactionProfitAndLoss</b></td> " +
                //"<td><b>AccumulatedProfitAndLoss</b></td> " +
                "<td><b>Recommendation</b></td> " +
               "</tr>";
          
            for (int loopCount = 0; loopCount < dt2.Rows.Count; loopCount++)
            {
                textBody2 += "<tr>" +
                    "<td>" + dt2.Rows[loopCount]["StockName"] + "</td>" +
                    //"<td> " + dt2.Rows[loopCount]["ReferenceBuyDate"] + "</td> " +
                    //"<td>" + dt2.Rows[loopCount]["ReferenceBuyPrice"] + "</td>" +
                    //"<td> " + dt2.Rows[loopCount]["ReferenceSellDate"] + "</td> " +
                    //"<td>" + dt2.Rows[loopCount]["ReferenceSellPrice"] + "</td>" +
                    "<td> " + dt2.Rows[loopCount]["LatestDate"] + "</td> " +
                    "<td>" + dt2.Rows[loopCount]["LatestPrice"] + "</td>" +
                    //"<td> " + dt2.Rows[loopCount]["PriceDiff"] + "</td> " +
                    //"<td>" + dt2.Rows[loopCount]["ChangePercent"] + "</td>" +
                    //"<td> " + dt2.Rows[loopCount]["PercentageSellingEntry"] + "</td> " +
                    //"<td>" + dt2.Rows[loopCount]["DiffWithBuyRefPrice"] + "</td>" +
                    "<td> " + dt2.Rows[loopCount]["Action"] + "</td> " +
                    "<td>" + dt2.Rows[loopCount]["LotNoFinal"] + "</td>" +
                    //"<td> " + dt2.Rows[loopCount]["TransactionProfitAndLoss"] + "</td> " +
                    //"<td>" + dt2.Rows[loopCount]["AccumulatedProfitAndLoss"] + "</td>" +
                    "<td> " + dt2.Rows[loopCount]["Recommend"] + "</td> " +
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
            mail.Subject = "Stock Alert -  " + DateTime.Now.ToString("yyyy-MM-dd");
            mail.Body = "Hi members, please find the latest Stock Alert for your reference. <br /> "+
            "<br />  <h1>BUY ALERT<h1> <br /> "+ textBody+
            "<br />  <h1>SELL ALERT<h1> <br /> " + textBody2;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("liausheauchang@gmail.com", "EXCUSEme123$567");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;


            smtp.Timeout = 30000;
            smtp.Send(mail);
        } 
    }
}
