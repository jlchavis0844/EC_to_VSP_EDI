using EC_to_VSP_EDI;

public class Header
{
    private const string SegmentID                       = "ISA";
    private const string AuthorizationInfoQualifier      = "00";
    private const string AuthorizationInfo               = "          ";
    private const string SecurityInfoQualifier           = "00";
    private const string SecurityInfo                    = "          ";
    private const string SenderIDQualifier               = "30";
    private const string SenderID                        = "94-2239786     ";
    private const string ReceiverIDQualifier             = "30";
    private const string ReceiverID                      = "94-1632821    ";
    private string       InterchangeDate;
    private string       InterchangeTime;
    private const char   InterchangeControlID            = '=';
    private const string InterchangeControlVersionNum    = "00501";
    private string       InterchangeControlNum;
    private const char   AcknowledgementRequested        = '0';
    private const char   UsageIndicator                  = 'P';
    private const char   ComponentElementSeparator       = '>';
    private const char   SegmentTerminator               = '~';

    public Header(){
        InterchangeDate = InterchangeTracker.GetInterchangeDate();
        InterchangeTime = InterchangeTracker.GetInterchangeTime();
        InterchangeControlNum = InterchangeTracker.GetInterchangeNumber().ToString().PadLeft(9,'0');
	}

    public new string ToString() {
        return SegmentID + '*' + AuthorizationInfoQualifier + '*' + AuthorizationInfo + '*' + SecurityInfoQualifier + '*' +
            SecurityInfo + '*' + SenderIDQualifier + '*' + SenderID + '*' + ReceiverIDQualifier + '*' + ReceiverID + '*' + InterchangeDate + '*' +
            InterchangeTime + '*' + InterchangeControlID + '*' + InterchangeControlVersionNum + '*' + InterchangeControlNum + '*' +
            AcknowledgementRequested + '*' + UsageIndicator + '*' + ComponentElementSeparator + SegmentTerminator;
    }
}
