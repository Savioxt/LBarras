using System;
using System.Net;

class LBarras
{
    static void Main(){
        //==========================SSL HTTPS====================================
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        //=========================================================================

        //=====================================WebClient============================
        WebClient client = new WebClient();
        client.Headers["Content-type"]="application/x-www-form-urlencoded";
        client.Headers["User-Agent"]="Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/118.0";
        client.Encoding = System.Text.Encoding.UTF8;
        string resposta = client.DownloadString("https://cosmos.bluesoft.com.br/produtos/7896401100011");
        //===================================================================================================================

        //===============Tratamento Dos Dados====================================
        int index1 = 7+resposta.IndexOf("<title>");
        int index2 = resposta.IndexOf("GTIN/EAN/UPC")-49;
        int index3 = resposta.IndexOf("NCM:");
        string NomeProduto = resposta.Substring(index1,index2);
        string NCM = resposta.Substring(index3,15);
        Console.WriteLine(NomeProduto);
        Console.WriteLine(NCM);
    }
}    