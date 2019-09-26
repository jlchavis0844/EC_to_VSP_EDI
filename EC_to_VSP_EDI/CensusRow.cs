using CsvHelper.Configuration;

public class CensusRow {
    public string CompanyName { get; set; }
    public string EID { get; set; }
    public string Location { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Relationship { get; set; }
    public string RelationshipCode { get; set; }
    public string SSN { get; set; }
    public string Gender { get; set; }
    public string BirthDate { get; set; }
    public string Race { get; set; }
    public string Citizenship { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string County { get; set; }
    public string Country { get; set; }
    public string PersonalPhone { get; set; }
    public string WorkPhone { get; set; }
    public string MobilePhone { get; set; }
    public string Email { get; set; }
    public string PersonalEmail { get; set; }
    public string EmployeeType { get; set; }
    public string EmployeeStatus { get; set; }
    public string HireDate { get; set; }
    public string TerminationDate { get; set; }
    public string Department { get; set; }
    public string Division { get; set; }
    public string JobClass { get; set; }
    public string JobTitle { get; set; }
    public string MaritalStatus { get; set; }
    public string MaritalDate { get; set; }
    public string MaritalLocation { get; set; }
    public string StudentStatus { get; set; }
    public string ScheduledHours { get; set; }
    public string SickHours { get; set; }
    public string PersonalHours { get; set; }
    public string W2Wages { get; set; }
    public string Compensation { get; set; }
    public string CompensationType { get; set; }
    public string PayCycle { get; set; }
    public string PayPeriods { get; set; }
    public string CostFactor { get; set; }
    public string TobaccoUser { get; set; }
    public string Disabled { get; set; }
    public string MedicareADate { get; set; }
    public string MedicareBDate { get; set; }
    public string MedicareCDate { get; set; }
    public string MedicareDDate { get; set; }
    public string MedicalPCPName { get; set; }
    public string MedicalPCPID { get; set; }
    public string DentalPCPName { get; set; }
    public string DentalPCPID { get; set; }
    public string IPANumber { get; set; }
    public string OBGYN { get; set; }
    public string BenefitEligibleDate { get; set; }
    public string UnlockEnrollmentDate { get; set; }
    public string OriginalEffectiveDateInfo { get; set; }
    public string SubscriberKey { get; set; }
    public string PlanType { get; set; }
    public string PlanEffectiveStartDate { get; set; }
    public string PlanEffectiveEndDate { get; set; }
    public string PlanAdminName { get; set; }
    public string PlanDisplayName { get; set; }
    public string PlanImportID { get; set; }
    public string EffectiveDate { get; set; }
    public string CoverageDetails { get; set; }
    public string ElectionStatus { get; set; }
    public string RiderCodes { get; set; }
    public string Action { get; set; }
    public string WaiveReason { get; set; }
    public string PolicyNumber { get; set; }
    public string SubgroupNumber { get; set; }
    public string AgeDetermination { get; set; }
    public string Carrier { get; set; }
    public string TotalRate { get; set; }
    public string EmployeeRate { get; set; }
    public string SpouseRate { get; set; }
    public string ChildrenRate { get; set; }
    public string EmployeeContribution { get; set; }
    public string EmployeePre_TaxCost { get; set; }
    public string EmployeePost_TaxCost { get; set; }
    public string EmployeeCostPerDeductionPeriod { get; set; }
    public string PlanDeductionCycle { get; set; }
    public string LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; }
    public string E_SignDate { get; set; }
    public string CalPERS_ID { get; set; }

    //public string EnrolledBy { get; set; }
    //public string NewBusiness { get; set; }


    //override to print all frields in a CensusRow
    public override string ToString() {
        string retStr = CompanyName + " | " + EID + " | " + Location + " | " + FirstName + " | " +
            MiddleName + " | " + LastName + " | " + Relationship + " | " + RelationshipCode + " | " +
            SSN + " | " + Gender + " | " + BirthDate + " | " + Race + " | " + Citizenship + " | " +
            Address1 + " | " + Address2 + " | " + City + " | " + State + " | " + Zip + " | " +
            County + " | " + Country + " | " + PersonalPhone + " | " + WorkPhone + " | " +
            MobilePhone + " | " + Email + " | " + PersonalEmail + " | " + EmployeeType + " | " +
            EmployeeStatus + " | " + HireDate + " | " + TerminationDate + " | " + Department + " | " +
            Division + " | " + JobClass + " | " + JobTitle + " | " + MaritalStatus + " | " + MaritalDate + " | " +
            MaritalLocation + " | " + StudentStatus + " | " + ScheduledHours + " | " + SickHours + " | " +
            PersonalHours + " | " + W2Wages + " | " + Compensation + " | " + CompensationType + " | " +
            PayCycle + " | " + PayPeriods + " | " + CostFactor + " | " + TobaccoUser + " | " + Disabled + " | " +
            MedicareADate + " | " + MedicareBDate + " | " + MedicareCDate + " | " + MedicareDDate + " | " +
            MedicalPCPName + " | " + MedicalPCPID + " | " + DentalPCPName + " | " + DentalPCPID + " | " +
            IPANumber + " | " + OBGYN + " | " + BenefitEligibleDate + " | " + UnlockEnrollmentDate + " | " +
            OriginalEffectiveDateInfo + " | " + SubscriberKey + " | " + PlanType + " | " + PlanEffectiveStartDate + " | " +
            PlanEffectiveEndDate + " | " + PlanAdminName + " | " + PlanDisplayName + " | " + PlanImportID + " | " +
            EffectiveDate + " | " + CoverageDetails + " | " + ElectionStatus + " | " + RiderCodes + " | " +
            Action + " | " + WaiveReason + " | " + PolicyNumber + " | " + SubgroupNumber + " | " +
            AgeDetermination + " | " + Carrier + " | " + TotalRate + " | " + EmployeeRate + " | " +
            SpouseRate + " | " + ChildrenRate + " | " + EmployeeContribution + " | " + EmployeePre_TaxCost + " | " +
            EmployeePost_TaxCost + " | " + EmployeeCostPerDeductionPeriod + " | " + PlanDeductionCycle + " | " +
            LastModifiedDate + " | " + LastModifiedBy + " | " + E_SignDate + " | " + CalPERS_ID;
        return retStr.Replace("  ", " ");
    }
}


public class CensusRowClassMap : ClassMap<CensusRow> {
    public CensusRowClassMap() {
        Map(m => m.CompanyName).Name("Company Name");
        Map(m => m.EID).Name("EID");
        Map(m => m.Location).Name("Location");
        Map(m => m.FirstName).Name("First Name");
        Map(m => m.MiddleName).Name("Middle Name");
        Map(m => m.LastName).Name("Last Name");
        Map(m => m.Relationship).Name("Relationship");
        Map(m => m.RelationshipCode).Name("Relationship Code");
        Map(m => m.SSN).Name("SSN");
        Map(m => m.Gender).Name("Gender");
        Map(m => m.BirthDate).Name("Birth Date");
        Map(m => m.Race).Name("Race");
        Map(m => m.Citizenship).Name("Citizenship");
        Map(m => m.Address1).Name("Address 1");
        Map(m => m.Address2).Name("Address 2");
        Map(m => m.City).Name("City");
        Map(m => m.State).Name("State");
        Map(m => m.Zip).Name("Zip");
        Map(m => m.County).Name("County");
        Map(m => m.Country).Name("Country");
        Map(m => m.PersonalPhone).Name("Personal Phone");
        Map(m => m.WorkPhone).Name("Work Phone");
        Map(m => m.MobilePhone).Name("Mobile Phone");
        Map(m => m.Email).Name("Email");
        Map(m => m.PersonalEmail).Name("Personal Email");
        Map(m => m.EmployeeType).Name("Employee Type");
        Map(m => m.EmployeeStatus).Name("Employee Status");
        Map(m => m.HireDate).Name("Hire Date");
        Map(m => m.TerminationDate).Name("Termination Date");
        Map(m => m.Department).Name("Department");
        Map(m => m.Division).Name("Division");
        Map(m => m.JobClass).Name("Job Class");
        Map(m => m.JobTitle).Name("Job Title");
        Map(m => m.MaritalStatus).Name("Marital Status");
        Map(m => m.MaritalDate).Name("Marital Date");
        Map(m => m.MaritalLocation).Name("Marital Location");
        Map(m => m.StudentStatus).Name("Student Status");
        Map(m => m.ScheduledHours).Name("Scheduled Hours");
        Map(m => m.SickHours).Name("Sick Hours");
        Map(m => m.PersonalHours).Name("Personal Hours");
        Map(m => m.W2Wages).Name("W2 Wages");
        Map(m => m.Compensation).Name("Compensation");
        Map(m => m.CompensationType).Name("Compensation Type");
        Map(m => m.PayCycle).Name("Pay Cycle");
        Map(m => m.PayPeriods).Name("Pay Periods");
        Map(m => m.CostFactor).Name("Cost Factor");
        Map(m => m.TobaccoUser).Name("Tobacco User");
        Map(m => m.Disabled).Name("Disabled");
        Map(m => m.MedicareADate).Name("Medicare A Date");
        Map(m => m.MedicareBDate).Name("Medicare B Date");
        Map(m => m.MedicareCDate).Name("Medicare C Date");
        Map(m => m.MedicareDDate).Name("Medicare D Date");
        Map(m => m.MedicalPCPName).Name("Medical PCP Name");
        Map(m => m.MedicalPCPID).Name("Medical PCP ID");
        Map(m => m.DentalPCPName).Name("Dental PCP Name");
        Map(m => m.DentalPCPID).Name("Dental PCP ID");
        Map(m => m.IPANumber).Name("IPA Number");
        Map(m => m.OBGYN).Name("OBGYN");
        Map(m => m.BenefitEligibleDate).Name("Benefit Eligible Date");
        Map(m => m.UnlockEnrollmentDate).Name("Unlock Enrollment Date");
        Map(m => m.OriginalEffectiveDateInfo).Name("Original Effective Date Info");
        Map(m => m.SubscriberKey).Name("Subscriber Key");
        Map(m => m.PlanType).Name("Plan Type");
        Map(m => m.PlanEffectiveStartDate).Name("Plan Effective Start Date");
        Map(m => m.PlanEffectiveEndDate).Name("Plan Effective End Date");
        Map(m => m.PlanAdminName).Name("Plan Admin Name");
        Map(m => m.PlanDisplayName).Name("Plan Display Name");
        Map(m => m.PlanImportID).Name("Plan Import ID");
        Map(m => m.EffectiveDate).Name("Effective Date");
        Map(m => m.CoverageDetails).Name("Coverage Details");
        Map(m => m.ElectionStatus).Name("Election Status");
        Map(m => m.RiderCodes).Name("Rider Codes");
        Map(m => m.Action).Name("Action");
        Map(m => m.WaiveReason).Name("Waive Reason");
        Map(m => m.PolicyNumber).Name("Policy Number");
        Map(m => m.SubgroupNumber).Name("Subgroup Number");
        Map(m => m.AgeDetermination).Name("Age Determination");
        Map(m => m.Carrier).Name("Carrier");
        Map(m => m.TotalRate).Name("Total Rate");
        Map(m => m.EmployeeRate).Name("Employee Rate");
        Map(m => m.SpouseRate).Name("Spouse Rate");
        Map(m => m.ChildrenRate).Name("Children Rate");
        Map(m => m.EmployeeContribution).Name("Employee Contribution");
        Map(m => m.EmployeePre_TaxCost).Name("Employee Pre-Tax Cost");
        Map(m => m.EmployeePost_TaxCost).Name("Employee Post-Tax Cost");
        Map(m => m.EmployeeCostPerDeductionPeriod).Name("Employee Cost Per Deduction Period");
        Map(m => m.PlanDeductionCycle).Name("Plan Deduction Cycle");
        Map(m => m.LastModifiedDate).Name("Last Modified Date");
        Map(m => m.LastModifiedBy).Name("Last Modified By");
        Map(m => m.E_SignDate).Name("E-Sign Date");
        Map(m => m.CalPERS_ID).Name("CalPERS ID");
        //Map(m => m.EnrolledBy).Name("Enrolled By");
        //Map(m => m.NewBusiness).Name("New Business");
    }
}
