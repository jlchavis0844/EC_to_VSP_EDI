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
            Header header = new Header();
            Console.WriteLine(header.ToString());


        }
    }
}
