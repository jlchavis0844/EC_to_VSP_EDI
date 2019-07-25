
namespace EC_to_VSP_EDI {
    public class Trailer {
        private const string SegmentID_SE = "SE";
        private string NumberOfIncludedSegments_SE01;
        private string TransactionSetControlNumber_SE02;
        private const string SegmentID_GE = "GE";
        private const string NumberOfTransactionSetsIncluded_GE01 = "1";
        private string GroupControlNumber_GE02;
        private const string SegmentID_IEA = "IEA";
        private const string NumberOfFunctionalGroupsIncluded_IEA01 = "1";
        private string InterchangeControlNumber_IEA02;
        private const string SegmentTerminator = "~";

        public Trailer() {
            NumberOfIncludedSegments_SE01 = Form1.enrollments.Count.ToString();
            TransactionSetControlNumber_SE02 = InterchangeTracker.GetInterchangeNumber().ToString();
            GroupControlNumber_GE02 = TransactionSetControlNumber_SE02.PadLeft(4, '0');
            InterchangeControlNumber_IEA02 = TransactionSetControlNumber_SE02;
        }

        public new string ToString() {
            return SegmentID_SE + '*' + NumberOfIncludedSegments_SE01 + '*' + TransactionSetControlNumber_SE02.PadLeft(4, '0') + SegmentTerminator + '\n' +
                SegmentID_GE + '*' + NumberOfTransactionSetsIncluded_GE01 + '*' + GroupControlNumber_GE02 + SegmentTerminator + '\n' +
                SegmentID_IEA + '*' + NumberOfFunctionalGroupsIncluded_IEA01 + '*' + InterchangeControlNumber_IEA02.PadLeft(9, '0') + SegmentTerminator;
        }
    }
}
