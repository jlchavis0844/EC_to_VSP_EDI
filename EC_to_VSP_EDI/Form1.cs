using CsvHelper;
using log4net;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace EC_to_VSP_EDI {
    public partial class Form1 : Form {
        public static string INPUTFILE;
        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static Header header;
        public static SubHeader subHeader;
        public static Trailer trailer;
        public static List<EnrollmentEntry> enrollments = new List<EnrollmentEntry>();
        public static List<CensusRow> records = new List<CensusRow>();
        public static string outputFolder;
        public static StringBuilder textOut;

        public Form1() {
            InitializeComponent();
            cbType.SelectedIndex = 0;
            //log4net.Config.XmlConfigurator.Configure();
            string interchangeNumber = InterchangeTracker.GetInterchangeNumber().ToString();
            string dateStr = InterchangeTracker.GetInterchangeDate();
            int year = Convert.ToInt32("20" + dateStr.Substring(0, 2));
            int mon = Convert.ToInt32(dateStr.Substring(2, 2));
            int day = Convert.ToInt32(dateStr.Substring(4, 2));
            string time = InterchangeTracker.GetInterchangeTime();
            int hour = Convert.ToInt32(time.Substring(0, 2));
            int min = Convert.ToInt32(time.Substring(2, 2));

            DateTime dt = new DateTime(year, mon, day, hour, min, 0);

            lblInterchangeNumber.Text = "Interchange Number: " + interchangeNumber;
            dtPicker.Value = dt;

            log.Info("Starting form loading at " + DateTime.Now);
        }

        public void btnLoadFile_Click(object sender, EventArgs e) {
            log.Info("Load button clicked");
            string type = "csv";
            
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.InitialDirectory = KnownFolders.Downloads.Path;
                ofd.Filter = type + " files (*." + type + ")| *." + type;
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK) {
                    INPUTFILE = ofd.FileName;
                    log.Info(INPUTFILE + " loaded");
                    lblFileLocation.Text = INPUTFILE;
                    btnProcessEDI.Enabled = true;

                    using (var reader = new StreamReader(INPUTFILE)) {
                        var csv = new CsvReader(reader);
                        csv.Configuration.HeaderValidated = null;
                        csv.Configuration.HasHeaderRecord = true;
                        csv.Configuration.RegisterClassMap<CensusRowClassMap>();

                        records = csv.GetRecords<CensusRow>().Where(rec => rec.CoverageDetails != "Waived" 
                        && DateTime.Parse(rec.PlanEffectiveEndDate) >= DateTime.Now).ToList()
                        .Where(rec => rec.CoverageDetails != "Waived" && DateTime.Parse(rec.PlanEffectiveEndDate) >= DateTime.Now).ToList();

                        log.Info(records.Count() + " records loaded from Census file.");
                    }
                } else {
                    MessageBox.Show("ERROR LOADING INPUT FILE", "ERROR LOADING INPUT FILE", MessageBoxButtons.OK);
                    log.Info("No file chosen");
                    Application.Exit();
                }
            }
        }

        public void button1_Click(object sender, EventArgs e) {
            if (!File.Exists(lblFileLocation.Text)) {
                log.Info("no file found loaded\n" + lblFileLocation);
                btnProcessEDI.Enabled = false;
                return;
            }

            InterchangeTracker.UpdateInterchange();

            string type;
            switch (cbType.SelectedIndex) {
                case 1:
                    type = TransactionSetPurposes.Original;
                    break;
                case 2:
                    type = TransactionSetPurposes.ReSubmission;
                    break;
                case 3:
                    type = TransactionSetPurposes.InformationCopy;
                    break;
                default:
                    type = TransactionSetPurposes.Test;
                    break;
            }
            subHeader = new SubHeader(type);
            header = new Header(type);

            foreach(var row in records) {
                enrollments.Add(new EnrollmentEntry(row));
            }

            trailer = new Trailer();


            Console.WriteLine(trailer.ToString());

            textOut = new StringBuilder();
            textOut.AppendLine(header.ToString());
            textOut.AppendLine(subHeader.ToString());

            Console.WriteLine(header.ToString());
            Console.WriteLine(subHeader.ToString());

            foreach (var line in enrollments) {
                textOut.AppendLine(line.ToString());
                Console.WriteLine(line.ToString());
            }

            textOut.AppendLine(trailer.ToString());
            Console.WriteLine(trailer.ToString());

            tbTextOut.MaxLength = 10000;
            tbTextOut.Text = textOut.ToString();
            btnOutput.Enabled = true;
        }

        private void btnSaveFile_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select the directory to output files to";
            fbd.ShowNewFolderButton = true;
            //fbd.RootFolder = Environment.SpecialFolder.MyDocuments;

            DialogResult result = fbd.ShowDialog();
            if(result == DialogResult.OK) {
                outputFolder = fbd.SelectedPath;
                log.Info("Output directory set to " + outputFolder);
                lblOutPutFolder.Text = outputFolder;
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            InterchangeTracker.UpdateInterchange();
            string interchangeNumber = InterchangeTracker.GetInterchangeNumber().ToString();
            string dateStr = InterchangeTracker.GetInterchangeDate();
            int year = Convert.ToInt32("20" + dateStr.Substring(0, 2));
            int mon = Convert.ToInt32(dateStr.Substring(2, 2));
            int day = Convert.ToInt32(dateStr.Substring(4, 2));
            string time = InterchangeTracker.GetInterchangeTime();
            int hour = Convert.ToInt32(time.Substring(0, 2));
            int min = Convert.ToInt32(time.Substring(2, 2));

            DateTime dt = new DateTime(year, mon, day, hour, min, 0);

            lblInterchangeNumber.Text = "Interchange Number: " + interchangeNumber;
            dtPicker.Value = dt;
            log.Info("updated interchange to " + InterchangeTracker.ToString());
        }

        private void btnOutput_Click(object sender, EventArgs e) {
            string outputFileLocation = outputFolder + @"\t" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            log.Info("attempting to save EDI to " + outputFileLocation);

            try {
                using (StreamWriter file = new StreamWriter(outputFileLocation, false)) {
                    file.WriteLine(textOut.ToString());
                    lblOutputSave.Text = "Saved to " + outputFileLocation;
                }
                log.Info("saved output to " + outputFileLocation);
            } catch(Exception ex) {
                log.Error("ERROR\n" + ex);
            }

        }
    }
}
