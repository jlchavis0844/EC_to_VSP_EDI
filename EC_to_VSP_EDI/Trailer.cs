
namespace EC_to_Humana_EDI {
    public class Trailer {
        private const string SegmentID_SE = "SE";
        private string numberOfIncludedSegments_SE01;
        private string transactionSetControlNumber_SE02;
        private const string SegmentID_GE = "GE";
        private const string NumberOfTransactionSetsIncluded_GE01 = "1";
        private string groupControlNumber_GE02;
        private const string SegmentID_IEA = "IEA";
        private const string NumberOfFunctionalGroupsIncluded_IEA01 = "1";
        private string interchangeControlNumber_IEA02;
        private const string SegmentTerminator = "~";

        public Trailer() {
            this.numberOfIncludedSegments_SE01 = Form1.Enrollments.Count.ToString();
            this.transactionSetControlNumber_SE02 = InterchangeTracker.GetInterchangeNumber().ToString();
            this.groupControlNumber_GE02 = this.transactionSetControlNumber_SE02;
            this.interchangeControlNumber_IEA02 = this.transactionSetControlNumber_SE02;
        }

        public new string ToString() {
            return SegmentID_SE + '*' + this.numberOfIncludedSegments_SE01 + '*' + this.transactionSetControlNumber_SE02.PadLeft(4, '0') + SegmentTerminator + '\n' +
                SegmentID_GE + '*' + NumberOfTransactionSetsIncluded_GE01 + '*' + this.groupControlNumber_GE02 + SegmentTerminator + '\n' +
                SegmentID_IEA + '*' + NumberOfFunctionalGroupsIncluded_IEA01 + '*' + this.interchangeControlNumber_IEA02.PadLeft(9, '0') + SegmentTerminator;
        }
    }
}
