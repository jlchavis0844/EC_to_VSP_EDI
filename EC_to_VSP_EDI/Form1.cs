namespace EC_to_BCBS_EDI {
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Windows.Forms;
    using CsvHelper;
    using log4net;
    using Syroot.Windows.IO;

    public partial class Form1 : Form {
        public static string INPUTFILE;
        public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static Header Header;
        public static SubHeader SubHeader;
        public static Trailer Trailer;
        public static List<EnrollmentEntry> Enrollments = new List<EnrollmentEntry>();
        public static List<CensusRow> Records = new List<CensusRow>();
        public static List<CensusRow> DentalRecords = new List<CensusRow>();
        public static string OutputFolder;
        public static StringBuilder TextOut;
        public static int ErrorCounter = 0;

        // TODO: add ability to load as a file
        public static string PublicKeyFilePath = @"\\nas3\users\jchavis\Documents\PublicKey.asc";
        public static string PrivateKeyFilePath = @"\\nas3\users\jchavis\Documents\SecretKey.asc";

        // TODO: add registry save and load and then manual entry text box
        public static string PgpPassFile = @"\\nas3\users\jchavis\Documents\pgpPass.pgp";

        public Form1() {
            this.InitializeComponent();
            this.cbType.SelectedIndex = 0;

            // log4net.Config.XmlConfigurator.Configure();
            string interchangeNumber = InterchangeTracker.GetInterchangeNumber().ToString();
            string dateStr = InterchangeTracker.GetInterchangeDate();
            int year = Convert.ToInt32("20" + dateStr.Substring(0, 2));
            int mon = Convert.ToInt32(dateStr.Substring(2, 2));
            int day = Convert.ToInt32(dateStr.Substring(4, 2));
            string time = InterchangeTracker.GetInterchangeTime();
            int hour = Convert.ToInt32(time.Substring(0, 2));
            int min = Convert.ToInt32(time.Substring(2, 2));

            DateTime dt = new DateTime(year, mon, day, hour, min, 0);

            this.lblInterchangeNumber.Text = "Interchange Number: " + interchangeNumber;
            this.dtPicker.Value = dt;

            Log.Info("Starting form loading at " + DateTime.Now);
        }

        public void BtnLoadFile_Click(object sender, EventArgs e) {
            Log.Info("Load button clicked");
            string type = "csv";

            using (OpenFileDialog ofd = new OpenFileDialog()) {
                //ofd.InitialDirectory = KnownFolders.Downloads.Path;
                ofd.Filter = type + " files (*." + type + ")| *." + type;
                ofd.RestoreDirectory = true;
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK) {
                    INPUTFILE = ofd.FileName;
                    Log.Info(INPUTFILE + " loaded");
                    this.lblFileLocation.Text = INPUTFILE;
                    this.btnProcessEDI.Enabled = true;
                    var loadedFile = File.Open(INPUTFILE, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (var reader = new StreamReader(loadedFile)) {
                        using (var csv = new CsvReader(reader)) {
                            csv.Configuration.HeaderValidated = null;
                            csv.Configuration.HasHeaderRecord = true;
                            csv.Configuration.RegisterClassMap<CensusRowClassMap>();

                            try {
                                //Records = csv.GetRecords<CensusRow>().Where(rec => rec.CoverageDetails != "Waived"
                                //&& DateTime.Parse(rec.PlanEffectiveEndDate) >= DateTime.Now).ToList()
                                //.Where(rec =>
                                //    rec.CoverageDetails != "Waived" &&
                                //    DateTime.Parse(rec.PlanEffectiveEndDate) >= DateTime.Now &&
                                //    rec.PlanType == "Vision")
                                //.ToList();
                                //Records = csv.GetRecords<CensusRow>().Where( rec =>
                                   //rec.CoverageDetails != "Waived" && rec.CoverageDetails != "Terminated"
                                    //&& rec.PlanType.Contains("Vis")
                                    //).ToList();
                                    Records = csv.GetRecords<CensusRow>().ToList();
                                lblFileLocation_cnt.Text = "Loaded Records = " + Records.Count;
                            } catch (Exception ex) {
                                Log.Error("ERROR loading file\n" + ex);
                                Console.WriteLine(ex);
                            }

                            Log.Info(Records.Count() + " records loaded from Census file.");
                        }
                    }
                } else {
                    MessageBox.Show("ERROR LOADING INPUT FILE", "ERROR LOADING INPUT FILE", MessageBoxButtons.OK);
                    Log.Info("No file chosen");
                    Application.Exit();
                }
            }
        }

        public void Button1_Click(object sender, EventArgs e) {
            Enrollments.Clear();
            if (!File.Exists(this.lblFileLocation.Text)) {
                Log.Info("no file found loaded\n" + this.lblFileLocation);
                this.btnProcessEDI.Enabled = false;
                return;
            }

            string type;
            switch (this.cbType.SelectedIndex) {
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

            SubHeader = new SubHeader(type);

            char usage = (this.cbType.SelectedIndex == 0) ? 'T' : 'P'; 
            Header = new Header(usage);

            foreach (var row in Records) {
                Enrollments.Add(new EnrollmentEntry(row));
            }

            Trailer = new Trailer();

            TextOut = new StringBuilder();
            TextOut.AppendLine(Header.ToString());
            TextOut.AppendLine(SubHeader.ToString());

            //eliminate trailing element seperators
            List<string> TESList = new List<string>();
            foreach (var line in Enrollments) {
                TESList.Add(line.ToString());
            }

            while (TESList.Count(cnt => cnt.Contains("*~")) >0) {
                for (int i = 0; i < TESList.Count; i++) {
                    TESList[i] = TESList[i].Replace("*~", "~");
                }
            }

            foreach (string line in TESList) {
                TextOut.AppendLine(line);
            }

            TextOut.AppendLine(Trailer.ToString());
            TextOut = new StringBuilder(TextOut.ToString().Replace("\r\n\r\n", "\r\n"));
            string[] segments = TextOut.ToString().Split('\n');

            string[] SE_Segs = segments[segments.Length - 4].Split('*');
            Console.WriteLine(segments[segments.Length - 4]);

            SE_Segs[1] = (segments.ToList().Count(ew => ew.Length > 3)-4).ToString();
            string NewSE = SE_Segs[0] + '*'+SE_Segs[1] + '*'+SE_Segs[2];
            segments[segments.Length - 4] = NewSE;

            TextOut.Clear();

            foreach(string seg in segments){
                if (string.IsNullOrEmpty(seg) || seg.Length <= 1)
                    continue;

                string cleanSeg = seg.Replace("\n", "");
                cleanSeg = cleanSeg.Replace("\r", "");

                if (string.IsNullOrEmpty(seg) || seg.Length <= 1)
                    continue;

                TextOut.AppendLine(cleanSeg);
            }


            Console.WriteLine(segments[segments.Length - 4]);


            //this.tbTextOut.MaxLength = int.MaxValue;
            TextOut = new StringBuilder(TextOut.ToString().Replace("\n\n","").Replace("\r\r",""));
            this.tbTextOut.Text = TextOut.ToString();
            this.btnOutput.Enabled = true;
            lblProcessedCnt.Text = Enrollments.Count().ToString() + " enrollments listed";
            //Enrollments.Count().Where();
        }

        private void BtnSaveFile_Click(object sender, EventArgs e) {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
                fbd.Description = "Select the directory to output files to";
                fbd.ShowNewFolderButton = true;

                // fbd.RootFolder = Environment.SpecialFolder.MyDocuments;
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK) {
                    OutputFolder = fbd.SelectedPath;
                    Log.Info("Output directory set to " + OutputFolder);
                    this.lblOutPutFolder.Text = OutputFolder;
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e) {
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

            this.lblInterchangeNumber.Text = "Interchange Number: " + interchangeNumber;
            this.dtPicker.Value = dt;
            Log.Info("updated interchange to " + InterchangeTracker.ToString());
        }

        private void BtnOutput_Click(object sender, EventArgs e) {
            //string outputFileLocation = OutputFolder + @"\Test_HTL_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string outputFileLocation = OutputFolder + @"\hmetwn28.8345010.m.prod";
            //string outputFileLocation = OutputFolder + @"\T8005054.txt";

            Log.Info("attempting to save EDI to " + outputFileLocation);
            try {
                if (!Directory.Exists(OutputFolder)) {
                    throw new ArgumentException("File location not valid", "original");
                }
            } catch (Exception ex1) {
                Log.Info("No out location selected." + ex1.Message);
                this.lblOutputSave.Text = "Select output folder first";
                this.lblOutputSave.ForeColor = Color.Red;
                this.lblOutputSave.Font = new Font(this.lblOutputSave.Font, FontStyle.Bold);
            }

            try {
                using (StreamWriter file = new StreamWriter(outputFileLocation, false)) {
                    string temp = TextOut.ToString().Replace("\r", "").Replace("\n\n", "");
                    temp = temp.Substring(0, temp.Length - 1);
                    file.WriteLine(temp);
                    this.lblOutputSave.Text = "Saved to " + outputFileLocation;
                }

                Log.Info("saved output to " + outputFileLocation);
            } catch (Exception ex) {
                Log.Error("ERROR\n" + ex);
            }

            //string pgpPass = string.Empty;
            //try {
            //    using (StreamReader sr = new StreamReader(PgpPassFile)) {
            //        pgpPass = sr.ReadToEnd();
            //    }

            //    if (pgpPass == null || pgpPass == string.Empty) {
            //        return;
            //    }
            //} catch (Exception ex3) {
            //    Log.Error("ERROR:\n" + ex3);
            //}
        }

        public string GetFileLocation() {
            return lblFileLocation.Text;
        }

        public bool ErrorCheck(CensusRow row) {
            bool failed = false;

            if (string.IsNullOrEmpty(row.Address1)) {
                return true;
            }

            if (string.IsNullOrEmpty(row.BirthDate)) {
                return true;
            }

            if (string.IsNullOrEmpty(row.Sex)) { 
                return true;
            }

            if (string.IsNullOrEmpty(row.HireDate)) {
                return true;
            }

            if (string.IsNullOrEmpty(row.LastName)) {
                return true;
            }

            if (string.IsNullOrEmpty(row.FirstName)) {
                return true;
            }
            return false;
        }
    }
}
