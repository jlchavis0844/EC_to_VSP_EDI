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

    // public string EnrolledBy { get; set; }
    // public string NewBusiness { get; set; }

    // override to print all frields in a CensusRow
    public override string ToString() {
        string retStr = this.CompanyName + " | " + this.EID + " | " + this.Location + " | " + this.FirstName + " | " +
            this.MiddleName + " | " + this.LastName + " | " + this.Relationship + " | " + this.RelationshipCode + " | " +
            this.SSN + " | " + this.Gender + " | " + this.BirthDate + " | " + this.Race + " | " + this.Citizenship + " | " +
            this.Address1 + " | " + this.Address2 + " | " + this.City + " | " + this.State + " | " + this.Zip + " | " +
            this.County + " | " + this.Country + " | " + this.PersonalPhone + " | " + this.WorkPhone + " | " +
            this.MobilePhone + " | " + this.Email + " | " + this.PersonalEmail + " | " + this.EmployeeType + " | " +
            this.EmployeeStatus + " | " + this.HireDate + " | " + this.TerminationDate + " | " + this.Department + " | " +
            this.Division + " | " + this.JobClass + " | " + this.JobTitle + " | " + this.MaritalStatus + " | " + this.MaritalDate + " | " +
            this.MaritalLocation + " | " + this.StudentStatus + " | " + this.ScheduledHours + " | " + this.SickHours + " | " +
            this.PersonalHours + " | " + this.W2Wages + " | " + this.Compensation + " | " + this.CompensationType + " | " +
            this.PayCycle + " | " + this.PayPeriods + " | " + this.CostFactor + " | " + this.TobaccoUser + " | " + this.Disabled + " | " +
            this.MedicareADate + " | " + this.MedicareBDate + " | " + this.MedicareCDate + " | " + this.MedicareDDate + " | " +
            this.MedicalPCPName + " | " + this.MedicalPCPID + " | " + this.DentalPCPName + " | " + this.DentalPCPID + " | " +
            this.IPANumber + " | " + this.OBGYN + " | " + this.BenefitEligibleDate + " | " + this.UnlockEnrollmentDate + " | " +
            this.OriginalEffectiveDateInfo + " | " + this.SubscriberKey + " | " + this.PlanType + " | " + this.PlanEffectiveStartDate + " | " +
            this.PlanEffectiveEndDate + " | " + this.PlanAdminName + " | " + this.PlanDisplayName + " | " + this.PlanImportID + " | " +
            this.EffectiveDate + " | " + this.CoverageDetails + " | " + this.ElectionStatus + " | " + this.RiderCodes + " | " +
            this.Action + " | " + this.WaiveReason + " | " + this.PolicyNumber + " | " + this.SubgroupNumber + " | " +
            this.AgeDetermination + " | " + this.Carrier + " | " + this.TotalRate + " | " + this.EmployeeRate + " | " +
            this.SpouseRate + " | " + this.ChildrenRate + " | " + this.EmployeeContribution + " | " + this.EmployeePre_TaxCost + " | " +
            this.EmployeePost_TaxCost + " | " + this.EmployeeCostPerDeductionPeriod + " | " + this.PlanDeductionCycle + " | " +
            this.LastModifiedDate + " | " + this.LastModifiedBy + " | " + this.E_SignDate + " | " + this.CalPERS_ID;
        return retStr.Replace("  ", " ");
    }
}

public class CensusRowClassMap : ClassMap<CensusRow> {
    public CensusRowClassMap() {
        this.Map(m => m.CompanyName).Name("Company Name");
        this.Map(m => m.EID).Name("EID");
        this.Map(m => m.Location).Name("Location");
        this.Map(m => m.FirstName).Name("First Name");
        this.Map(m => m.MiddleName).Name("Middle Name");
        this.Map(m => m.LastName).Name("Last Name");
        this.Map(m => m.Relationship).Name("Relationship");
        this.Map(m => m.RelationshipCode).Name("Relationship Code");
        this.Map(m => m.SSN).Name("SSN");
        this.Map(m => m.Gender).Name("Gender");
        this.Map(m => m.BirthDate).Name("Birth Date");
        this.Map(m => m.Race).Name("Race");
        this.Map(m => m.Citizenship).Name("Citizenship");
        this.Map(m => m.Address1).Name("Address 1");
        this.Map(m => m.Address2).Name("Address 2");
        this.Map(m => m.City).Name("City");
        this.Map(m => m.State).Name("State");
        this.Map(m => m.Zip).Name("Zip");
        this.Map(m => m.County).Name("County");
        this.Map(m => m.Country).Name("Country");
        this.Map(m => m.PersonalPhone).Name("Personal Phone");
        this.Map(m => m.WorkPhone).Name("Work Phone");
        this.Map(m => m.MobilePhone).Name("Mobile Phone");
        this.Map(m => m.Email).Name("Email");
        this.Map(m => m.PersonalEmail).Name("Personal Email");
        this.Map(m => m.EmployeeType).Name("Employee Type");
        this.Map(m => m.EmployeeStatus).Name("Employee Status");
        this.Map(m => m.HireDate).Name("Hire Date");
        this.Map(m => m.TerminationDate).Name("Termination Date");
        this.Map(m => m.Department).Name("Department");
        this.Map(m => m.Division).Name("Division");
        this.Map(m => m.JobClass).Name("Job Class");
        this.Map(m => m.JobTitle).Name("Job Title");
        this.Map(m => m.MaritalStatus).Name("Marital Status");
        this.Map(m => m.MaritalDate).Name("Marital Date");
        this.Map(m => m.MaritalLocation).Name("Marital Location");
        this.Map(m => m.StudentStatus).Name("Student Status");
        this.Map(m => m.ScheduledHours).Name("Scheduled Hours");
        this.Map(m => m.SickHours).Name("Sick Hours");
        this.Map(m => m.PersonalHours).Name("Personal Hours");
        this.Map(m => m.W2Wages).Name("W2 Wages");
        this.Map(m => m.Compensation).Name("Compensation");
        this.Map(m => m.CompensationType).Name("Compensation Type");
        this.Map(m => m.PayCycle).Name("Pay Cycle");
        this.Map(m => m.PayPeriods).Name("Pay Periods");
        this.Map(m => m.CostFactor).Name("Cost Factor");
        this.Map(m => m.TobaccoUser).Name("Tobacco User");
        this.Map(m => m.Disabled).Name("Disabled");
        this.Map(m => m.MedicareADate).Name("Medicare A Date");
        this.Map(m => m.MedicareBDate).Name("Medicare B Date");
        this.Map(m => m.MedicareCDate).Name("Medicare C Date");
        this.Map(m => m.MedicareDDate).Name("Medicare D Date");
        this.Map(m => m.MedicalPCPName).Name("Medical PCP Name");
        this.Map(m => m.MedicalPCPID).Name("Medical PCP ID");
        this.Map(m => m.DentalPCPName).Name("Dental PCP Name");
        this.Map(m => m.DentalPCPID).Name("Dental PCP ID");
        this.Map(m => m.IPANumber).Name("IPA Number");
        this.Map(m => m.OBGYN).Name("OBGYN");
        this.Map(m => m.BenefitEligibleDate).Name("Benefit Eligible Date");
        this.Map(m => m.UnlockEnrollmentDate).Name("Unlock Enrollment Date");
        this.Map(m => m.OriginalEffectiveDateInfo).Name("Original Effective Date Info");
        this.Map(m => m.SubscriberKey).Name("Subscriber Key");
        this.Map(m => m.PlanType).Name("Plan Type");
        this.Map(m => m.PlanEffectiveStartDate).Name("Plan Effective Start Date");
        this.Map(m => m.PlanEffectiveEndDate).Name("Plan Effective End Date");
        this.Map(m => m.PlanAdminName).Name("Plan Admin Name");
        this.Map(m => m.PlanDisplayName).Name("Plan Display Name");
        this.Map(m => m.PlanImportID).Name("Plan Import ID");
        this.Map(m => m.EffectiveDate).Name("Effective Date");
        this.Map(m => m.CoverageDetails).Name("Coverage Details");
        this.Map(m => m.ElectionStatus).Name("Election Status");
        this.Map(m => m.RiderCodes).Name("Rider Codes");
        this.Map(m => m.Action).Name("Action");
        this.Map(m => m.WaiveReason).Name("Waive Reason");
        this.Map(m => m.PolicyNumber).Name("Policy Number");
        this.Map(m => m.SubgroupNumber).Name("Subgroup Number");
        this.Map(m => m.AgeDetermination).Name("Age Determination");
        this.Map(m => m.Carrier).Name("Carrier");
        this.Map(m => m.TotalRate).Name("Total Rate");
        this.Map(m => m.EmployeeRate).Name("Employee Rate");
        this.Map(m => m.SpouseRate).Name("Spouse Rate");
        this.Map(m => m.ChildrenRate).Name("Children Rate");
        this.Map(m => m.EmployeeContribution).Name("Employee Contribution");
        this.Map(m => m.EmployeePre_TaxCost).Name("Employee Pre-Tax Cost");
        this.Map(m => m.EmployeePost_TaxCost).Name("Employee Post-Tax Cost");
        this.Map(m => m.EmployeeCostPerDeductionPeriod).Name("Employee Cost Per Deduction Period");
        this.Map(m => m.PlanDeductionCycle).Name("Plan Deduction Cycle");
        this.Map(m => m.LastModifiedDate).Name("Last Modified Date");
        this.Map(m => m.LastModifiedBy).Name("Last Modified By");
        this.Map(m => m.E_SignDate).Name("E-Sign Date");
        this.Map(m => m.CalPERS_ID).Name("CalPERS ID");

        // Map(m => m.EnrolledBy).Name("Enrolled By");
        // Map(m => m.NewBusiness).Name("New Business");
    }
}
