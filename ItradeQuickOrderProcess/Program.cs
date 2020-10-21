using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ItradeQuickOrderProcess
{
    class Program
    {
        static void Main(string[] args)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://secure8.itradecimb.com.my/gcCIMBNEW/tcplus/trade2.jsp");
            request.Method = "POST";
          

            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            request.Host = "secure8.itradecimb.com.my";
            request.KeepAlive = true;
            request.ContentLength = 487;
            request.Accept =  "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.125 Safari/537.36";
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            request.Headers.Add("Origin", "https://secure8.itradecimb.com.my");
            request.Headers.Add("Sec-Fetch-Site", "same-origin");
            request.Headers.Add("Sec-Fetch-Mode", "cors");
            request.Headers.Add("Sec-Fetch-Dest", "empty");
            request.Referer = "https://secure8.itradecimb.com.my/gcCIMBNEW/tcplus/main.jsp?lang=en&basic=&ts=1598367601049";
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Accept-Language", "1");
            request.Headers.Add("Cookie", @"indices.sLastScrollerPos=871px; JSESSIONID=C76DBEA7C40FEDE538E00A313305E559.P3_2; lang={""trdPhase"":""""}; _ga=GA1.3.2107224242.1585622139; watlaoyeh80_LastFont=Helvetica{12; watlaoyeh80_defTrAcc=KL{1,000113295~001,000113295~001; intercom-id-bzfz65lp=239dd53e-3086-43e1-a0a5-6db8e747420c; watlaoyeh80_v4d_col_quoteKL=10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|30|31|32|33|34|35|42|43|44|45|46|47|48|49|50|51|52|53|54|60|01|02|03|04|05|06|07|08|09|br,129|58|151|129|30|56|131|55|151|55|35|40|129|60|129|30|40|85|50|55|48|48|146|160|76|60|60|60|65|60|65|65|45|75|60|85|80|53|115|54|48|53|48|78|62|70|50; dbsColState=1=60,2=75,3=75,4=75,5=75,6=50,7=210; watlaoyeh80_MenuRowSettings=tbSI,tbPrtf,tbOS,tbWL,tbTools,tbSell,tbBuy,tbNews2,tbCht,tbMenuReports,tbMenuAnalysis,tbMS,tbQS,tbFund,tbEx,tbSett,tbCalc,tbLog; watlaoyeh80_v4d_col_equityPrtf=10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27|28|01|02|03|04|05|06|07|08|09,60|60|103|60|96|90|50|105|104|159|164|100|40|65|65|93|103|85|65|122|113|108|110|116|122|78|111|65; intercom-session-bzfz65lp=; _gid=GA1.3.178779880.1598286397; watlaoyeh80_defTrAccSync=false");

            string postData = "ex=KL&act=B&tktno=&ordno=&subordno=&stkcode=7035.KL&ac=000113295&cc=A22176&lotsize=400&validity=Day&gtd=&pin2=33eb17a73e7f7e51b5cd4eeaeeb1e23d8d5256d9734f275494aa00f45ce98702&confirm=&ordsource=&prevaction=&branchcode=&unmtqty=&mtqty=&brokercode=&accountno_label2=MYR%2010%2C357.00&searchautobox-1531-inputEl=7035.KL&accountno=000113295%20-%20LIAU%20SHEAU%20CHANG%20-%20001&cbAction=B&otype=Limit&tptype=&stoplimit=&tpdirection=&quantity=1&price=0.295&settcurr=MYR&cbValidity=Day&payment=";
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(postData);
            request.ContentLength = bytes.Length;
            Stream newStream = request.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            //using (var client = new HttpClient())
            //{
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded;charset=UTF-8"));
            //    client.DefaultRequestHeaders.Add("Accept", "*/*");

            //    var Parameters = new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("Host", "secure8.itradecimb.com.my"),
            //    new KeyValuePair<string, string>("Connection", "keep-alive"),
            //    new KeyValuePair<string, string>("Content-Length", "487"),
            //    new KeyValuePair<string, string>("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.125 Safari/537.36"),
            //    new KeyValuePair<string, string>("X-Requested-With", "XMLHttpRequest"),
            //    new KeyValuePair<string, string>("Origin", "https://secure8.itradecimb.com.my"),
            //    new KeyValuePair<string, string>("Sec-Fetch-Site", "same-origin"),
            //    new KeyValuePair<string, string>("Sec-Fetch-Mode", "cors"),
            //    new KeyValuePair<string, string>("Sec-Fetch-Dest", "empty"),
            //    new KeyValuePair<string, string>("Referer", "https://secure8.itradecimb.com.my/gcCIMBNEW/tcplus/main.jsp?lang=en&basic=&ts=1598367601049"),
            //    new KeyValuePair<string, string>("Accept-Encoding", "gzip, deflate, br"),
            //    new KeyValuePair<string, string>("Accept-Language", "1"),
            //    new KeyValuePair<string, string>("Cookie", @"indices.sLastScrollerPos=871px; JSESSIONID=C76DBEA7C40FEDE538E00A313305E559.P3_2; lang={""trdPhase"":""""}; _ga=GA1.3.2107224242.1585622139; watlaoyeh80_LastFont=Helvetica{12; watlaoyeh80_defTrAcc=KL{1,000113295~001,000113295~001; intercom-id-bzfz65lp=239dd53e-3086-43e1-a0a5-6db8e747420c; watlaoyeh80_v4d_col_quoteKL=10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|30|31|32|33|34|35|42|43|44|45|46|47|48|49|50|51|52|53|54|60|01|02|03|04|05|06|07|08|09|br,129|58|151|129|30|56|131|55|151|55|35|40|129|60|129|30|40|85|50|55|48|48|146|160|76|60|60|60|65|60|65|65|45|75|60|85|80|53|115|54|48|53|48|78|62|70|50; dbsColState=1=60,2=75,3=75,4=75,5=75,6=50,7=210; watlaoyeh80_MenuRowSettings=tbSI,tbPrtf,tbOS,tbWL,tbTools,tbSell,tbBuy,tbNews2,tbCht,tbMenuReports,tbMenuAnalysis,tbMS,tbQS,tbFund,tbEx,tbSett,tbCalc,tbLog; watlaoyeh80_v4d_col_equityPrtf=10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27|28|01|02|03|04|05|06|07|08|09,60|60|103|60|96|90|50|105|104|159|164|100|40|65|65|93|103|85|65|122|113|108|110|116|122|78|111|65; intercom-session-bzfz65lp=; _gid=GA1.3.178779880.1598286397; watlaoyeh80_defTrAccSync=false"),
            //};

            //    var Request = new HttpRequestMessage(HttpMethod.Post, @"https://secure8.itradecimb.com.my/gcCIMBNEW/tcplus/trade2.jsp")
            //    {
            //        Content = new FormUrlEncodedContent(Parameters),

            //    };

            //    var Result = client.SendAsync(Request).Result.Content.ReadAsStringAsync();
            //}
        }
    }
}

