using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Newtonsoft.Json;
using PrintApp.Data;
using SAPBusinessObjects.WPF.Viewer;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PrintApp
{
    /// <summary>
    /// Interaction logic for FormShow.xaml
    /// </summary>
    /// 
 
    public static class PaymentOptions
    {
        public const string txtIP = "";
        public const string txtPort = "";
        public const string ReadTimeOut = "";


        public static string txtDebitAmount="1000";
        public static string txtDebitPayerId;
        public static string txtDebitMsg;
        public static string txtDebitPcID;


    }

    public static class PaymentResponse
    {
        public static string txtAccountNo;
        public static string txtCardNo;
        public static string txtTransSerialNo;
        public static string txtRRN;
        public static string txtTeminalNo;
        public static string txtDate;
        public static string txtTime;
        public static string txtResponseCode;
        public static string textResult;

    }

    public partial class FormShow : Window
    {

        private int _numValue = 1;

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                txtPagesAmount.Text = value.ToString();
            }
        }


        ReportDocument report;
        public FormShow()
        {
            InitializeComponent();
            txtPagesAmount.Text = _numValue.ToString();

        }

        private void HidePreviewTabFromCRV()
        {
            //visiual Tree
            var y = GetChild<System.Windows.Controls.Primitives.TabPanel>(crystalform.ViewerCore);
            y.Visibility = Visibility.Collapsed;
        }
        private TargetType GetChild<TargetType>(DependencyObject o)
      where TargetType : DependencyObject
        {
            if (o == null || o is TargetType)
                return (TargetType)o;

            int i = 0;
            if (VisualTreeHelper.GetChildrenCount(o) == 2 && VisualTreeHelper.GetParent(o).GetType() == typeof(System.Windows.Controls.TabControl))
                i = 1; // We Arrive Our Destination

            return GetChild<TargetType>(VisualTreeHelper.GetChild(o, i));
        }

        private void load_Loaded(object sender, RoutedEventArgs e)
        {
           // ParameterFields parameterFields = new ParameterFields();
           // ParameterField p1 = new ParameterField();
           //// p1.Name = 
           // //   p1.para name ="@no"
           // ParameterDiscreteValue dc = new ParameterDiscreteValue();
           // dc.Value = 1;
           // p1.CurrentValues.Add(dc);
           // parameterFields.Add(p1);

            crystalform.ShowLogo = false;
           crystalform.ShowToolbar = false;
            crystalform.ShowToggleSidePanelButton = false;
            //left panel
            crystalform.ToggleSidePanel = Constants.SidePanelKind.None;
            //hide preview
            HidePreviewTabFromCRV();
            crystalform.ShowStatusbar = false;

            crystalform.ShowPrintButton = false;

            //crystalform.
            report = new ReportDocument();
            // //AppDomain.CurrentDomain.BaseDirectory+ "\\formcr.rpt"
            //// string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            //  var  APPPATH = Environment.CurrentDirectory + "formcr.rpt";
          //  string sss = HttpContext.Current.Server.MapPath("~/Reports/reportName.rpt"); 
           // m_rpt.Load(sss);
            report.Load(System.Windows.Forms.Application.StartupPath + "\\"+"Forms\\"+"form"+ MainWindow.OpenedForm.ToString()+".rpt");
            //"C:\\" + "formcr.rpt"
         //   report.Load(APPPATH);
            //CrystalDecisions.Shared.ParameterValues pval1 = new ParameterValues();


            //ParameterDiscreteValue pdisval1 = new ParameterDiscreteValue();
            //pdisval1.Value = "hossein";
            //pval1.Add(pdisval1);




            //            report.DataDefinition.ParameterFields["name1"].ApplyCurrentValues(pval1);


            //ParameterFieldDefinitions crParameterFieldDefinitions;
            //ParameterFieldDefinition crParameterFieldDefinition;
            //ParameterValues crParameterValues = new ParameterValues();
            //ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            //crParameterDiscreteValue.Value = "hossein";
            //crParameterFieldDefinitions = report.DataDefinition.ParameterFields;
            //crParameterFieldDefinition = crParameterFieldDefinitions["name1"];
            //crParameterValues = crParameterFieldDefinition.CurrentValues;

            //crParameterValues.Clear();
            //crParameterValues.Add(crParameterDiscreteValue);
            //crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);




            // CRUserList CRUserListRPT = new CRUserList();
            using (AppDbContext connection = new AppDbContext())
            {
                ParameterFields paraFileds = new ParameterFields();
            ParameterField paraFiled = new ParameterField();
            ParameterDiscreteValue paraDescritValue;
        

           
                paraFiled.Name = "name1";
                paraFiled.CurrentValues.Clear();
                paraDescritValue = new ParameterDiscreteValue();
                paraDescritValue.Value = connection.Pageforms.Where(p=>p.Id== 1).FirstOrDefault().Name;
                paraFiled.CurrentValues.Add(paraDescritValue);
                paraFileds.Add(paraFiled);
            

         

            // //   var connectionString = ConfigurationManager.ConnectionStrings["MyAppConfigConnectionStringName"].ConnectionString;
            

              //  report.SetParameterValue("@name", "hossein");

                //SybaseIQDataAdapter dataAdapter = new SybaseIQDataAdapter(
                //"SELECT ProductName, Price FROM Products WHERE ProductName = 'Konbu'", connection);
                //DataSet set = new DataSet("_set");
                // DataTable table = set.Tables.Add("_table");
                //  dataAdapter.Fill(table);
                //  System.Windows.Forms.Application.StartupPath + "\\Reports\\ReportName.rpt"
              // report.SetDataSource(connection.pageforms.ToList());
               //report.SetParameterValue("name1", "hossein") ;
                report.Refresh();
                crystalform.ViewerCore.ReportSource = report;
               // crystalform.ViewerCore.RefreshReport();
               crystalform.ViewerCore.ParameterFieldInfo = paraFileds;




            }


            //reportViewer.ViewerCore.ReportSource = report;
            //CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
            //CustomerReport crystalReport = new CustomerReport();
            //NorthwindEntities entities = new NorthwindEntities();
            //crystalReport.SetDataSource(from customer in entities.Customers.Take(10)
            //                            select customer);
            //CrystalReportViewer1.ReportSource = crystalReport;
            //CrystalReportViewer1.RefreshReport();

        }

        private void btnPayment_Click(object sender, RoutedEventArgs e)
        {
           // PrintForm();

            //----------------- Transaction config --------------------------------
            int AmountInt;
            bool isNumeric6 = int.TryParse(PaymentOptions.txtDebitAmount, out AmountInt);
            if (PaymentOptions.txtDebitAmount.Length < 4 || isNumeric6 == false)
            {
                System.Windows.MessageBox.Show(" مبلغ  نامعتبر است");
            }
            else
            {
                System.Net.Sockets.TcpClient client = null;
                try
                {
                    System.Net.ServicePointManager.Expect100Continue = false;
                    byte[] resvCommand = new byte[10025];
                    client = new System.Net.Sockets.TcpClient(PaymentOptions.txtIP, UInt16.Parse(PaymentOptions.txtPort)); // Create a new connection  
                    if (!client.Connected)
                    {
                        // btDebitConfirm.Enabled = true;
                        System.Windows.Forms.MessageBox.Show("pleas check Service Port");
                        return;
                    }
                    NetworkStream stream = client.GetStream();
                    string str_comm = "" + "{\"ServiceCode\" :\"" + "1";
                    if (PaymentOptions.txtDebitAmount.Length > 0)
                        str_comm += "\",\"Amount\":\"" + PaymentOptions.txtDebitAmount;
                    if (PaymentOptions.txtDebitPayerId.Length > 0)
                        str_comm += "\",\"PayerId\":\"" + PaymentOptions.txtDebitPayerId;
                    if (PaymentOptions.txtDebitMsg.Length > 0)
                        str_comm += "\",\"MerchantMsg\":\"" + PaymentOptions.txtDebitMsg;
                    if (PaymentOptions.txtDebitPcID.Length > 0)
                        str_comm += "\",\"PcID\":\"" + PaymentOptions.txtDebitPcID;
                    str_comm += "\"}";

                    //string str_comm = "" + "{\"ServiceCode\" :\"" + "1" + "\",\"Amount\":\"" + txtDebitAmount.Text + "\",\"PayerId\":\"" + txtDebitPayerId.Text + "\",\"MerchantMsg\":\"" + txtDebitMsg.Text + "\",\"PcID\":\"" + txtDebitPcID.Text + "\"}";
                    byte[] sendCommand = System.Text.Encoding.ASCII.GetBytes(str_comm);
                    stream.Write(sendCommand, 0, sendCommand.Length);
                    stream.ReadTimeout = Int32.Parse(PaymentOptions.ReadTimeOut);
                    int recvSize = stream.Read(resvCommand, 0, resvCommand.Length);

                    string jsonStr = Encoding.UTF8.GetString(resvCommand);
                    Dictionary<String, String> values = JsonConvert.DeserializeObject<Dictionary<String, String>>(jsonStr);
                    //دریافت اطلاعات از ‍پوز
                    ParseJson(values);
                    // btDebitConfirm.Enabled = true;
                    client.Close();


                }
                catch (Exception ex)
                {
                    //   btDebitConfirm.Enabled = true;
                    try
                    {
                        System.Windows.MessageBox.Show(ex.Message.ToString());

                        client.Close();

                    }
                    catch
                    { }
                }

            }





            //  btDebitConfirm.Enabled = true;

            //btnPrint.IsEnabled = true;




            //  report.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
            //  report.PrintOptions.PaperSize = PaperSize.PaperA4;

            //report.PrintToPrinter(1, false, 0, 0);
            // PrintDialog dialog1 = new PrintDialog();


            //dialog1.Document = pDoc;

            //DialogResult result = printDialog1.ShowDialog();

            //if (result == DialogResult.OK)
            //{
            //    pDoc.PrinterSettings.PrinterName = printDialog1.PrinterSettings.PrinterName;
            //    pDoc.Print();
            //}
            //  report.PrintToPrinter(1, true, 0, 0);
            // Refresh Report.
            //report.Refresh();
            //// Set Paper Orientation.
            //report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            //// Set Paper Size.
            //report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            //// CrystalDecisions.Shared.ExportFormatType to change the format i.e. Excel, Word, PDF
            ////crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "CustomerDetails");
            //report.PrintOptions.PrinterName = GetDefaultPrinter();
            //report.PrintToPrinter(1, true, 0, 0);


        }


        private void PrintForm()
        {
            System.Windows.Forms.PrintDialog dialog1 = new System.Windows.Forms.PrintDialog();

            // report.SetDatabaseLogon("username", "password");

            dialog1.AllowSomePages = true;
            dialog1.AllowPrintToFile = false;
            dialog1.PrinterSettings.Copies = Convert.ToInt16(txtPagesAmount.Text);

            if (dialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int copies =   dialog1.PrinterSettings.Copies;
                int fromPage = dialog1.PrinterSettings.FromPage;
                int toPage = dialog1.PrinterSettings.ToPage;
                bool collate = dialog1.PrinterSettings.Collate;

                report.PrintOptions.PrinterName = dialog1.PrinterSettings.PrinterName;
                report.PrintToPrinter(copies, collate, fromPage, toPage);
            }

            report.Dispose();
            dialog1.Dispose();
        }

        private void ParseJson(Dictionary<string, string> values)
        {
            foreach (KeyValuePair<String, String> d in values)
            {
                //values.Add(d.Key, d.Value);
                if (d.Key == "AccountNo")
                    PaymentResponse.txtAccountNo = d.Value;
                else if (d.Key == "PAN" && d.Value.Length > 0)
                {
                    PaymentResponse.txtCardNo = d.Value;
                }
                else if (d.Key == "SerialTransaction")
                    PaymentResponse.txtTransSerialNo = d.Value;
                else if (d.Key == "TraceNumber")
                    PaymentResponse.txtRRN = d.Value;
                else if (d.Key == "TerminalNo")
                    PaymentResponse.txtTeminalNo = d.Value;
                else if (d.Key == "TransactionDate")
                    PaymentResponse.txtDate = d.Value;
                else if (d.Key == "TransactionTime")
                    PaymentResponse.txtTime = d.Value;
                else if (d.Key == "ReasonCode")
                    PaymentResponse.txtResponseCode = d.Value;
                if (d.Key == "ReturnCode")
                {
                    PaymentResponse.textResult = d.Value;
                    if (d.Value == "100")
                        //موفقیت آمیز بوده
                        PrintForm();
                    //   pictureBox1.Image = imageList1.Images[0];
                    else
                        return;
                   
                }
            }
        }




        private string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                {
                    return printer;
                }
            }
            return string.Empty;
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;

        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            if (txtPagesAmount.Text == 1.ToString())
            {

            }
            else
            {
                NumValue--;

            }
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPagesAmount == null)
            {
                return;
            }

            if (!int.TryParse(txtPagesAmount.Text, out _numValue))
                txtPagesAmount.Text = _numValue.ToString();
        }
    }
}
