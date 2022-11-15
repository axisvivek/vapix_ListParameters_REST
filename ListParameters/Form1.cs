using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;


namespace ListParameters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Clear the rich text box every time the user clicks the Get Param button.
            
            richTextBox1.Text = "";
           

            //Create a string. The string will be used to pass the VAPIX(R) command to the Axis product.
            string ParamList;

            try
            {
                
                //Enter the VAPIX command. Here we use param.cgi with the list action. 192.168.0.90 is the IP address of the Axis product.
                ParamList = "http://195.60.68.14:12096/axis-cgi/param.cgi?action=list&responseformat=rfc";

                // Enter the user name and password for the Axis product.

                NetworkCredential networkCredential = new NetworkCredential("root", "5mm0ZI4D");

                
                //Associate the 'NetworkCredential' object with the 'WebRequest' object.
                //Read more about WebRequest at
                //http://msdn.microsoft.com/en-us/library/system.net.webrequest.credentials(v=vs.71).aspx



                WebRequest request = WebRequest.Create(ParamList);
                request.Credentials = networkCredential;  
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
               

                //Read Parameter List and display the response in the rich text box.
                //Read more about the HaveResponse property at
                //http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest.haveresponse(v=vs.110).aspx

              
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);
                Char[] readBuff = new Char[256000];
                int count = streamRead.Read(readBuff, 0, 256000);
                richTextBox1.Text += String.Format("\nAXIS PARAMETER LIST:\n");
                while (count > 0)
                {
                    String outputData = new String(readBuff, 0, count);
                    richTextBox1.Text += String.Format("{0}", outputData);
                    count = streamRead.Read(readBuff, 0, 256000);
                }


                // Close and release the response.
                streamRead.Close();
                streamResponse.Close();
                response.Close();

            }

            catch (Exception es)
            {
                MessageBox.Show(es.ToString(), "\nError Message");


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Clear the rich text box every time the user clicks the Get Param button.

            richTextBox1.Text = "";


            //Create a string. The string will be used to pass the VAPIX(R) command to the Axis product.
            string PeerList;

            try
            {

                //Enter the VAPIX command. Here we use param.cgi with the list action. 192.168.0.90 is the IP address of the Axis product.
                PeerList = "http://195.60.68.14:12096/vapix/aconn/GetPeerList";

                // Enter the user name and password for the Axis product.

                NetworkCredential networkCredential = new NetworkCredential("root", "5mm0ZI4D");


                //Associate the 'NetworkCredential' object with the 'WebRequest' object.
                //Read more about WebRequest at
                //http://msdn.microsoft.com/en-us/library/system.net.webrequest.credentials(v=vs.71).aspx



                WebRequest request = WebRequest.Create(PeerList);
                request.Credentials = networkCredential;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();


                //Read Parameter List and display the response in the rich text box.
                //Read more about the HaveResponse property at
                //http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest.haveresponse(v=vs.110).aspx


                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);
                Char[] readBuff = new Char[256000];
                int count = streamRead.Read(readBuff, 0, 256000);
                richTextBox1.Text += String.Format("\nResponse from AXIS A1601:\n");
                while (count > 0)
                {
                    String outputData = new String(readBuff, 0, count);
                    richTextBox1.Text += String.Format("{0}", outputData);
                    count = streamRead.Read(readBuff, 0, 256000);
                }


                // Close and release the response.
                streamRead.Close();
                streamResponse.Close();
                response.Close();

            }

            catch (Exception es)
            {
                MessageBox.Show(es.ToString(), "\nError Message");


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Clear the rich text box every time the user clicks the Get Param button.

            richTextBox1.Text = "";


            //Create a string. The string will be used to pass the VAPIX(R) command to the Axis product.
            Uri PeerList;

            try
            {

                //Enter the VAPIX command. Here we use param.cgi with the list action. 192.168.0.90 is the IP address of the Axis product.
                PeerList = new Uri("http://195.60.68.14:12096/vapix/doorcontrol");

                // Enter the user name and password for the Axis product.

                NetworkCredential networkCredential = new NetworkCredential("root", "5mm0ZI4D");


                //Associate the 'NetworkCredential' object with the 'WebRequest' object.
                //Read more about WebRequest at
                //http://msdn.microsoft.com/en-us/library/system.net.webrequest.credentials(v=vs.71).aspx

                string rawStringJSON = "{ \"tdc:GetDoorState\":{ \"Token\":\"Axis-accc8efde02f:1668510220.983413000\"} }";

                WebRequest wRequest = WebRequest.Create(PeerList);
                wRequest.Method = "POST";
                wRequest.Credentials = networkCredential;
                byte[] bArray = Encoding.UTF8.GetBytes(rawStringJSON);
                wRequest.ContentType = "application/json";
                wRequest.ContentLength = bArray.Length;
                Stream webData = wRequest.GetRequestStream();
                webData.Write(bArray, 0, bArray.Length);
                webData.Close();
                WebResponse webResponse = wRequest.GetResponse();
                Console.WriteLine(((HttpWebResponse)webResponse).StatusDescription);
                webData = webResponse.GetResponseStream();
                StreamReader reader = new StreamReader(webData);
                string responseFromServer = reader.ReadToEnd();
                richTextBox1.Text = String.Format("{0}", responseFromServer);
                reader.Close();
                webData.Close();
                webResponse.Close();
            }

            catch (Exception es)
            {
                MessageBox.Show(es.ToString(), "\nError Message");


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Clear the rich text box every time the user clicks the Get Param button.

            richTextBox1.Text = "";


            //Create a string. The string will be used to pass the VAPIX(R) command to the Axis product.
            Uri PeerList;

            try
            {

                //Enter the VAPIX command. Here we use param.cgi with the list action. 192.168.0.90 is the IP address of the Axis product.
                PeerList = PeerList = new Uri("http://195.60.68.14:12096/vapix/services/pacs");

                // Enter the user name and password for the Axis product.

                NetworkCredential networkCredential = new NetworkCredential("root", "5mm0ZI4D");


                //Associate the 'NetworkCredential' object with the 'WebRequest' object.
                //Read more about WebRequest at
                //http://msdn.microsoft.com/en-us/library/system.net.webrequest.credentials(v=vs.71).aspx

                

                string rawStringXML = @"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" "+ "\n" +
                                      @"xmlns:user=""http://www.axis.com/vapix/ws/user"" >" + "\n" +

                @"<soap:Header/> " + "\n"+

                 @"<soap:Body>" + "\n" +

                     @" <user:SetUser> " + "\n"+

                         @"<user:User token=""TIP1"">" + "\n" +

                             @"<user:Name>Vivek Kumar</user:Name>" + "\n"+

                                  @"<user:Description>Solution Development Engineer</user:Description>" + "\n" +

                                      @" <user:Attribute type=""firstname"" Name=""First name"" Value=""Vivek""> " + "\n"+

                                            @"</user:Attribute>" + "\n" +

                                            @"<user:Attribute type = ""lastname"" Name = ""Last Name"" Value = ""Kumar"" > " + "\n"+

                                                 @"</user:Attribute >" + "\n" +

                                               @" </user:User > " + "\n"+

                                             @"</user:SetUser >" + "\n" +

                                           @"</soap:Body >" + "\n"+
                                         @"</soap:Envelope> ";

                string rawStringXMLGetList = @"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope""" +
                    @"xmlns:user= ""http://www.axis.com/vapix/ws/user"" >" + "\n" +
                    @"<soap:Header/>" + "\n" +
                    @"<soap:Body>" + "\n" +
                    @"<user:GetUserList>" + "\n" +
                    @"<user:Limit>20</user:Limit>" + "\n" +
                    @"</user:GetUserList>" + "\n" +
                    @"</soap:Body>" + "\n" +
                    @"</soap:Envelope>" + "\n";
                WebRequest wRequest = WebRequest.Create(PeerList);
                wRequest.Method = "POST";
                wRequest.Credentials = networkCredential;
                byte[] bArray = Encoding.UTF8.GetBytes(rawStringXML);
                wRequest.ContentType = "application/xml";
                wRequest.ContentLength = bArray.Length;
                Stream webData = wRequest.GetRequestStream();
                webData.Write(bArray, 0, bArray.Length);
                webData.Close();
                WebResponse webResponse = wRequest.GetResponse();
                Console.WriteLine(((HttpWebResponse)webResponse).StatusDescription);
                webData = webResponse.GetResponseStream();
                StreamReader reader = new StreamReader(webData);
                string responseFromServer = reader.ReadToEnd();
                richTextBox1.Text = String.Format("{0}", responseFromServer);
                reader.Close();
                webData.Close();
                webResponse.Close();

            }

            catch (Exception es)
            {
                MessageBox.Show(es.ToString(), "\nError Message");


            }
        }
    }
}
