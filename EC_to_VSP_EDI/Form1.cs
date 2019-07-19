using CsvHelper;
using Syroot.Windows.IO;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EC_to_VSP_EDI {
    public partial class Form1 : Form {
        public static string INPUTFILE;

        public Form1() {
            InitializeComponent();
        }

        private void btnLoadFile_Click(object sender, EventArgs e) {
            string type = "csv";
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.InitialDirectory = KnownFolders.Downloads.Path;
                ofd.Filter = type + " files (*." + type + ")| *." + type;
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == DialogResult.OK) {
                    INPUTFILE = ofd.FileName;
                    using (var reader = new StreamReader(INPUTFILE)) {
                        var csv = new CsvReader(reader);
                        csv.Configuration.HeaderValidated = null;
                        csv.Configuration.HasHeaderRecord = true;
                        csv.Configuration.RegisterClassMap<CensusRowClassMap>();

                        var records = csv.GetRecords<CensusRow>().Where(rec => rec.CoverageDetails != "Waived" 
                        && DateTime.Parse(rec.PlanEffectiveEndDate) >= DateTime.Now).ToList<CensusRow>()
                        .Where(rec => rec.CoverageDetails != "Waived" && DateTime.Parse(rec.PlanEffectiveEndDate) >= DateTime.Now);

                        foreach(CensusRow test in records) {
                            Console.WriteLine(test);
                        }
                    }
                } else {
                    MessageBox.Show("ERROR LOADING INPUT FILE", "ERROR LOADING INPUT FILE", MessageBoxButtons.OK);
                    Application.Exit();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            Console.WriteLine(InterchangeTracker.GetInterchangeNumber());
            Console.WriteLine(InterchangeTracker.GetInterchangeNumber());
            Console.WriteLine(InterchangeTracker.IncrementNumber());
            Console.WriteLine(InterchangeTracker.IncrementNumber());
            Console.WriteLine(InterchangeTracker.DecrementNumber());
            Console.WriteLine(InterchangeTracker.SetInterchangeNumber(10));
            Console.WriteLine(InterchangeTracker.GetInterchangeNumber());
            Console.WriteLine(InterchangeTracker.GetInterchangeNumber().ToString().PadLeft(9,'0'));
            Console.WriteLine(InterchangeTracker.GetInterchangeNumber());

            Console.WriteLine(InterchangeTracker.GetInterchangeDate());
            Console.WriteLine(InterchangeTracker.GetInterchangeTime());
            Console.WriteLine(InterchangeTracker.SetInterchangeDate(new DateTime(2015,12,12)));
            Console.WriteLine(InterchangeTracker.GetInterchangeDate());
            Console.WriteLine(InterchangeTracker.SetInterchangeTime(new DateTime(1900,1,1,5,5,5)));
            Console.WriteLine(InterchangeTracker.GetInterchangeTime());
            Console.WriteLine(InterchangeTracker.GetInterchangeDate());
            Console.WriteLine(InterchangeTracker.CreateNewInterchange());
            Console.WriteLine(InterchangeTracker.GetInterchangeTime());
            Console.WriteLine(InterchangeTracker.GetInterchangeDate());
            Console.WriteLine(InterchangeTracker.GetInterchangeNumber());
            Console.WriteLine(InterchangeTracker.UpdateInterchange());
            Console.WriteLine(InterchangeTracker.ToString());



        }
    }
}
