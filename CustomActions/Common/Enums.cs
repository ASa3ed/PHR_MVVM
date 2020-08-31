using System;
using System.Collections.Generic;
using System.Text;

namespace CustomActions.Common
{
    public enum PatientRecordSyncEnum
    {
        Alreadylinked = 1,
        NoMatchedUser = 2,
        SyncedSuccessfully = 3,
        ExpectationFailed = 4
    };
    public enum GenderEnum
    {
        Male = 1,
        Female = 2,
    };
    public enum CountryEnum
    {
        EGY = 1,
        KSA = 2,
    };
    public enum CategoriesEnum
    {
        Lab = 1,
        Rad = 2,
        Operation = 3,
        Procedure = 4,
        Medication = 5,
        Diagnose = 6,
        DiagnoseICD = 7
    };
    public enum ReservationResponsEnum
    {
        PatternNotAvailable = 0,
        SeatNotAvailable = 1,
        ReservationSucceed = 2,
        ReservationFailed = 3
    };


    public enum ReservationASlotResponsEnum
    {
        Succeeded = 0,
        FailedToSave = 1,
        NotAvailable = 2,
        InvalidPattern = 15
    };
    public enum VisitDoctorReservationResponsEnum
    {
        NoPattern = 0,
        ReservationSucceed = 2,
        ReservationFailed = 3
    };
    public enum CrownStatusEnum
    {
        Empty = 0,
        Half = 1,
        Full = 2
    };
    public enum DefaultImagesType 
    {
        MaleDoctor = 1,
        FemaleDoctor = 2,
        Hospital = 3,
        User=4,
        Speciality=5
    };
    public enum ReservationRecordStateEnum
    {
        Pending = 1,
        PaymentReady = 2,
        PaymentPending = 3,
        JoinReady = 4,
        JoinPending = 5
    };

}
