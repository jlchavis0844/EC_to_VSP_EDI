using CsvHelper;
using log4net;
using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
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

        public Form1() {
            //log4net.Config.XmlConfigurator.Configure();
            log.Info("Starting form loading at " + DateTime.Now);
            InitializeComponent();
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
                    using (var reader = new StreamReader(INPUTFILE)) {
                        var csv = new CsvReader(reader);
                        csv.Configuration.HeaderValidated = null;
                        csv.Configuration.HasHeaderRecord = true;
                        csv.Configuration.RegisterClassMap<CensusRowClassMap>();

                        records = csv.GetRecords<CensusRow>().Where(rec => rec.CoverageDetails != "Waived" 
                        && DateTime.Parse(rec.PlanEffectiveEndDate) >= DateTime.Now).ToList<CensusRow>()
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
            InterchangeTracker.UpdateInterchange();
            header = new Header();
            subHeader = new SubHeader();

            foreach(var row in records) {
                enrollments.Add(new EnrollmentEntry(row));
            }

            trailer = new Trailer();

            Console.WriteLine(header.ToString());
            Console.WriteLine(subHeader.ToString());

            foreach(var line in enrollments) {
                Console.WriteLine(line.ToString());
            }

            Console.WriteLine(trailer.ToString());

        }
    }
}
