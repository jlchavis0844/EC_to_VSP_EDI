﻿using EC_to_VSP_EDI;

public class Header {
    private const string SegmentID = "ISA";
    private const string AuthorizationInfoQualifier = "00";
    private readonly string AuthorizationInfo = "".PadLeft(10);
    private const string SecurityInfoQualifier = "00";
    private readonly string SecurityInfo = "".PadLeft(10);
    private const string SenderIDQualifier = "30";
    private readonly string SenderID = "94-2239786".PadRight(15);//15 fixed width
    private const string ReceiverIDQualifier = "30";
    private readonly string ReceiverID = "94-1632821".PadRight(15);
    private readonly string InterchangeDate;
    private readonly string InterchangeTime;
    private const char InterchangeControlID = '=';
    private const string InterchangeControlVersionNum = "00501";
    private readonly string InterchangeControlNum;
    private const char AcknowledgementRequested = '0';
    private readonly char UsageIndicator;
    private const char ComponentElementSeparator = '>';
    private const char SegmentTerminator = '~';

    public Header(string type) {
        InterchangeDate = InterchangeTracker.GetInterchangeDate();
        InterchangeTime = InterchangeTracker.GetInterchangeTime();
        InterchangeControlNum = InterchangeTracker.GetInterchangeNumber().ToString().PadLeft(9, '0');

        if(type == TransactionSetPurposes.Test) {
            UsageIndicator = 'T';
        } else {
            UsageIndicator = 'P';
        }
    }

    public new string ToString() {
        return SegmentID + '*' + AuthorizationInfoQualifier + '*' + AuthorizationInfo + '*' + SecurityInfoQualifier + '*' +
            SecurityInfo + '*' + SenderIDQualifier + '*' + SenderID + '*' + ReceiverIDQualifier + '*' + ReceiverID + '*' + InterchangeDate + '*' +
            InterchangeTime + '*' + InterchangeControlID + '*' + InterchangeControlVersionNum + '*' + InterchangeControlNum + '*' +
            AcknowledgementRequested + '*' + UsageIndicator + '*' + ComponentElementSeparator + SegmentTerminator;
    }
}
